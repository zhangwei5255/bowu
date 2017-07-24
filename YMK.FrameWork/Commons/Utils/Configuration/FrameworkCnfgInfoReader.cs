using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Pirate.Configuration;

namespace YMK.FrameWork.Commons.Utils.Configuration
{
    public class FrameworkCnfgInfoReader
    {
        public static FrameworkCnfgSection GetFrameworkCnfgSection()
        {
            FrameworkCnfgSection configInfoSection = null;
            var nameInfo = ReadConfigInfoHelper.GetNameInfoOfConfigInfoConfiguration<FrameworkCnfgSectionGroup, FrameworkCnfgSection>();
            if (!nameInfo.ExistFlag)
            {
                return null;
            }
            if (nameInfo.ExistFlag)
            {
                System.Configuration.Configuration cnfg = ReadConfigInfoHelper.GetExecuteConfig();
                configInfoSection = (FrameworkCnfgSection)cnfg.GetSection(nameInfo.GroupName + "/" + nameInfo.SectionName);
            }

            return configInfoSection;
        }

        public static IbatisSqlMapperCnfg GetIbatisSqlMapperInfo(string databaseName)
        {
            var cnfgSection = GetFrameworkCnfgSection();
            if (cnfgSection == null)
                return null;
            return (IbatisSqlMapperCnfg)cnfgSection.IbatisSqlMappers[databaseName];
        }

        public static void GenerateIbatisSqlMapperCnfg(Dictionary<string,string> databaseInfoDic,string appConfigFileFullName)
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = appConfigFileFullName;
            System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            var existCheck=ReadConfigInfoHelper.GetNameInfoOfConfigInfoConfiguration<FrameworkCnfgSectionGroup,FrameworkCnfgSection>(config);
            if (!existCheck.ExistFlag)
            {
                FrameworkCnfgSectionGroup group = new FrameworkCnfgSectionGroup();
                FrameworkCnfgSection sec = new FrameworkCnfgSection();

                foreach (var key in databaseInfoDic.Keys)
                {
                    sec.IbatisSqlMappers.Add(new IbatisSqlMapperCnfg(key, databaseInfoDic[key]));
                }

                config.SectionGroups.Add("frameworkCnfgGroup", group);
                group.Sections.Add("frameworkCnfgSection", sec);
            }
            else
            {
                FrameworkCnfgSection sec = (FrameworkCnfgSection)config.GetSection(existCheck.GroupName + @"/" + existCheck.SectionName);
                sec.IbatisSqlMappers.Clear();

                foreach (var key in databaseInfoDic.Keys)
                {
                    sec.IbatisSqlMappers.Add(new IbatisSqlMapperCnfg(key, databaseInfoDic[key]));
                }
            }

            config.Save();

        }

    }
}

