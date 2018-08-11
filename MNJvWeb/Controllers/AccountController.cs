using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using MNJvWeb.Models;
using System.Web.Security;
using System.Web.Mvc;
using System.IO;
namespace MNJvWeb.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Authenticate(FormCollection coll)
        {
            string userName = string.Empty;
            string password = string.Empty;
            string query1 = string.Empty;
            string query2 = string.Empty;
            string errmsg = string.Empty;
            //Wiyono Remove
            DBManager objdbmgr = new DBManager();
            if (coll != null)
            {
                userName = coll["txtusrName"];
                password = coll["txtPassword"];
                query1 = "SELECT   NVL(LOCKED,'N') LOCKED"
                            + " FROM     SPA99MT"
                            + " WHERE    UPPER(NAMA) = '" + userName + "'";

                query2 = "SELECT   EMP_NO, NAMA, KODE, NVL(hak,'N') hak"
                        + " FROM     SPA99MT"
                        + " WHERE    UPPER(NAMA) = '" + userName + "'"
                        + " AND UPPER(KODE) = '" + password + "'"
                        + " AND NVL(LOCKED,'N') = 'N'";
                //Wiyono Remove
                DataTable dtCekLocked = objdbmgr.GetData(query1, out errmsg);

                //Wiyono Remove
                //var dtCekLocked = new DataTable();
                //dtCekLocked.Columns.Add("LOCKED", typeof(string));
                //dtCekLocked.Rows.Add("N");

                if (dtCekLocked.Rows.Count > 0)
                {
                    if (dtCekLocked.Rows[0]["LOCKED"].ToString().Trim() == "N")
                    {
                        //Wiyono Remove
                        DataTable dtAuth = objdbmgr.GetData(query2, out errmsg);
                        //var dtAuth = new DataTable();
                        //dtAuth.Columns.Add("EMP_NO", typeof(string));
                        //dtAuth.Columns.Add("NAMA", typeof(string));
                        //dtAuth.Columns.Add("KODE", typeof(string));
                        //dtAuth.Columns.Add("HAK", typeof(string));
                        //dtAuth.Rows.Add("1000", "SYSTEM", "ADMIN", "Y");


                        if (dtAuth.Rows.Count <= 0)
                        {
                            errmsg = "User Id dan Password yang anda masukkan salah";
                            ViewBag.Error = errmsg;
                            return View("Login");
                        }
                        else
                        {
                            Session["UserLogOn"] = dtAuth;
                            FormsAuthentication.SetAuthCookie(dtAuth.Rows[0]["NAMA"].ToString(), true);
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        errmsg = "User ID Terkunci silahkan hubungi system admin anda";
                        ViewBag.Error = errmsg;
                        return View("Login");
                    }
                }
                else
                {
                    errmsg = "Error Query";
                    ViewBag.Error = errmsg;
                    return View("Login");
                }
            }
            else
            {
                errmsg = "Please Enter UserName and Password";
                ViewBag.Error = errmsg;
                return View("Login");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}