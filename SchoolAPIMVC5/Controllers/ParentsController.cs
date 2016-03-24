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
    public class ParentsController : ApiController
    {
        private SchoolManagementDBEntities db = new SchoolManagementDBEntities();

        // GET: api/Parents
        public IQueryable<Parent> GetParents()
        {
            return db.Parents;
        }

        // GET: api/Parents/5
        [ResponseType(typeof(Parent))]
        public IHttpActionResult GetParent(int id)
        {
            Parent parent = db.Parents.Find(id);
            if (parent == null)
            {
                return NotFound();
            }

            return Ok(parent);
        }

        // PUT: api/Parents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutParent(int id, Parent parent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != parent.ParentID)
            {
                return BadRequest();
            }

            db.Entry(parent).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParentExists(id))
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

        // POST: api/Parents
        [ResponseType(typeof(Parent))]
        public IHttpActionResult PostParent(Parent parent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Parents.Add(parent);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = parent.ParentID }, parent);
        }

        // DELETE: api/Parents/5
        [ResponseType(typeof(Parent))]
        public IHttpActionResult DeleteParent(int id)
        {
            Parent parent = db.Parents.Find(id);
            if (parent == null)
            {
                return NotFound();
            }

            db.Parents.Remove(parent);
            db.SaveChanges();

            return Ok(parent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParentExists(int id)
        {
            return db.Parents.Count(e => e.ParentID == id) > 0;
        }
    }
}