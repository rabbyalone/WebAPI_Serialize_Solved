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
    public class tblClassesController : ApiController
    {
        private SchoolManagementDBEntities db = new SchoolManagementDBEntities();

        // GET: api/tblClasses
        public IQueryable<tblClass> GettblClasses()
        {
            return db.tblClasses;
        }

        // GET: api/tblClasses/5
        [ResponseType(typeof(tblClass))]
        public IHttpActionResult GettblClass(int id)
        {
            tblClass tblClass = db.tblClasses.Find(id);
            if (tblClass == null)
            {
                return NotFound();
            }

            return Ok(tblClass);
        }

        // PUT: api/tblClasses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblClass(int id, tblClass tblClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblClass.ClassID)
            {
                return BadRequest();
            }

            db.Entry(tblClass).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblClassExists(id))
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

        // POST: api/tblClasses
        [ResponseType(typeof(tblClass))]
        public IHttpActionResult PosttblClass(tblClass tblClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblClasses.Add(tblClass);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblClass.ClassID }, tblClass);
        }

        // DELETE: api/tblClasses/5
        [ResponseType(typeof(tblClass))]
        public IHttpActionResult DeletetblClass(int id)
        {
            tblClass tblClass = db.tblClasses.Find(id);
            if (tblClass == null)
            {
                return NotFound();
            }

            db.tblClasses.Remove(tblClass);
            db.SaveChanges();

            return Ok(tblClass);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblClassExists(int id)
        {
            return db.tblClasses.Count(e => e.ClassID == id) > 0;
        }
    }
}