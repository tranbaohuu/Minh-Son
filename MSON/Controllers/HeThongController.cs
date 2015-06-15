using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MSON.Models;
using PagedList;

namespace MSON.Controllers
{
    public class HeThongController : Controller
    {

        private minhsondbEntities ett = new minhsondbEntities();

        // GET: HeThong

        public ActionResult Index(int page = 1)
        {
            //if (Session["tendangnhap"] != null)
            //{
            //    var model = ett.sanphams.Select(s => s).OrderByDescending(o => o.ID).ToPagedList(page, 10);


            //    return View(model);
            //}
            //else
            //{
            //    return RedirectToAction("LoginCustomize", "HeThong");

            //}


            if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {


                //string username = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                var model = ett.sanphams.Select(s => s).OrderByDescending(o => o.ID).ToPagedList(page, 10);


                return View(model);
            }
            else
            {
                return RedirectToAction("LoginCustomize", "HeThong");

            }
        }



        public ActionResult Create_SanPham()
        {
            if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {

                //var model = ett.sanphams.Single(s => s.ID == id);


                //truyền dữ liệu vào dropdownlist tên DS_LOAIHANG trong view Edit_SanPham
                ViewBag.ID_LOAIHANG = new SelectList(ett.loaihangs, "ID", "TENLOAI");


                return View();

            }
            else
            {
                return RedirectToAction("LoginCustomize", "HeThong");

            }
        }

        [HttpPost]
        public ActionResult Create_SanPham(sanpham sp, HttpPostedFileBase IMG_URL)
        {

            sp.IMG_URL = "IMG_" + sp.ID + "_" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" +
                               DateTime.Now.Year + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" +
                               DateTime.Now.Second + ".jpg";

            if (ModelState.IsValid)
            {
                ett.Entry(sp).State = EntityState.Added;
                ett.SaveChanges();
                UpFile(IMG_URL, sp.IMG_URL);

                return RedirectToAction("Index");
            }

            return View(sp);

        }



        public ActionResult Edit_SanPham(int id)
        {
            if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {

                string path = HttpContext.Server.MapPath("~/IMAGES/");
                var listURLHinh = Directory
                .EnumerateFiles(path, "*", SearchOption.AllDirectories)
                .Select(Path.GetFileName);


                @ViewBag.listURLHinh = listURLHinh;


                var model = ett.sanphams.Single(s => s.ID == id);


                //truyền dữ liệu vào dropdownlist tên DS_LOAIHANG trong view Edit_SanPham
                ViewBag.ID_LOAIHANG = new SelectList(ett.loaihangs, "ID", "TENLOAI", model.ID_LOAIHANG);


                return View(model);
            }
            else
            {
                return RedirectToAction("LoginCustomize", "HeThong");

            }

        }



        [HttpPost]
        public ActionResult Edit_SanPham(sanpham sp, HttpPostedFileBase IMG_URL)
        {

            if (IMG_URL != null)
            {
                sp.IMG_URL = "IMG_" + sp.ID + "_" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" +
                             DateTime.Now.Year + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" +
                             DateTime.Now.Second + ".jpg";


                if (ModelState.IsValid)
                {
                    ett.Entry(sp).State = EntityState.Modified;
                    ett.SaveChanges();
                    UpFile(IMG_URL, sp.IMG_URL);
                    return RedirectToAction("Index");
                }
            }
            else
            {

                if (ModelState.IsValid)
                {
                    ett.Entry(sp).State = EntityState.Modified;
                    ett.SaveChanges();
                    return RedirectToAction("Index");
                }
            }





            return View(sp);


        }


        public ActionResult LoginCustomize()
        {


            return View();

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginCustomize(nguoidung nd)
        {


            if (nd != null)
            {

                var query = ett.nguoidungs.Where(w => w.tendangnhap == nd.tendangnhap && w.matkhau == nd.matkhau).FirstOrDefault();

                if (query != null)
                {

                    //set true ispersitent mới set timeout cho cookie dc
                    FormsAuthentication.SetAuthCookie(query.tendangnhap, true);


                    //FormsAuthentication.RedirectFromLoginPage(query.tendangnhap, false);


                    //Session["tendangnhap"] = query.tendangnhap;
                    //Session["matkhau"] = query.matkhau;

                    return RedirectToAction("Index", "HeThong");


                }


            }


            return View();


        }




        public ActionResult RegisterCustomize()
        {
            if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {

                string username = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;


                if (username.Equals("admin"))
                {

                    return View();
                }
            }

            return RedirectToAction("LoginCustomize");
        }



        [HttpPost]
        public ActionResult RegisterCustomize(nguoidung nd)
        {


            if (ModelState.IsValid)
            {
                nd.ngaynhap = DateTime.Now;
                ett.Entry(nd).State = EntityState.Added;
                ett.SaveChanges();
                return RedirectToAction("RegisterCustomize");
            }


            return View();


        }


        public ActionResult Delete_SanPham(int id)
        {
            if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {

                var model = ett.sanphams.Single(s => s.ID == id);


                //truyền dữ liệu vào dropdownlist tên DS_LOAIHANG trong view Edit_SanPham
                //ViewBag.ID_LOAIHANG = new SelectList(ett.loaihangs, "ID", "TENLOAI", model.ID_LOAIHANG);


                return View(model);

            }
            else
            {
                return RedirectToAction("LoginCustomize", "HeThong");

            }

        }

        [HttpPost]
        public ActionResult Delete_SanPham(sanpham sp)
        {


            if (ModelState.IsValid)
            {
                ett.Entry(sp).State = EntityState.Deleted;
                ett.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sp);


        }



        public ActionResult Detail_SanPham(int id)
        {

            var model = ett.sanphams.Single(s => s.ID == id);

            //truyền dữ liệu vào dropdownlist tên DS_LOAIHANG trong view Edit_SanPham
            ViewBag.ID_LOAIHANG = new SelectList(ett.loaihangs, "ID", "TENLOAI", model.ID_LOAIHANG);


            return View(model);



        }

        public ActionResult DangXuat()
        {
            //Session["tendangnhap"] = null;
            //Session["matkhau"] = null;

            FormsAuthentication.SignOut();


            // after successfully uploading redirect the user
            return RedirectToAction("LoginCustomize", "HeThong");
        }




        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/IMAGES/"), pic);
                // file is uploaded
                file.SaveAs(path);

                // save the image path path to the database or you can send image
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }

            }
            // after successfully uploading redirect the user
            return RedirectToAction("Create_SanPham", "HeThong");
        }



        public ActionResult UploadFile()
        {


            // after successfully uploading redirect the user
            return View();
        }


        public void UpFile(HttpPostedFileBase file, string fileName)
        {
            if (file != null)
            {
                //string pic = System.IO.Path.GetFileName(file.FileName);
                //string path = System.IO.Path.Combine(
                //                       Server.MapPath(Directory.GetCurrentDirectory() + "~/IMAGES/"), fileName);

                string path = HttpContext.Server.MapPath("~/IMAGES/" + fileName);

                // file is uploaded
                file.SaveAs(path);

                // save the image path path to the database or you can send image
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }

            }
        }


        public void Demo()
        {



        }
    }
}