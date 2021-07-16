using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;
using MTDataConnection;
using Newtonsoft.Json;

namespace WebTienMinh.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string getLogin()
        {
            string tk = Request["txttk"];
            string mk = Request["txtmk"];
           MTDbConnection db = new MTDbConnection();
            try
            {
                BienDungChung.sinhviendangnhap = db.getStudent(tk,mk);
                if (BienDungChung.sinhviendangnhap.id==0 || BienDungChung.sinhviendangnhap.id<0)
                {
                    return "sai Tên Tài khoản hoặc mật khẩu";
                }
                else
                {
                    Session["User"] = tk;
                }
               
                return JsonConvert.SerializeObject(BienDungChung.sinhviendangnhap);
            }
            catch (Exception)
            {
                
                throw;
            }
                          
        }
    }
}