using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using YMK.FrameWork.Commons.Utils.Configuration;

namespace com.en.users.Common.Contexts.Utils
{
    public class FrameworkConfigInfo
    {
		public static string GetIbatisSqlMapperFilePath(string databaseName)
        {
            var sqlMapperCnfgInfo = FrameworkCnfgInfoReader.GetIbatisSqlMapperInfo(databaseName);
            if (sqlMapperCnfgInfo != null)
            {
                return sqlMapperCnfgInfo.IbatisCnfgFilePath;
            }

            string fileName = @"Resources\Customize\" + databaseName + "SqlMapper.Config";
            if (File.Exists(fileName))
                return fileName;
            return null;
        }
    }
}

