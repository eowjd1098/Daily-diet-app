using System;
using MySql.Data.MySqlClient;
using System.Collections;

namespace Service
{
    class DBManager
    {
        #region 싱글톤 
        static DBManager dbm;
        protected DBManager() { }
        public static DBManager GetInstance()
        {
            if (dbm == null)
            {
                dbm = new DBManager();
            }
            return dbm;
        }
        #endregion

        #region DB 연결
        //DB 서버 주소 연결        
		static string connStr = "Server=localhost;" +
							"Database=DDA_DB;" +
							"User ID=root;" +
							"Password=root;" +
							"Pooling=false";

        MySqlConnection scon = new MySqlConnection(connStr); // DB 연결
        #endregion
               
        #region ID 중복검사 
        internal bool IDCheckDB(string id)
        {
            string sql = "SELECT * FROM member";
            using (MySqlCommand scom = new MySqlCommand(sql, scon))
            {
                scom.Connection.Open();
                using (MySqlDataReader reader = scom.ExecuteReader())
                {
                    if (reader == null)
                    {
                        scom.Connection.Close();
                        return false;
                    }
                    while (reader.Read())
                    {
                        if (reader["id"].Equals(id))
                        {
                            //Email이 중복 되면
                            scom.Connection.Close();
                            return false;
                        }
                    }
                    //Email이 일치하는게 없을때
                    scom.Connection.Close();
                    return true;
                }
            }
        }
        #endregion              

        #region 회원 가입 
        internal bool AddMember(string id, string pw, string name, string age, string gender)
        {
            string sql = "INSERT INTO member(id, pw, name, age, gender) VALUES(@id, @pw,@name,@age,@gender)";            

            using (MySqlCommand scom = new MySqlCommand(sql, scon))
            {
                MySqlParameter sp_id = new MySqlParameter("@id", id);
                MySqlParameter sp_pw = new MySqlParameter("@pw", pw);
                MySqlParameter sp_name = new MySqlParameter("@name", name);
                MySqlParameter sp_age = new MySqlParameter("@age", age);
                MySqlParameter sp_gender = new MySqlParameter("@gender", gender);

                scom.Parameters.Add(sp_id);
                scom.Parameters.Add(sp_pw);
                scom.Parameters.Add(sp_name);
                scom.Parameters.Add(sp_age);
                scom.Parameters.Add(sp_gender);

                scom.Connection.Open();
                int re = scom.ExecuteNonQuery();
                scom.Connection.Close();
                if (re >= 1)
                {                    
                    if(re == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion
        
        #region 로그인        
        internal int Login(string id, string pw)
        {
			 
            string sql = "SELECT * FROM member";
            using (MySqlCommand scom = new MySqlCommand(sql, scon))
            {
                scom.Connection.Open();
                using (MySqlDataReader reader = scom.ExecuteReader())
                {
                    if (reader == null)
                    {
                        scom.Connection.Close();
                        return 0; // 에러
                    }
                    while (reader.Read())
                    {
                        if (reader["id"].Equals(id))
                        {
                            if (reader["pw"].Equals(pw))
                            {
                                scom.Connection.Close();
                                return 1; // 정상반환                               
                            }
                            else
                            {
                                //비밀번호가 틀릴때
                                scom.Connection.Close();
                                return 2; // 비번 불일치
                            }
                        }
                    }
                    //ID가 일치하는게 없을때
                    scom.Connection.Close();
                    return 3; // 아이디없음
                }
            }
        }        
        #endregion
       
        #region ID로 MID 조회
        internal int FindMIDByID(string id)
        {
            string sql = string.Format("SELECT * FROM member where id ='{0}'",id);
            using (MySqlCommand scom = new MySqlCommand(sql, scon))
            {
                scom.Connection.Open();
                using (MySqlDataReader reader = scom.ExecuteReader())
                {
                    if (reader == null)
                    {
                        scom.Connection.Close();
                        return 0; // 에러
                    }
                    try
                    {
                        reader.Read();
                        int mid = int.Parse(reader["mid"].ToString());
                        scom.Connection.Close();
                        return mid; // 정상반환
                    }
                    catch (Exception e)
                    {
						Console.WriteLine("FindMIDByID :"+e);
                        scom.Connection.Close();
                        return 0;
                    }
                }
            }
        }
        #endregion

        #region 음식 분석요청 저장 (mid,fid,time 저장)  
        internal bool SaveEatFood(int fid, int mid, string time)
        {
            string sql = "INSERT INTO memberandfood(mid, fid,time) VALUES(@mid, @fid, @time)";

            using (MySqlCommand scom = new MySqlCommand(sql, scon))
            {
                MySqlParameter sp_mid = new MySqlParameter("@mid", mid);
                MySqlParameter sp_fid = new MySqlParameter("@fid", fid);
                MySqlParameter sp_time = new MySqlParameter("@time", time);

                scom.Parameters.Add(sp_mid);
                scom.Parameters.Add(sp_fid);
                scom.Parameters.Add(sp_time);

                scom.Connection.Open();
                int re = scom.ExecuteNonQuery();
                scom.Connection.Close();
                if (re >= 1)
                {
                    if (re == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region 음식정보 조회
        internal FoodNutrient FindFoodbyFid(int resultfood)
        {			
            string sql = string.Format("SELECT * FROM food where fid ='{0}'", resultfood);
            using (MySqlCommand scom = new MySqlCommand(sql, scon))
            {
                scom.Connection.Open();
                using (MySqlDataReader reader = scom.ExecuteReader())
                {
                    if (reader == null)
                    {
                        scom.Connection.Close();
                        return null; // 에러
                    }
                    try
                    {						
                        reader.Read();
                        string name = reader["name"].ToString();
                        int kcal      = int.Parse(reader["kcal"].ToString());
                        double cho    = double.Parse(reader["cho"].ToString());
                        double fat    = double.Parse(reader["fat"].ToString());
                        double protein= double.Parse(reader["protein"].ToString());
                        double na     = double.Parse(reader["m_na"].ToString());
                       
                        FoodNutrient foodnutrient = new FoodNutrient(name, kcal, cho, fat, protein, na);
                        scom.Connection.Close();
                        return foodnutrient; // 정상반환
                    }
                    catch (Exception e)
                    {
						Console.WriteLine("FindFoodByFid :"+e);
                        scom.Connection.Close();
                        return null;
                    }
                }
            }
        }
        #endregion

        #region 음식 분석요청 조회 회수 
        internal int CountFood(int mid)
        {
            string sql = string.Format("SELECT COUNT(*) FROM memberandfood where mid ='{0}'", mid);
            using (MySqlCommand scom = new MySqlCommand(sql, scon))
            {
                scom.Connection.Open();
                using (MySqlDataReader reader = scom.ExecuteReader())
                {
                    if (reader == null)
                    {
                        scom.Connection.Close();
                        return 0; // 에러
                    }
                    try
                    {
                        reader.Read();
                        int count = int.Parse(reader["count(*)"].ToString());
                        scom.Connection.Close();
                        return count; // 정상반환
                    }
                    catch (Exception e)
                    {
						Console.WriteLine("Count Food :"+e);
                        scom.Connection.Close();
                        return 0;
                    }
                }
            }
        }
        #endregion
        
        #region FID 조회
        internal ArrayList FindFID(int mid, string date)
        {
            DateTime dtdate = DateTime.ParseExact(date, "yyyyMMdd", null);
            DateTime dtdate2 = dtdate + TimeSpan.FromDays(1);

            string sql = string.Format("SELECT* FROM memberandfood where time between '{0}' and '{1}' and mid = {2}", dtdate.ToString(), dtdate2.ToString(), mid);

			using (MySqlCommand scom = new MySqlCommand(sql, scon))
            {
                scom.Connection.Open();
                using (MySqlDataReader reader = scom.ExecuteReader())
                {
                    if (reader == null)
                    {						
                        scom.Connection.Close();
                        return null; // 에러
                    }
                    try
                    {						
                        ArrayList fid = new ArrayList();
                        while (reader.Read())
                        {
                            fid.Add(int.Parse(reader["fid"].ToString()));
                        }
                        scom.Connection.Close();
                        return fid; // 정상반환
                    }
                    catch (Exception e)
                    {
						Console.WriteLine("FindFid :"+e);
                        scom.Connection.Close();
                        return null;
                    }
                }
            }
        }
        #endregion

    }
}
