using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace ImgSaveSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void search_btn_Click(object sender, EventArgs e)
        {                        
            string query = search_tbox.Text.ToString(); // 검색할 문자열
            string start = start_tbox.Text.ToString();
            string ect = "&display=100&sort=sim&start=";
            string url = "https://openapi.naver.com/v1/search/image.xml?query=" + query + ect + start; // 결과가 JSON 포맷
            string save = Save_tbox.Text.ToString();

            // -------- 저장할 저장공간 컴퓨터 옴길시 필수 변경 
            string savedirSrc = "C: \\Users\\daejung\\Desktop\\test\\";
            // --------------------------------------------------- 

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Naver-Client-Id", "ynggkN0M4bjWZKbCwGrW"); // 클라이언트 아이디
            request.Headers.Add("X-Naver-Client-Secret", "Ob05r06CbM");       // 클라이언트 시크릿
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string status = response.StatusCode.ToString();
            
            if (status == "OK")
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                
                XmlDocument xdoc = new XmlDocument();
                           
                xdoc.Load(reader);

                XmlNodeList xnl = xdoc.GetElementsByTagName("link");

                int su = int.Parse(start);

                int i = 1;

                int su2 = su + 100;

                for( ;su<su2;su++)
                {                    
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(new Uri(xnl.Item(i).InnerText));

                    HttpWebResponse result = (HttpWebResponse)req.GetResponse();

                    Stream ReceiveStream = result.GetResponseStream();

                    // Byte 배열 생성
                    Byte[] read = new Byte[512];

                    // 스트림 내의 현재 위치는 읽은 바이트 수만큼 앞으로 이동(512 바이트 씩 Read)
                    int bytes = ReceiveStream.Read(read, 0, 512);

                    // 파일 객체 생성
                    // 파일에 대해 Stream 을 제공하여, 읽기, 쓰기 작업을 모두 지원
                    Encoding encode = System.Text.Encoding.Default;
                    
                    
                    //디렉터리 생성
                    DirectoryInfo di = new DirectoryInfo(savedirSrc + query);   
                    if (di.Exists == false)    
                    {
                        di.Create();               
                    }

                    //파일 생성 및 라이트
                    string saveurl = savedirSrc + query+"\\"+save+ su.ToString() + ".png";
                    FileStream FileStr = new FileStream(saveurl, FileMode.OpenOrCreate, FileAccess.Write);

                    // FileStream에 byte 쓰기
                    // 스트림의 끝에 도달 하면 0 이 Return
                    while (bytes > 0)
                    {
                        // 버퍼의 데이터를 사용하여 이 스트림에 바이트 블록을 씀
                        FileStr.Write(read, 0, bytes);
                        bytes = ReceiveStream.Read(read, 0, 512);

                    }
                    // Save File
                    BinaryWriter Savefile = new BinaryWriter(FileStr, encode);
                    Savefile.Close();

                    i++;

                }

            }
            else
            {
                MessageBox.Show("Error 발생 = " + status);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = search_tbox.Text.ToString(); // 검색할 문자열
            string start = start_tbox.Text.ToString();
            string ect = "&display=100&sort=sim&start=";
            string url = "https://openapi.naver.com/v1/search/image.xml?query=" + query + ect + start; // 결과가 JSON 포맷
            string save = Save_tbox.Text.ToString();

            // -------- 저장할 저장공간 컴퓨터 옴길시 필수 변경 
            string savedirSrc = "C: \\Users\\daejung\\Desktop\\test\\";
            // --------------------------------------------------- 

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Naver-Client-Id", "ynggkN0M4bjWZKbCwGrW"); // 클라이언트 아이디
            request.Headers.Add("X-Naver-Client-Secret", "Ob05r06CbM");       // 클라이언트 시크릿
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string status = response.StatusCode.ToString();

            if (status == "OK")
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);

                XmlDocument xdoc = new XmlDocument();

                xdoc.Load(reader);

                XmlNodeList xnl = xdoc.GetElementsByTagName("link");

                int su = int.Parse(start);

                int i = 1;

                int su2 = su + 100;

                for (; su < su2; su++)
                {
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(new Uri(xnl.Item(i).InnerText));

                    HttpWebResponse result = (HttpWebResponse)req.GetResponse();

                    Stream ReceiveStream = result.GetResponseStream();

                    // Byte 배열 생성
                    Byte[] read = new Byte[512];

                    // 스트림 내의 현재 위치는 읽은 바이트 수만큼 앞으로 이동(512 바이트 씩 Read)
                    int bytes = ReceiveStream.Read(read, 0, 512);

                    // 파일 객체 생성
                    // 파일에 대해 Stream 을 제공하여, 읽기, 쓰기 작업을 모두 지원
                    Encoding encode = System.Text.Encoding.Default;


                    //디렉터리 생성
                    DirectoryInfo di = new DirectoryInfo(savedirSrc + query);
                    if (di.Exists == false)
                    {
                        di.Create();
                    }

                    //파일 생성 및 라이트
                    string saveurl = savedirSrc + query + "\\" + save + su.ToString() + ".png";
                    FileStream FileStr = new FileStream(saveurl, FileMode.OpenOrCreate, FileAccess.Write);

                    // FileStream에 byte 쓰기
                    // 스트림의 끝에 도달 하면 0 이 Return
                    while (bytes > 0)
                    {
                        // 버퍼의 데이터를 사용하여 이 스트림에 바이트 블록을 씀
                        FileStr.Write(read, 0, bytes);
                        bytes = ReceiveStream.Read(read, 0, 512);

                    }
                    // Save File
                    BinaryWriter Savefile = new BinaryWriter(FileStr, encode);
                    Savefile.Close();

                    i++;

                }

            }
            else
            {
                MessageBox.Show("Error 발생 = " + status);
            }
        }
    }
}
