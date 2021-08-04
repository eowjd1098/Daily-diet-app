using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Service
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 클래스 이름 "Service"을 변경할 수 있습니다.
    [ServiceBehavior]
    public class Service : IService
    {
        DBManager DBM = DBManager.GetInstance();
        
        #region Public

        #region 연결테스트
        public bool ConnectTest()
        {
            var context = OperationContext.Current;
            var prop = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;

            string ipText = endpoint.Address;

            Console.WriteLine(ipText + " connet try " + DateTime.Now.ToString());
            return true;
        }
        #endregion
        
        #region 회원가입         
        /// <returns> 성공 = 1, 아이디 중복 = 2, 추가실패 = 3 </returns>
        public int AddMember(string id, string pw, string name, string age, string gender)
        {
            ViewLog(id, "Sign up try");

            if (DBM.IDCheckDB(id) == false)
            {
                ViewLog(id, "Sign up fail (id Overlap)");
                return 2;
            }

            if (DBM.AddMember(id, pw, name, age, gender) == false)
            {
                ViewLog(id, "Sign up fail");
                return 3;
            }

            ViewLog(id, "Sign up Success");
            return 1;
        }
        #endregion

        #region 로그인       
        /// <returns> 에러 = 0, 성공 = 1, 비번틀림 = 2, 아이디없음 = 3 </returns>
        public int Login(string id, string pw)
        {
            ViewLog(id, "login try");
            int result = DBM.Login(id, pw);

            switch (result)
            {
                case 0: ViewLog(id, "login fail"); return 0;
                case 1: ViewLog(id, "login success"); return 1;
                case 2: ViewLog(id, "login fail(Password)"); return 2;
                case 3: ViewLog(id, "login fail(Nonexistent Email"); return 3;
                default:
                    break;
            }
            return result;
        }
        #endregion

        #region 이미지 분석 로직
        public FoodNutrient ImageAnalysis(string id,byte[] img)
        {
            ViewLog(id, "ImageAnalysis try");

            // 이미지 파일명 생성및 저장
            ViewLog(id, "ImageSave try");
            string imgfath = SaveImg(id, img);
            if (imgfath == "f")
            {
                ViewLog(id, "ImageSave fail");
                return null;
            }
            ViewLog(id, "ImageSave success");

            // WCF -> 인공지능 분석요청(이미지)
            ViewLog(id, "SendImgforTen try");
            int fid = SendImgforTen(imgfath);
            switch (fid)
            {
                case -1: ViewLog(id, "SendImgforTen Fail"); return null;
                case 0: ViewLog(id, "SendImgforTen  Can not Find Food"); return null;
            }
            ViewLog(id, "SendImgforTen success");

            //분석결과로 음식영양소 조회
            ViewLog(id, "FindFoodFid try");
            FoodNutrient foodnutrient = DBM.FindFoodbyFid(fid);
            if (foodnutrient == null)
            {
                ViewLog(id, "FindFoodFid fail");
                return null;
            }
            foodnutrient.IMG = img;
            ViewLog(id, "FindFoodFid success");

            //WCF -> DB 저장 (조회 아이디랑 음식종류결과, 분석요청한시간 저장)
            ViewLog(id, "SaveEatFood try");
            int mid = DBM.FindMIDByID(id);
            bool saveresult = DBM.SaveEatFood(fid, mid, DateTime.Now.ToString());

            if (saveresult == false)
            {
                ViewLog(id, "SaveEatFood fail");
                return null;
            }
            ViewLog(id, "SaveEatFood success");
		     ViewLog(id, "ImageAnalysis success");
            //WCF -> 안드로이드 전송 (음식정보 반환)               
            return foodnutrient;
        }
        #endregion

        #region 먹은 음식 정보 조회
        public FoodNutrient LoadEatFood(string id, string date)
        {
            // 해당 일에 id 가 먹은 음식 조회
            ViewLog(id, "LoadEatFood try");
            int mid = DBM.FindMIDByID(id);		

            ArrayList fid = DBM.FindFID(mid, date);

            if (fid == null)
            {
                ViewLog(id, "LoadEatFood fail");
                return null;
            }
            //영양소 합
            FoodNutrient allfoodnutrient = LoadFoodAll(fid);
            if (allfoodnutrient == null)
            {
                ViewLog(id, "LoadEatFood fail");
                return null;
            }
            ViewLog(id, "LoadEatFood success");

            return allfoodnutrient;
        }
        #endregion
        #endregion

        #region Private
        #region 먹은 음식 총합 영양소
        private FoodNutrient LoadFoodAll(ArrayList fid)
        {
            FoodNutrient allFoodNutrient = new FoodNutrient();
            for (int i = 0; i < fid.Count; i++)
            {
                FoodNutrient FoodNutrient = DBM.FindFoodbyFid((int)fid[i]);
                allFoodNutrient.Kcal = allFoodNutrient.Kcal + FoodNutrient.Kcal;
                allFoodNutrient.Cho = allFoodNutrient.Cho + FoodNutrient.Cho;
                allFoodNutrient.Fat = allFoodNutrient.Fat + FoodNutrient.Fat;
                allFoodNutrient.Protein = allFoodNutrient.Protein + FoodNutrient.Protein;
                allFoodNutrient.Na = allFoodNutrient.Na + FoodNutrient.Na;
            }
            return allFoodNutrient;
        }
        #endregion

        #region 이미지저장 및 이미지 변환
        private string SaveImg(string id, byte[] img)
        {           
            try
            {
                int mid = DBM.FindMIDByID(id);
                int mcount = DBM.CountFood(mid);
                string fpath = @"/home/songminsang/work/food/";    // 기본베이스주소                 
                string filenaem = mid.ToString() + "_" + mcount.ToString() + ".jpg";        // 파일명 = SID+파일카운트.확장자 
                string path = fpath + filenaem;
                FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write);
                stream.Write(img, 0, img.Length);
                stream.Dispose();

                //이미지 변환
                Process convert = new Process();
                convert.StartInfo.UseShellExecute = false;
                convert.StartInfo.RedirectStandardOutput = true;
                convert.StartInfo.FileName = "convert";
                convert.StartInfo.Arguments = "-resize 600x600! " + path + " " + path;
                convert.Start();
                convert.WaitForExit(); // 프로세스 종료시까지 대기     

                return path;
            }
            catch (Exception e)
            {
                Console.WriteLine("SaveImg :"+e);
                return "f";
            }
        }
        #endregion

        #region 텐서플로우 분석
        private int SendImgforTen(string imgaddr)//0 = 분석자료없음 
        {           
            try
            {
                Process ten = new Process();
                ten.StartInfo.UseShellExecute = false;
                ten.StartInfo.RedirectStandardOutput = true;
                ten.StartInfo.FileName = "/home/songminsang/anaconda2/bin/python";
                ten.StartInfo.Arguments = "/home/songminsang/work/food/label_image.py " + imgaddr;
                ten.Start();

                string output = ten.StandardOutput.ReadToEnd();
                Console.WriteLine(output);
				int result = 0;
				// 10~30 은  2자리 컷팅  	// 1~9 는 1자리 컷팅
				if(output.Substring(1, 1)==" ")
				{
					result=int.Parse(output.Substring(0,1));
				}
				else
				{
					result=int.Parse(output.Substring(0,2));
				}
				return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("SendImgforTen :"+e);
                return -1;
            }

        }
        #endregion

        #region ViewLogConsole
        private void ViewLog(string id, string format)
        {
            var context = OperationContext.Current;
            var prop = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            string ipText = endpoint.Address;

            Console.WriteLine(ipText + " " + id + " " + format + " " + DateTime.Now.ToString());
        }        
        #endregion        
        #endregion

        
    }


}
