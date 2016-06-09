using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSON.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSON.Controllers.Tests
{
    [TestClass()]
    public class NguoiDungControllerTests
    {
        [TestMethod()]
        public void SanPhamTest()
        {


            NguoiDungController nd = new NguoiDungController();




            Assert.IsNotNull(nd.SanPham(1, 1), "Co du lieu");
        }
    }
}