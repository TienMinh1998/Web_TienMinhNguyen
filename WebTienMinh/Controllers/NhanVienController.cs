using MTDataConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTienMinh.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ThemMoiNhanVien()
        {
            return View();
        }

        [HttpPost]
        public bool AddNewNhanVien()
        {
            string tennhanvien = Request["txtten"];
            string diachi = Request["txtdiachi"];
            string quequan = Request["txtquequan"];
            string chitietquequan = Request["txtchitietquequan"];
            string chucvu = Request["txtchucvu"];
            int danhgia = int.Parse(Request["txtdanhgia"]);

            MTDbConnection db = new MTDbConnection();
            bool isAddNewSuccess;
            isAddNewSuccess = db.addNewNhanVien(tennhanvien, diachi, quequan, chitietquequan, chucvu, danhgia);
            if (isAddNewSuccess)
            {
                return true;
                
            }
            return false;
           
        }
        /// <summary>
        ///Hiển Thị tất cả nhân viên
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string getAllNhanVien()
        {
            MTDbConnection db = new MTDbConnection();
            string dsNV;
            dsNV = db.getAllNhanVien();
            return dsNV;
        }
        [HttpPost]
        public string demSoBanGhi()
        {
            MTDbConnection db = new MTDbConnection();
            int sobanghi = 0;
            sobanghi = db.demSoBanGhi("minhtien.tblnhanvien");
            return sobanghi.ToString();
           
        }


    }
}