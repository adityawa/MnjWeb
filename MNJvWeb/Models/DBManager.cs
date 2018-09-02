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

        public T FindByID<T>(string _sql) where T : class, new()
        {
            T obj = new T();
            using (var con = oraCon)
            {
                try
                {
                    obj = con.QueryFirstOrDefault<T>(_sql);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
               
            }
            return obj;
        }

        public List<T> GetDataByDapper<T>(string sSql) where T : class,new()
        {
            List<T> list = new List<T>();

            using (var con = oraCon)
            {
                list = con.Query<T>(sSql).ToList();
            }

            return list;
        }

        public int Update(string sSql)
        {
            int returnAffected = 0;
            try
            {
                using (var con = oraCon)
                {
                    returnAffected = con.Execute(sSql);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return returnAffected;
        }

        public int Add(string sSql) 
        {
            int returnAffected = 0;
            try
            {
                using (var con = oraCon)
                {
                    returnAffected = con.Execute(sSql);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return returnAffected;
        }

        public int Delete(string sSql)
        {
            int returnAffected = 0;
            try
            {
                using (var con = oraCon)
                {
                    returnAffected = con.Execute(sSql);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return returnAffected;
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