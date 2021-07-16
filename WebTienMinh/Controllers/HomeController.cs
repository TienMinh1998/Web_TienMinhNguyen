using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MTDataConnection;
using DataConnection;
using Newtonsoft.Json;

namespace WebTienMinh.Controllers
{
    public class HomeController : Controller
    {
    

        public ActionResult Index()
        {
            if (Session["User"]==null)
            {
                return View("../Login/Index");
            }
            return View();
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public string getUserByID()
        {
            // lấy ra thông tin sinh viên vừa đăng nhập
            return JsonConvert.SerializeObject(BienDungChung.sinhviendangnhap);
        }

        [HttpPost]
        public void DangXuat()
        {
            BienDungChung._id = 0;
            
        }
    }
}