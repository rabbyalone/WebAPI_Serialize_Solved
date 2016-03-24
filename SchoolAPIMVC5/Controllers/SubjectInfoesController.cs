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
    public class SubjectInfoesController : ApiController
    {
        private SchoolManagementDBEntities db = new SchoolManagementDBEntities();

        // GET: api/SubjectInfoes
        public IQueryable<SubjectInfo> GetSubjectInfoes()
        {
            return db.SubjectInfoes;
        }

        // GET: api/SubjectInfoes/5
        [ResponseType(typeof(SubjectInfo))]
        public IHttpActionResult GetSubjectInfo(int id)
        {
            SubjectInfo subjectInfo = db.SubjectInfoes.Find(id);
            if (subjectInfo == null)
            {
                return NotFound();
            }

            return Ok(subjectInfo);
        }

        // PUT: api/SubjectInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSubjectInfo(int id, SubjectInfo subjectInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subjectInfo.SubjectID)
            {
                return BadRequest();
            }

            db.Entry(subjectInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectInfoExists(id))
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

        // POST: api/SubjectInfoes
        [ResponseType(typeof(SubjectInfo))]
        public IHttpActionResult PostSubjectInfo(SubjectInfo subjectInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubjectInfoes.Add(subjectInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = subjectInfo.SubjectID }, subjectInfo);
        }

        // DELETE: api/SubjectInfoes/5
        [ResponseType(typeof(SubjectInfo))]
        public IHttpActionResult DeleteSubjectInfo(int id)
        {
            SubjectInfo subjectInfo = db.SubjectInfoes.Find(id);
            if (subjectInfo == null)
            {
                return NotFound();
            }

            db.SubjectInfoes.Remove(subjectInfo);
            db.SaveChanges();

            return Ok(subjectInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubjectInfoExists(int id)
        {
            return db.SubjectInfoes.Count(e => e.SubjectID == id) > 0;
        }
    }
}