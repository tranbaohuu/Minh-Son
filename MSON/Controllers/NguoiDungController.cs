using System;
using System.Collections.Generic;
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

            var model = ett.sanphams.Select(s => s);


            return View(model);
        }




    }
}