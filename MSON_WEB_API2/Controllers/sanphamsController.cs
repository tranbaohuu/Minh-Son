using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MSON_WEB_API2;

namespace MSON_WEB_API2.Controllers
{
    public class sanphamsController : ApiController
    {
        private minhsondbEntities db = new minhsondbEntities();

        // GET: api/sanphams
        public IQueryable<sanpham> Getsanphams()
        {
            return db.sanphams;
        }

        // GET: api/sanphams/5
        [ResponseType(typeof(sanpham))]
        public IHttpActionResult Getsanpham(int id)
        {
            sanpham sanpham = db.sanphams.Find(id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return Ok(sanpham);
        }

        // PUT: api/sanphams/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putsanpham(int id, sanpham sanpham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sanpham.ID)
            {
                return BadRequest();
            }

            db.Entry(sanpham).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!sanphamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/sanphams
        [ResponseType(typeof(sanpham))]
        public IHttpActionResult Postsanpham(sanpham sanpham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.sanphams.Add(sanpham);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sanpham.ID }, sanpham);
        }

        // DELETE: api/sanphams/5
        [ResponseType(typeof(sanpham))]
        public IHttpActionResult Deletesanpham(int id)
        {
            sanpham sanpham = db.sanphams.Find(id);
            if (sanpham == null)
            {
                return NotFound();
            }

            db.sanphams.Remove(sanpham);
            db.SaveChanges();

            return Ok(sanpham);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool sanphamExists(int id)
        {
            return db.sanphams.Count(e => e.ID == id) > 0;
        }
    }
}