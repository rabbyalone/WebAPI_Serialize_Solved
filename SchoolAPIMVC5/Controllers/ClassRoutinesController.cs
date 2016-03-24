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
    public class ClassRoutinesController : ApiController
    {
        private SchoolManagementDBEntities db = new SchoolManagementDBEntities();

        // GET: api/ClassRoutines
        public IQueryable<ClassRoutine> GetClassRoutines()
        {
            return db.ClassRoutines;
        }

        // GET: api/ClassRoutines/5
        [ResponseType(typeof(ClassRoutine))]
        public IHttpActionResult GetClassRoutine(int id)
        {
            ClassRoutine classRoutine = db.ClassRoutines.Find(id);
            if (classRoutine == null)
            {
                return NotFound();
            }

            return Ok(classRoutine);
        }

        // PUT: api/ClassRoutines/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClassRoutine(int id, ClassRoutine classRoutine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != classRoutine.RoutineID)
            {
                return BadRequest();
            }

            db.Entry(classRoutine).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassRoutineExists(id))
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

        // POST: api/ClassRoutines
        [ResponseType(typeof(ClassRoutine))]
        public IHttpActionResult PostClassRoutine(ClassRoutine classRoutine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClassRoutines.Add(classRoutine);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = classRoutine.RoutineID }, classRoutine);
        }

        // DELETE: api/ClassRoutines/5
        [ResponseType(typeof(ClassRoutine))]
        public IHttpActionResult DeleteClassRoutine(int id)
        {
            ClassRoutine classRoutine = db.ClassRoutines.Find(id);
            if (classRoutine == null)
            {
                return NotFound();
            }

            db.ClassRoutines.Remove(classRoutine);
            db.SaveChanges();

            return Ok(classRoutine);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClassRoutineExists(int id)
        {
            return db.ClassRoutines.Count(e => e.RoutineID == id) > 0;
        }
    }
}