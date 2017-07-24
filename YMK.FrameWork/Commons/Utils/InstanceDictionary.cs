using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace YMK.FrameWork.Commons.Utils
{

    public class InstanceDictionary
    {
        /// <summary>
        /// Initialize a Dictionary<string,string> by a text file. every line in txt file will be as a key-value pair
        /// exclude the line is start with "#". this sharp character means the line is a comment line
        /// </summary>
        /// <param name="initFilePath"></param>
        public InstanceDictionary(string initFilePath)
        {
            dictionary.Clear();
            using (StreamReader sr = new StreamReader(initFilePath))
            {
                string tmp = "";
                string[] tmpArr;
                while (sr.Peek() != -1)
                {
                    tmp = sr.ReadLine();
                    if (tmp.StartsWith("#"))
                        continue;
                    tmpArr = tmp.Split(new string[] { "|", "\t" },2, StringSplitOptions.RemoveEmptyEntries);
                    if (tmpArr.Length > 1)
                    {
                        dictionary.Add(tmpArr[0], tmpArr[1]);
                    }
                }
            }
        }

        public InstanceDictionary(string initFilePath,int count,string[] splitStringList)
        {
            dictionary.Clear();
            using (StreamReader sr = new StreamReader(initFilePath))
            {
                string tmp = "";
                string[] tmpArr;
                while (sr.Peek() != -1)
                {
                    tmp = sr.ReadLine();
                    tmpArr = tmp.Split(splitStringList, count, StringSplitOptions.RemoveEmptyEntries);
                    if (tmpArr.Length > 1)
                    {
                        dictionary.Add(tmpArr[0], tmpArr[1]);
                    }
                }
            }
        }

        public string this[string key]
        {
            get { return dictionary[key]; }
            set { dictionary[key] = value; }
        }

        Dictionary<string, string> dictionary = new Dictionary<string, string>();
    }
}
