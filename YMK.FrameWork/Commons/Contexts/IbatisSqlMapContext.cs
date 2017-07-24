using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Runtime.Remoting.Messaging;
using Spring.Context.Support;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using com.en.users.Common.Contexts.Utils;
using YMK.FrameWork.Commons.Utils.ExceptionHandler;

namespace YMK.FrameWork.Commons.Contexts
{
    public class IbatisSqlMapContext:System.Web.UI.Page
    {
        static IbatisSqlMapContext _context;

        public ISqlMapper GetSqlMapper()
        {

            var mapper = (ISqlMapper)CallContext.GetData("MAPPER");
            if (mapper == null)
            {
                var appContext = new XmlApplicationContext(@"Resources\SpringNet.config");
                mapper = (ISqlMapper)appContext.GetObject("ProjectSqlMapper");
                CallContext.SetData("MAPPER", mapper);
            }
            else
                mapper = (ISqlMapper)CallContext.GetData("MAPPER");
            return mapper;
        }

        public ISqlMapper GetSqlMapper(string databaseName)
        {
            var mapper = (ISqlMapper)CallContext.GetData(databaseName);
            if (mapper == null)
            {
                string ibatisSqlMapperCnfgFileName = FrameworkConfigInfo.GetIbatisSqlMapperFilePath(databaseName);
                if (String.IsNullOrEmpty(ibatisSqlMapperCnfgFileName))
                    throw new YmkException("There is no configuration section of database: " + databaseName);
                if(System.Web.HttpRuntime.AppDomainAppId!=null)
                    ibatisSqlMapperCnfgFileName = Server.MapPath(ibatisSqlMapperCnfgFileName);

                //Read Original XML data and parser DTD
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.DtdProcessing = DtdProcessing.Parse;
                XmlReader reader = XmlTextReader.Create(ibatisSqlMapperCnfgFileName, settings);
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);
                reader.Close();

                
                //Load XML data again with DTD prohibit
                var stream=new System.IO.StringReader(doc.InnerXml);
                settings.DtdProcessing = DtdProcessing.Ignore;                
                reader = XmlReader.Create(stream, settings);
                doc.Load(reader);
                reader.Close();
                stream.Close();

                DomSqlMapBuilder builder = new DomSqlMapBuilder();
                mapper = builder.Build(doc, false);
                CallContext.SetData(databaseName, mapper);
                //CallContext.SetData("dreamdb", mapper);
            }
            else
                mapper = (ISqlMapper)CallContext.GetData(databaseName);
            return mapper;
        }

        public ISqlMapper GetProjectsSqlMapper()
        {
            return GetSqlMapper("projects");
        }

        //public ISqlMapper GetBasicSqlMapper()
        //{

        //    var mapper = (ISqlMapper)CallContext.GetData("BASICMAPPER");
        //    if (mapper == null)
        //    {
        //        DomSqlMapBuilder builder = new DomSqlMapBuilder();
        //        XmlDocument doc = new XmlDocument();
        //        doc.Load(@"Resources\DatabaseSchemaSqlMapper.Config");
        //        mapper = builder.Build(doc, false);
        //        CallContext.SetData("BASICMAPPER", mapper);
        //    }
        //    else
        //        mapper = (ISqlMapper)CallContext.GetData("BASICMAPPER");
        //    return mapper;

        //}

        public static IbatisSqlMapContext Context
        {
            get
            {
                if (_context == null)
                    _context = new IbatisSqlMapContext();
                return _context;
            }
        }
    }
}

