using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
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

    }
}