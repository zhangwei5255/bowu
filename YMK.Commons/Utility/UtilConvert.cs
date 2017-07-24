using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data;

namespace YMK.Commons.Utility
{
    public class UtilConvert
    {
        public static IList<TView> CopyProperties<TEntity, TView>(IList<TEntity> lstEntity, IList<TView> lstView) where TEntity : class
        {
            foreach (var item in lstEntity)
            {
                TView v = (TView)Activator.CreateInstance(typeof(TView));

                v = CopyProperties<TEntity, TView>(item, v);
                lstView.Add(v);

            }

            return lstView;

        }

        public static TView CopyProperties<TEntity, TView>(TEntity e, TView v) where TEntity : class
        {
            //***** インスタンスの作成 *****
            //ConstructorInfo ci = t.GetConstructor(Type.EmptyTypes);

            PropertyInfo[] desProInfos = typeof(TView).GetProperties();
            PropertyInfo[] srcProInfos = typeof(TEntity).GetProperties();

            foreach (PropertyInfo desProInfo in desProInfos)
            {
                //srcProInfos.PropertyType 
                foreach (PropertyInfo srcProInfo in srcProInfos)
                {
                    if (srcProInfo.PropertyType == desProInfo.PropertyType &&
                       srcProInfo.Name == desProInfo.Name)
                    {
                        //object target = ci.Invoke(new string[] { "" });
                        desProInfo.SetValue(v, srcProInfo.GetValue(e));
                        break;
                    }
                }
            }

            return v;
        }




        /// <summary>
        /// Convierte un arraylist de objetos en un datatable a partir de las 'propiedades' del arraylist
        /// </summary>
        /// <param name="array">Arraylist de objetos</param>
        /// <returns>DataTable de salida</returns>
        public static System.Data.DataTable ArrayList2DataTable(ArrayList array)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            if (array.Count > 0)
            {
                object obj = array[0];
                //Convertir las propiedades del objeto en columnas del datarow
                foreach (PropertyInfo info in obj.GetType().GetProperties())
                {
                    dt.Columns.Add(info.Name, info.PropertyType);
                }
            }
            foreach (object obj in array)
            {
                DataRow dr = dt.NewRow();
                foreach (DataColumn col in dt.Columns)
                {
                    Type type = obj.GetType();

                    MemberInfo[] members = type.GetMember(col.ColumnName);

                    object valor;
                    if (members.Length != 0)
                    {
                        switch (members[0].MemberType)
                        {
                            case MemberTypes.Property:
                                //leer las propiedades del objeto
                                PropertyInfo prop = (PropertyInfo)members[0];
                                try
                                {
                                    valor = prop.GetValue(obj, new object[0]);
                                }
                                catch
                                {
                                    valor = prop.GetValue(obj, null);
                                }

                                break;
                            case MemberTypes.Field:
                                //leer los campos del objeto (no se usa 
                                //dado q hemos poblado el dt con las propiedades del arraylist)
                                FieldInfo field = (FieldInfo)members[0];
                                valor = field.GetValue(obj);
                                break;
                            default:
                                throw new NotImplementedException();
                        }
                        dr[col] = valor;
                    }
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

    }
}
