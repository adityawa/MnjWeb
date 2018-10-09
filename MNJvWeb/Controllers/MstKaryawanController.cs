using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MNJvWeb.Models;
using MNJvWeb.Models.EntityModel;
namespace MNJvWeb.Controllers
{
    public class MstKaryawanController : BaseController
    {
        //
        // GET: /MstKaryawan/
        public ActionResult Index()
        {
            return CheckSession();
        }
        public JsonResult AddNewEmployee()
        {
            string _status = "success";
            string _sSqlGetEmpNO = "SELECT NVL(MAX(emp_no),100000)+ 1 emp_no FROM spa03mt";
            SPTA03MTModel emp = new SPTA03MTModel();

            if (Request["EmpNo"] == "" || Request["EmpNo"] == null)
            {
                //new
                System.Data.DataTable dt_temp = new DBManager().GetData(_sSqlGetEmpNO, out _status);
                if (_status == "" || _status == "success")
                {
                    emp.EMP_NO = Int32.Parse( dt_temp.Rows[0][0].ToString());
                    emp.EMP_NM = Request["Name"].ToString();
                    emp.DEPT_CD = Request["Dept"].ToString();
                    emp.GRADE = Request["Grade"].ToString();
                    emp.ENTER_DT = Request["EnterDT"].ToString();
                    emp.BIRTH_DT = Request["BirthDT"].ToString();
                    emp.RESIGN_DT = Request["ResignDT"].ToString();
                    emp.STATUS = Request["Status"].ToString();
                    emp.RELIGION = Request["Religion"].ToString();
                    emp.WORK_TY = Request["WorkType"].ToString();

                    string _sSqlInsert = string.Format("INSERT INTO SPA03MT (EMP_NO, EMP_NM, DEPT_CD, GRADE, ENTER_DT, BIRTH_DT, RESIGN_DT, STATUS, RELIGION, WORK_TY, SEX, EDU_CD, HP, BERAT, TINGGI, KACAMATA, DARAH, KTP, ADDR, KOMISI, USED, PASSWORD, TELP) "
         + "VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}",
        emp.EMP_NO, emp.EMP_NM, emp.DEPT_CD, emp.GRADE, emp.ENTER_DT, emp.BIRTH_DT,
        emp.RESIGN_DT, emp.STATUS, emp.RELIGION, emp.WORK_TY, emp.SEX, emp.EDU_CD, emp.HP, emp.BERAT, emp.TINGGI, emp.KACAMATA, emp.DARAH, emp.KTP, emp.ADDR, emp.KOMISI, "Y", emp.PASSWORD, emp.TELP);
                    

                }


            }
            else
            {
                //update
            }



            return Json(new { Status = _status }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetEmployee()
        {
            string _status = "success";
            string sSql = "select"
                             + "  a.EMP_NO"
                             + " ,a.EMP_NM"
                             + " ,b.ITEM_NM AS DEPT_CD"
                             + " ,c.ITEM_NM AS GRADE"
                             + " ,a.ENTER_DT"
                             + " ,a.BIRTH_DT"
                             + " ,d.ITEM_NM AS STATUS"
                             + " ,a.RESIGN_DT"
                             + " ,e.ITEM_NM AS RELIGION"
                             + " ,f.ITEM_NM as WORK_TY"
                             + " ,a.HP"
                             + " ,a.TELP"
                             + " ,g.ITEM_NM as SEX"
                             + " ,h.ITEM_NM as EDU_CD"
                             + " ,a.BERAT"
                             + " ,a.TINGGI"
                             + " ,i.ITEM_NM as KACAMATA"
                             + " ,j.ITEM_NM as DARAH"
                             + " ,a.ADDR"
                             + " ,a.KTP"

                             + " from spa03mt a"
                             + " INNER JOIN spa01mt b"
                             + " on"
                             + " a.DEPT_CD =b.ITEM_CD AND b.GRP_CD = 'DEPARTEMEN'"
                             + " INNER JOIN spa01mt c"
                             + " on"
                             + " a.GRADE=c.ITEM_CD AND c.GRP_CD='GRADE'"
                             + " INNER JOIN spa01mt d"
                             + " on"
                             + " a.STATUS=d.ITEM_CD AND d.GRP_CD='STATUS'"
                             + " INNER JOIN spa01mt e"
                             + " ON"
                             + " a.Religion=e.ITEM_CD and e.GRP_CD='RELIGION'"
                             + " INNER JOIN spa01mt f"
                             + " on"
                             + " a.WORK_TY=f.ITEM_CD and f.GRP_CD='WORK TYPE'"
                             + " INNER JOIN spa01mt g"
                             + " ON"
                             + " a.SEX=g.ITEM_CD and g.GRP_CD='SEX'"
                             + " INNER JOIN spa01mt h"
                             + " on"
                             + " a.EDU_CD=h.ITEM_CD and h.GRP_CD='EDUCATION'"
                             + " INNER JOIN spa01mt i"
                             + " on"
                             + " a.KACAMATA = i.ITEM_CD and i.GRP_CD='KACA MATA'"
                             + " INNER JOIN spa01mt j"
                             + " on"
                             + " a.DARAH=j.ITEM_CD and j.GRP_CD='BLOOD TYPE'";

            List<SPTA03MTModel> ls = new List<SPTA03MTModel>();
            try
            {
                ls = new DBManager().GetDataByDapper<SPTA03MTModel>(sSql);
            }
            catch (Exception ex)
            {
                _status = ex.Message;
            }

            var JsonResult = Json(new { Data = ls, Status = _status }, JsonRequestBehavior.AllowGet);
            JsonResult.MaxJsonLength = Int32.MaxValue;
            return JsonResult;
        }
    }
}