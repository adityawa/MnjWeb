using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MNJvWeb.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        //[Authorize]
        public ActionResult Index()
        {
            FileInfo sFile = new FileInfo(@"D:\NOCHECK.INI");
            bool fileExist = sFile.Exists;
            if (fileExist == true)
                {
                }
            else
            {
                if (Session["UserLogon"] == null)
                    return RedirectToAction("Login", "Account");

            }

            return View();

        }
	}
}