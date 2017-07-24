using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace YMK.FrameWork.Commons.Utils.Configuration
{
    public class ReadConfigInfoHelper
    {
        public static ConfigurationSectionNameInfo GetNameInfoOfConfigInfoConfiguration<G, T>()
            where G : ConfigurationSectionGroup
            where T : ConfigurationSection
        {
            System.Configuration.Configuration exeConfig = GetExecuteConfig();
            return GetNameInfoOfConfigInfoConfiguration<G, T>(exeConfig);
        }

        public static ConfigurationSectionNameInfo GetNameInfoOfConfigInfoConfiguration<G, T>(System.Configuration.Configuration exeConfig)
            where G : ConfigurationSectionGroup
            where T : ConfigurationSection
        {
            ConfigurationSectionNameInfo info = new ConfigurationSectionNameInfo();
            foreach (var item in exeConfig.SectionGroups)
            {
                if (item is G)
                {
                    var sectionGroup = (G)item;
                    info.ExistFlag = true;
                    info.GroupName = sectionGroup.Name;

                    foreach (var sectionItem in sectionGroup.Sections)
                    {
                        if (sectionItem is T)
                        {
                            info.SectionName = ((T)sectionItem).SectionInformation.Name;
                            break;
                        }
                    }
                    break;
                }
            }
            return info;
        }

		internal static System.Configuration.Configuration GetExecuteConfig()
        {
            if (System.Web.HttpRuntime.AppDomainAppId == null)
            {
                return ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            }
            else
            {
                return System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(@"~\Web.config");
            }
        }
    }


    public class ConfigurationSectionNameInfo
    {
        public ConfigurationSectionNameInfo()
        {
            ExistFlag = false;
        }
        public bool ExistFlag { get; set; }
        public string GroupName { get; set; }
        public string SectionName { get; set; }
    }

}
