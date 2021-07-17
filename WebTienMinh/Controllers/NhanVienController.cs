using DataConnection.Model;
using MTDataConnection;
using Newtonsoft.Json;
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

        public ActionResult ChinhSuaNhanVien()
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

        [HttpPost]
        // Hàm chỉnh sửa nhân viên
        public string chinhsuanhanvien()
        {
            int id = int.Parse( Request["id_nv"]);
            string ten = Request["ten"];
            string diachi = Request["diachi"];
            string quequan = Request["quequan"];
            string chietietquequan = Request["chitietquequan"];
            string chuvu = Request["chucvu"];
            int danhgia = int.Parse(Request["danhgia"]);
           string gioitinh =Request["gioitinh"];
            MTDbConnection db = new MTDbConnection();
            db.UpdateNhanVien(id, ten, diachi, quequan, chietietquequan, chuvu, danhgia, gioitinh);

            return "Thành Công";
            //// Lấy về đối tượng đang được chỉnh sửa
            //int id = int.Parse(Request["txtId"]);
            //string tennhanvien = Request["txtten"];
            //string diachi = Request["txtdiachi"];
            //string quequan = Request["txtquequan"];
            //string chitietquequan = Request["txtchitietquequan"];
            //string chucvu = Request["txtchucvu"];
            //int danhgia = int.Parse(Request["txtdanhgia"]);
            //string gioitinh = Request["txtGioiTinh"];

            //MTDbConnection db = new MTDbConnection();
            //bool isAddNewSuccess;
            //isAddNewSuccess = db.UpdateNhanVien(id, tennhanvien, diachi, quequan, chitietquequan, chucvu, danhgia, gioitinh);
            //if (isAddNewSuccess)
            //{
            //    return "Thành Công";

            //}
            //return "Chỉnh sửa thất bại";

        }
        [HttpPost]
        public string get_info_student()
        {
            int id = int.Parse(Request["id_dm"]);
            NhanVien nv = new NhanVien();
            MTDbConnection db = new MTDbConnection();
            nv = db.get_Employee(id);
            return JsonConvert.SerializeObject(nv);
          
        }
    }
}