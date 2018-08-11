using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using Dapper;
using System.Reflection;
namespace MNJvWeb.Models
{
    public class DBManager
    {
        private OracleConnection oraCon;

        public DBManager()
        {
            try
            {
                oraCon = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MnJDbContext"].ConnectionString.ToString());
                if (oraCon.State == ConnectionState.Closed)
                    oraCon.Open();
            }
            catch (Exception ex)
            {
                //Wiyono Remove
                throw new Exception(ex.Message);
            }

        }

        public List<T> GetDataByDapper<T>(string sSql) where T : class,new()
        {
            List<T> list = new List<T>();

            using (var con = oraCon)
            {
               list = con.Query<T>(sSql).ToList();
                
                //foreach (var item in qry)
                //{
                //    T obj = new T();
                    
                //    foreach (var prop in obj.GetType().GetProperties())
                //    {
                //        try
                //        {
                //            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                //            propertyInfo.SetValue(obj, Convert.ChangeType(item, item.GetType()), null);
                //        }
                //        catch(Exception ex)
                //        {
                //            continue;
                //        }
                //    }

                //    list.Add(obj);
                //}
            }

            return list;
        }

        public DataTable GetData(string sSql, out string errorMsg)
        {
            DataTable dtResult = new DataTable();
            errorMsg = string.Empty;

            //Wiyono Remove
            if (oraCon.State == ConnectionState.Closed)
                oraCon.Open();
            using (OracleCommand cmd = new OracleCommand(sSql, oraCon))
            {
                try
                {
                    cmd.CommandType = CommandType.Text;
                    OracleDataAdapter adapt = new OracleDataAdapter(cmd);
                    adapt.Fill(dtResult);
                }
                catch (Exception ex)
                {
                    errorMsg = ex.Message;
                }

            }

            return dtResult;
        }


    }
}