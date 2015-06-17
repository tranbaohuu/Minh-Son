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
    public class loaihangsController : ApiController
    {
        private minhsondbEntities db = new minhsondbEntities();

        // GET: api/loaihangs
        public IQueryable<loaihang> Getloaihangs()
        {
            return db.loaihangs;
        }

        // GET: api/loaihangs/5
        [ResponseType(typeof(loaihang))]
        public IHttpActionResult Getloaihang(int id)
        {
            loaihang loaihang = db.loaihangs.Find(id);
            if (loaihang == null)
            {
                return NotFound();
            }

            return Ok(loaihang);
        }

        // PUT: api/loaihangs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putloaihang(int id, loaihang loaihang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != loaihang.ID)
            {
                return BadRequest();
            }

            db.Entry(loaihang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!loaihangExists(id))
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

        // POST: api/loaihangs
        [ResponseType(typeof(loaihang))]
        public IHttpActionResult Postloaihang(loaihang loaihang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.loaihangs.Add(loaihang);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = loaihang.ID }, loaihang);
        }

        // DELETE: api/loaihangs/5
        [ResponseType(typeof(loaihang))]
        public IHttpActionResult Deleteloaihang(int id)
        {
            loaihang loaihang = db.loaihangs.Find(id);
            if (loaihang == null)
            {
                return NotFound();
            }

            db.loaihangs.Remove(loaihang);
            db.SaveChanges();

            return Ok(loaihang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool loaihangExists(int id)
        {
            return db.loaihangs.Count(e => e.ID == id) > 0;
        }
    }
}