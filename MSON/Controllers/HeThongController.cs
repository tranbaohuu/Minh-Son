using System;
using System.Collections.Generic;
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


        public ActionResult SanPham()
        {
            return View();
        }


        public ActionResult LayDanhSach()
        {

            //var model = ett.sanphams.Select(s => s);


            var model = from sp in ett.sanphams

                        select new KieuCuaToiModels()
                        {
                            TenHang = sp.TEN,
                            NgayNhap = sp.NGAYNHAP ?? default(DateTime)


                        };



            return View(model.ToList());
        }

    }
}