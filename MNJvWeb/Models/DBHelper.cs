using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
namespace MNJvWeb.Models
{
    public class DBHelper
    {
        public DataTable GetData(string tableName, string[] cols, string[] whereArgs, string[] whereVal)
        {
            DataTable dtbl = new DataTable();
            string strErrMsg = string.Empty;
            StringBuilder sbsSql = new StringBuilder();
            sbsSql.Append("SELECT ");

            if (cols == null || cols.Length == 0)
            {
                sbsSql.Append(" * ");
            }
            else
            {
                for (int i = 0; i < cols.Length; i++)
                {
                    if (i == 0)
                    {
                        sbsSql.Append(cols[i]);
                    }
                    else
                    {
                        sbsSql.Append(", " + cols[i]);
                    }
                }
            }


            sbsSql.Append(" from " + tableName);

            if (whereArgs != null && whereVal != null && whereArgs.Length == whereVal.Length)
            {
                sbsSql.Append(" Where ");

                for (int k = 0; k < whereArgs.Length; k++)
                {
                    if (k == 0)
                    {
                        sbsSql.Append(whereArgs[k] + " = '" + whereVal[k] + "'");
                    }
                    else
                    {
                        sbsSql.Append("AND " + whereArgs[k] + " = '" + whereVal[k] + "'");
                    }

                }
            }

            DBManager objDBMgr = new DBManager();
            dtbl = objDBMgr.GetData(sbsSql.ToString(), out strErrMsg);

            return dtbl;
        }

        public  string GetAutoNo(string tableName, string fieldName)
        {
            DataTable dtbl = new DataTable();
            int tempNo = 0;
            DBManager objDBMgr = new DBManager();
            string ssql = string.Format("SELECT MAX({0}) from {1}", fieldName, tableName);
            DBManager db = new DBManager();
            string errMsg = string.Empty;
            dtbl = db.GetData(ssql, out errMsg);
            if (dtbl.Rows.Count > 0)
                tempNo = dtbl.Rows[0][0] == null ? 0 : Convert.ToInt32(dtbl.Rows[0][0].ToString());
            return (tempNo + 1).ToString();
        }
    }
}