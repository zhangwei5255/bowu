using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace YMK.Commons.Messages
{
    [Serializable]
    [XmlRoot("MsgInfo")]
    public class MsgInfo
    {
        //XML属性の名称(id)を指定しなければ、デフォルトはプロパティの名称をXML属性とする
        [XmlAttribute("id")]
        public string ID { get; set; }

        //[XmlAttribute("cd")]
        //public int Cd { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }

        public MsgInfo()
        {
        }
    }


    [Serializable]
    [XmlRoot("MsgInfoList")]
    public class MsgInfoList
    {
        [XmlArrayItem("msg", typeof(MsgInfo))]
        [XmlArray("items")]
        public List<MsgInfo> Items
        {
            get;
            set;
        }

        public MsgInfoList()
        {
            Items = new List<MsgInfo>();
        }
    }
}
