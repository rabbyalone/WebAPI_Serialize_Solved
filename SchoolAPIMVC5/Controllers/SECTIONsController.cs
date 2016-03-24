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
using SchoolAPIMVC5.Models;

namespace SchoolAPIMVC5.Controllers
{
    public class SECTIONsController : ApiController
    {
        private SchoolManagementDBEntities db = new SchoolManagementDBEntities();

        // GET: api/SECTIONs
        public IQueryable<SECTION> GetSECTIONs()
        {
            return db.SECTIONs;
        }

        // GET: api/SECTIONs/5
        [ResponseType(typeof(SECTION))]
        public IHttpActionResult GetSECTION(int id)
        {
            SECTION sECTION = db.SECTIONs.Find(id);
            if (sECTION == null)
            {
                return NotFound();
            }

            return Ok(sECTION);
        }

        // PUT: api/SECTIONs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSECTION(int id, SECTION sECTION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sECTION.SectionID)
            {
                return BadRequest();
            }

            db.Entry(sECTION).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SECTIONExists(id))
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

        // POST: api/SECTIONs
        [ResponseType(typeof(SECTION))]
        public IHttpActionResult PostSECTION(SECTION sECTION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SECTIONs.Add(sECTION);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sECTION.SectionID }, sECTION);
        }

        // DELETE: api/SECTIONs/5
        [ResponseType(typeof(SECTION))]
        public IHttpActionResult DeleteSECTION(int id)
        {
            SECTION sECTION = db.SECTIONs.Find(id);
            if (sECTION == null)
            {
                return NotFound();
            }

            db.SECTIONs.Remove(sECTION);
            db.SaveChanges();

            return Ok(sECTION);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SECTIONExists(int id)
        {
            return db.SECTIONs.Count(e => e.SectionID == id) > 0;
        }
    }
}