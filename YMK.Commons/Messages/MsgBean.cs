using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace YMK.Commons.Messages
{
    [Serializable]
    [XmlRoot("configuration")]
    public class MsgBean
    {
        [XmlElement("msgs")]
        public MsgInfoList msgInfos { get; set; }

        public MsgBean()
        {
        }
    }
}
