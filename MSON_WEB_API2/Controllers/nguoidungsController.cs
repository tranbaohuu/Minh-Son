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
    public class nguoidungsController : ApiController
    {
        private minhsondbEntities db = new minhsondbEntities();

        // GET: api/nguoidungs
        public IQueryable<nguoidung> Getnguoidungs()
        {
            return db.nguoidungs;
        }

        // GET: api/nguoidungs/5
        [ResponseType(typeof(nguoidung))]
        public IHttpActionResult Getnguoidung(string id)
        {
            nguoidung nguoidung = db.nguoidungs.Find(id);
            if (nguoidung == null)
            {
                return NotFound();
            }

            return Ok(nguoidung);
        }

        // PUT: api/nguoidungs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putnguoidung(string id, nguoidung nguoidung)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nguoidung.tendangnhap)
            {
                return BadRequest();
            }

            db.Entry(nguoidung).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!nguoidungExists(id))
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

        // POST: api/nguoidungs
        [ResponseType(typeof(nguoidung))]
        public IHttpActionResult Postnguoidung(nguoidung nguoidung)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.nguoidungs.Add(nguoidung);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (nguoidungExists(nguoidung.tendangnhap))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = nguoidung.tendangnhap }, nguoidung);
        }

        // DELETE: api/nguoidungs/5
        [ResponseType(typeof(nguoidung))]
        public IHttpActionResult Deletenguoidung(string id)
        {
            nguoidung nguoidung = db.nguoidungs.Find(id);
            if (nguoidung == null)
            {
                return NotFound();
            }

            db.nguoidungs.Remove(nguoidung);
            db.SaveChanges();

            return Ok(nguoidung);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool nguoidungExists(string id)
        {
            return db.nguoidungs.Count(e => e.tendangnhap == id) > 0;
        }
    }
}