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
    public class MARKsController : ApiController
    {
        private SchoolManagementDBEntities db = new SchoolManagementDBEntities();

        // GET: api/MARKs
        public IQueryable<MARK> GetMARKS()
        {
            return db.MARKS;
        }

        // GET: api/MARKs/5
        [ResponseType(typeof(MARK))]
        public IHttpActionResult GetMARK(int id)
        {
            MARK mARK = db.MARKS.Find(id);
            if (mARK == null)
            {
                return NotFound();
            }

            return Ok(mARK);
        }

        // PUT: api/MARKs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMARK(int id, MARK mARK)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mARK.MarkID)
            {
                return BadRequest();
            }

            db.Entry(mARK).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MARKExists(id))
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

        // POST: api/MARKs
        [ResponseType(typeof(MARK))]
        public IHttpActionResult PostMARK(MARK mARK)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MARKS.Add(mARK);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mARK.MarkID }, mARK);
        }

        // DELETE: api/MARKs/5
        [ResponseType(typeof(MARK))]
        public IHttpActionResult DeleteMARK(int id)
        {
            MARK mARK = db.MARKS.Find(id);
            if (mARK == null)
            {
                return NotFound();
            }

            db.MARKS.Remove(mARK);
            db.SaveChanges();

            return Ok(mARK);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MARKExists(int id)
        {
            return db.MARKS.Count(e => e.MarkID == id) > 0;
        }
    }
}