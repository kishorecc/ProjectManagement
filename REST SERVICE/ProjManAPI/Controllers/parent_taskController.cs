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
    public class parent_taskController : ApiController
    {
        
        public MSBI_NBREQSEntities1 db;


        public parent_taskController()
        {
            db = new MSBI_NBREQSEntities1();
        }
        public parent_taskController(MSBI_NBREQSEntities1 _db)
        {
            db = _db;
        }

        // GET: api/parent_task
        public IQueryable<parent_task> Getparent_task()
        {
            return db.parent_task;
        }

        // GET: api/parent_task/5
        [ResponseType(typeof(parent_task))]
        public IHttpActionResult Getparent_task(int id)
        {
            parent_task parent_task = db.parent_task.Find(id);
            if (parent_task == null)
            {
                return NotFound();
            }

            return Ok(parent_task);
        }

        // PUT: api/parent_task/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putparent_task( parent_task parent_task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            

            db.Entry(parent_task).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                
                    throw;
                
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/parent_task
        [ResponseType(typeof(parent_task))]
        public IHttpActionResult Postparent_task(parent_task parent_task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.parent_task.Add(parent_task);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = parent_task.parent_id }, parent_task);
        }

        // DELETE: api/parent_task/5
        [ResponseType(typeof(parent_task))]
        public IHttpActionResult Deleteparent_task(int id)
        {
            parent_task parent_task = db.parent_task.Find(id);
            if (parent_task == null)
            {
                return NotFound();
            }

            db.parent_task.Remove(parent_task);
            db.SaveChanges();

            return Ok(parent_task);
        }

        
    }
}