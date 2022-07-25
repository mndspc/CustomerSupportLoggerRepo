using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
namespace CustomerSupportLogger.Controllers
{
    public class CustLogInfoController : Controller
    {
        // GET: CustLogInfo
        CustLogInfoDAL custLogInfoDAL = new CustLogInfoDAL();
        public ActionResult AddCustPage()
        {
            if (Session["userid"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToRoute(new
                {
                    controller= "UserInfo",
                    action= "LogInPage"
                });
            }
        }

        [HttpPost]
        public ActionResult AddCustPage(CustLogInfo custLogInfo)
        {
            custLogInfo.UserId = Convert.ToInt32(Session["userid"]);
           var result= custLogInfoDAL.SaveLog(custLogInfo);
            if(result)
            {
                ViewBag.Message = "Complaint is Registered Successfully";
                return View();
            }
            return View();
        }
    }
}