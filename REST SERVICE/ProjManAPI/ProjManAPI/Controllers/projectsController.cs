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
    public class projectsController : ApiController
    {
        private MSBI_NBREQSEntities1 db = new MSBI_NBREQSEntities1();

        // GET: api/projects
        public IQueryable<project> Getprojects()
        {
            return db.projects;
        }

        // GET: api/projects/5
        [ResponseType(typeof(project))]
        public IHttpActionResult Getproject(int id)
        {
            project project = db.projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        // PUT: api/projects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putproject( project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            

            db.Entry(project).State = EntityState.Modified;

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

        // POST: api/projects
        [ResponseType(typeof(project))]
        public IHttpActionResult Postproject(project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.projects.Add(project);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = project.project_id }, project);
        }

        // DELETE: api/projects/5
        [ResponseType(typeof(project))]
        public IHttpActionResult Deleteproject(int id)
        {
            project project = db.projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            db.projects.Remove(project);
            db.SaveChanges();

            return Ok(project);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool projectExists(int id)
        {
            return db.projects.Count(e => e.project_id == id) > 0;
        }
    }
}