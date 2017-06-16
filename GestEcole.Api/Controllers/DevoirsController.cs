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
using GestEcole.Api;

namespace GestEcole.Api.Controllers
{
    public class DevoirsController : ApiController
    {
        private GestEcoleEntities db = new GestEcoleEntities();

        // GET: api/Devoirs
        public IQueryable<Devoir> GetDevoirs()
        {
            return db.Devoirs;
        }

        // GET: api/Devoirs/5
        [ResponseType(typeof(Devoir))]
        public IHttpActionResult GetDevoir(int id)
        {
            Devoir devoir = db.Devoirs.Find(id);
            if (devoir == null)
            {
                return NotFound();
            }

            return Ok(devoir);
        }

        // PUT: api/Devoirs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDevoir(int id, Devoir devoir)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != devoir.Id)
            {
                return BadRequest();
            }

            db.Entry(devoir).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DevoirExists(id))
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

        // POST: api/Devoirs
        [ResponseType(typeof(Devoir))]
        public IHttpActionResult PostDevoir(Devoir devoir)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Devoirs.Add(devoir);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = devoir.Id }, devoir);
        }

        // DELETE: api/Devoirs/5
        [ResponseType(typeof(Devoir))]
        public IHttpActionResult DeleteDevoir(int id)
        {
            Devoir devoir = db.Devoirs.Find(id);
            if (devoir == null)
            {
                return NotFound();
            }

            db.Devoirs.Remove(devoir);
            db.SaveChanges();

            return Ok(devoir);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DevoirExists(int id)
        {
            return db.Devoirs.Count(e => e.Id == id) > 0;
        }
    }
}