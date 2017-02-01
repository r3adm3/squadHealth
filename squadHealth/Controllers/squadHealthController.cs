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
using squadHealth.Models;
using System.Configuration;

namespace squadHealth.Controllers
{
    public class squadHealthController : ApiController
    {
        private squadHealthEntities db = new squadHealthEntities();

        // GET: api/squadHealth
        public IQueryable<tbl_squadHealth> Gettbl_squadHealth()
        {
            return db.tbl_squadHealth;
        }

        // GET: api/squadHealth/5
        [ResponseType(typeof(tbl_squadHealth))]
        public IHttpActionResult Gettbl_squadHealth(int id)
        {
            tbl_squadHealth tbl_squadHealth = db.tbl_squadHealth.Find(id);
            if (tbl_squadHealth == null)
            {
                return NotFound();
            }

            return Ok(tbl_squadHealth);
        }

        // PUT: api/squadHealth/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_squadHealth(int id, tbl_squadHealth tbl_squadHealth)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_squadHealth.Id)
            {
                return BadRequest();
            }

            db.Entry(tbl_squadHealth).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_squadHealthExists(id))
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

        // POST: api/squadHealth
        [ResponseType(typeof(tbl_squadHealth))]
        public IHttpActionResult Posttbl_squadHealth(tbl_squadHealth tbl_squadHealth)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_squadHealth.Add(tbl_squadHealth);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_squadHealth.Id }, tbl_squadHealth);
        }

        // DELETE: api/squadHealth/5
        [ResponseType(typeof(tbl_squadHealth))]
        public IHttpActionResult Deletetbl_squadHealth(int id)
        {
            tbl_squadHealth tbl_squadHealth = db.tbl_squadHealth.Find(id);
            if (tbl_squadHealth == null)
            {
                return NotFound();
            }

            db.tbl_squadHealth.Remove(tbl_squadHealth);
            db.SaveChanges();

            return Ok(tbl_squadHealth);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_squadHealthExists(int id)
        {
            return db.tbl_squadHealth.Count(e => e.Id == id) > 0;
        }
    }
}