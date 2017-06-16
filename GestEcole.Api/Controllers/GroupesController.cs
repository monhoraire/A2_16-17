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
    public class GroupesController : ApiController
    {
        private GestEcoleEntities db = new GestEcoleEntities();

        // GET: api/Groupes
        public IQueryable<Groupe> GetGroupes()
        {
            return db.Groupes;
        }

        // GET: api/Groupes/5
        [ResponseType(typeof(Groupe))]
        public IHttpActionResult GetGroupe(int id)
        {
            Groupe groupe = db.Groupes.Find(id);
            if (groupe == null)
            {
                return NotFound();
            }

            return Ok(groupe);
        }

        // PUT: api/Groupes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGroupe(int id, Groupe groupe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groupe.Id)
            {
                return BadRequest();
            }

            db.Entry(groupe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupeExists(id))
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

        // POST: api/Groupes
        [ResponseType(typeof(Groupe))]
        public IHttpActionResult PostGroupe(Groupe groupe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Groupes.Add(groupe);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = groupe.Id }, groupe);
        }

        // DELETE: api/Groupes/5
        [ResponseType(typeof(Groupe))]
        public IHttpActionResult DeleteGroupe(int id)
        {
            Groupe groupe = db.Groupes.Find(id);
            if (groupe == null)
            {
                return NotFound();
            }

            db.Groupes.Remove(groupe);
            db.SaveChanges();

            return Ok(groupe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GroupeExists(int id)
        {
            return db.Groupes.Count(e => e.Id == id) > 0;
        }
    }
}