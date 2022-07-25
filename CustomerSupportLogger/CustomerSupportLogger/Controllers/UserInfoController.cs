using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
namespace CustomerSupportLogger.Controllers
{
    public class UserInfoController : Controller
    {
        UserInfoDAL userInfoDAL=new UserInfoDAL();
        // GET: UserInfo
        public ActionResult LogInPage()
        {
            return View();
        }

        [HttpPost]
       public ActionResult LogInPage(UserInfo userInfo)
        {
           var result= userInfoDAL.ValidateUser(userInfo);
            if (result)
            {
                Session["userid"] = userInfo.UserId;
                return RedirectToRoute(new
                {
                    controller="CustLogInfo",
                    action="AddCustPage"
                });
            }
            else
            {

                @ViewBag.Message = "Incorrect UserId or Password";
                return View();
            }
        }
    }
}