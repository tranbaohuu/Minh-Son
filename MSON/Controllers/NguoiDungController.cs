using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSON.Controllers
{
    public class NguoiDungController : Controller
    {

        private minhsondbEntities ett = new minhsondbEntities();
        // GET: NguoiDung
        public ActionResult Index()
        {


            var listLoaiHang = ett.loaihangs.Select(l => l).ToList();


            List<sanpham> dsSanPham = new List<sanpham>();

            foreach (var lh in listLoaiHang)
            {

                var dsSanPhamLayLen = ett.sanphams.Where(w => w.ID_LOAIHANG == lh.ID).Select(s => s).Take(4).ToList();

                dsSanPham.AddRange(dsSanPhamLayLen);


            }




            //var tuple = new Tuple<List<sanpham>, List<loaihang>>(ett.sanphams.Select(s => s).ToList(), ett.loaihangs.Select(s => s).ToList());
            var tuple = new Tuple<List<sanpham>, List<loaihang>>(dsSanPham, ett.loaihangs.Select(s => s).ToList());
            return View(tuple);



        }


        public ActionResult Detail_SanPham(int id)
        {

            var model = ett.sanphams.Single(s => s.ID == id);


            //truyền dữ liệu vào dropdownlist tên DS_LOAIHANG trong view Edit_SanPham
            ViewBag.ID_LOAIHANG = new SelectList(ett.loaihangs, "ID", "TENLOAI", model.ID_LOAIHANG);


            var tuple = new Tuple<sanpham, List<loaihang>>(model, ett.loaihangs.Select(s => s).ToList());


            return View(tuple);



        }



        public ActionResult SanPham(int id)
        {

            //var model = ett.sanphams.Where(w => w.ID_LOAIHANG == id).Select(s => s);




            var tuple = new Tuple<List<sanpham>, List<loaihang>>(ett.sanphams.Where(w => w.ID_LOAIHANG == id).Select(s => s).ToList(), ett.loaihangs.Select(s => s).ToList());
            return View(tuple);

        }


        public ActionResult VeChungToi()
        {

            //var model = ett.sanphams.Where(w => w.ID_LOAIHANG == id).Select(s => s);

            var tuple = new Tuple<List<sanpham>, List<loaihang>>(new List<sanpham>(), ett.loaihangs.Select(s => s).ToList());


            return View(tuple);

        }



    }
}