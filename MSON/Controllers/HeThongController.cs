using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MSON.Models;

namespace MSON.Controllers
{
    public class HeThongController : Controller
    {

        private minhsondbEntities ett = new minhsondbEntities();

        // GET: HeThong
        public ActionResult Index()
        {

            var model = ett.sanphams.Select(s => s);


            return View(model);
        }



        public ActionResult Create_SanPham()
        {

            //var model = ett.sanphams.Single(s => s.ID == id);


            //truyền dữ liệu vào dropdownlist tên DS_LOAIHANG trong view Edit_SanPham
            ViewBag.ID_LOAIHANG = new SelectList(ett.loaihangs, "ID", "TENLOAI");


            return View();

        }

        [HttpPost]
        public ActionResult Create_SanPham(sanpham sp)
        {

            if (ModelState.IsValid)
            {
                ett.Entry(sp).State = EntityState.Added;
                ett.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sp);

        }

        public ActionResult Edit_SanPham(int id)
        {

            var model = ett.sanphams.Single(s => s.ID == id);


            //truyền dữ liệu vào dropdownlist tên DS_LOAIHANG trong view Edit_SanPham
            ViewBag.ID_LOAIHANG = new SelectList(ett.loaihangs, "ID", "TENLOAI", model.ID_LOAIHANG);


            return View(model);

        }



        [HttpPost]
        public ActionResult Edit_SanPham(sanpham sp)
        {




            if (ModelState.IsValid)
            {
                ett.Entry(sp).State = EntityState.Modified;
                ett.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sp);


        }






        public ActionResult Delete_SanPham(int id)
        {


            var model = ett.sanphams.Single(s => s.ID == id);


            //truyền dữ liệu vào dropdownlist tên DS_LOAIHANG trong view Edit_SanPham
            //ViewBag.ID_LOAIHANG = new SelectList(ett.loaihangs, "ID", "TENLOAI", model.ID_LOAIHANG);


            return View(model);



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



        public ActionResult UploadFile(HttpPostedFileBase file)
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
            return View();
        }

    }
}