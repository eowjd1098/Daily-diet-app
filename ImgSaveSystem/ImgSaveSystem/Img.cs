using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ImgSaveSystem
{
    [Serializable]
    class Img
    {
        public Img()
        {
            ImgeUrl = string.Empty;
        }

        public Img(XmlNode imgeurl)
        {
            string img = imgeurl.SelectSingleNode("link").InnerText;
            ImgeUrl = img;
        }


        public string ImgeUrl
        {
            get;
            set;
        }


    }
}
