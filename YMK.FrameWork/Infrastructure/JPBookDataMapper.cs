using IBatisNet.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMK.FrameWork.Infrastructure.Contracts;

namespace YMK.FrameWork.Infrastructure
{

    public  class JPBookDataMapper<TEntity> : BaseDataMapper<TEntity> where TEntity : class
    {
        public override ISqlMapper Mapper
        {
            get
            {
                if (mapper == null)
                    //IBatisNet.DataMapper.Mapper.Instance()
                    mapper = new InfrastructureFactory().GetSqlMapper("jpbook");
                //mapper = new InfrastructureFactory().GetSqlMapper("dreamdb");
                return mapper;
            }
            set
            {
                mapper = value;
            }
        }
    }
}
