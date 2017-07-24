using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bowu
{
    public class SinaBean
    {
        private string _name;       //名称
        private string _price;      //価格
        private string _offset;     //増加価格
        private string _percent;    //％
        private Int32 _turnover;   //売上額

        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }



        /// <summary>
        /// 価格
        /// </summary>
        public string Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }

        /// <summary>
        /// 増加価格
        /// </summary>
        public string Offset
        {
            get
            {
                return _offset;
            }
            set
            {
                _offset = value;
            }
        }

        /// <summary>
        /// ％
        /// </summary>
        public string Percent
        {
            get
            {
                return _percent;
            }
            set
            {
                _percent = value;
            }
        }

        /// <summary>
        /// 売上額
        /// </summary>
        public Int32 Turnover
        {
            get
            {
                return _turnover;
            }
            set
            {
                _turnover = value;
            }
        }


    }
}
