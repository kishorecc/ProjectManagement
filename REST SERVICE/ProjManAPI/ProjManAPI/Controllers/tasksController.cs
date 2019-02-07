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
using ProjManAPI;
using System.Web.Http.Cors;

namespace ProjManAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class tasksController : ApiController
    {
        private MSBI_NBREQSEntities1 db = new MSBI_NBREQSEntities1();

        // GET: api/tasks
        public IQueryable<task> Gettasks()
        {
            return db.tasks;
        }

        // GET: api/tasks/5
        [ResponseType(typeof(task))]
        public IHttpActionResult Gettask(int id)
        {
            task task = db.tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        // PUT: api/tasks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttask( task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            

            db.Entry(task).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/tasks
        [ResponseType(typeof(task))]
        public IHttpActionResult Posttask(task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tasks.Add(task);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = task.task_id }, task);
        }

        // DELETE: api/tasks/5
        [ResponseType(typeof(task))]
        public IHttpActionResult Deletetask(int id)
        {
            task task = db.tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            db.tasks.Remove(task);
            db.SaveChanges();

            return Ok(task);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool taskExists(int id)
        {
            return db.tasks.Count(e => e.task_id == id) > 0;
        }
    }
}