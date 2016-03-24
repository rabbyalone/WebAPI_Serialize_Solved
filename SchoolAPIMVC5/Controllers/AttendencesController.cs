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
    public class AttendencesController : ApiController
    {
        private SchoolManagementDBEntities db = new SchoolManagementDBEntities();

        // GET: api/Attendences
        public IQueryable<Attendence> GetAttendences()
        {
            return db.Attendences;
        }

        // GET: api/Attendences/5
        [ResponseType(typeof(Attendence))]
        public IHttpActionResult GetAttendence(int id)
        {
            Attendence attendence = db.Attendences.Find(id);
            if (attendence == null)
            {
                return NotFound();
            }

            return Ok(attendence);
        }

        // PUT: api/Attendences/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAttendence(int id, Attendence attendence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != attendence.AttID)
            {
                return BadRequest();
            }

            db.Entry(attendence).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendenceExists(id))
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

        // POST: api/Attendences
        [ResponseType(typeof(Attendence))]
        public IHttpActionResult PostAttendence(Attendence attendence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Attendences.Add(attendence);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = attendence.AttID }, attendence);
        }

        // DELETE: api/Attendences/5
        [ResponseType(typeof(Attendence))]
        public IHttpActionResult DeleteAttendence(int id)
        {
            Attendence attendence = db.Attendences.Find(id);
            if (attendence == null)
            {
                return NotFound();
            }

            db.Attendences.Remove(attendence);
            db.SaveChanges();

            return Ok(attendence);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AttendenceExists(int id)
        {
            return db.Attendences.Count(e => e.AttID == id) > 0;
        }
    }
}