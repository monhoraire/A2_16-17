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
    public class MatieresController : ApiController
    {
        private GestEcoleEntities db = new GestEcoleEntities();

        // GET: api/Matieres
        public IQueryable<Matiere> GetMatieres()
        {
            return db.Matieres;
        }

        // GET: api/Matieres/5
        [ResponseType(typeof(Matiere))]
        public IHttpActionResult GetMatiere(int id)
        {
            Matiere matiere = db.Matieres.Find(id);
            if (matiere == null)
            {
                return NotFound();
            }

            return Ok(matiere);
        }

        // PUT: api/Matieres/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMatiere(int id, Matiere matiere)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != matiere.Id)
            {
                return BadRequest();
            }

            db.Entry(matiere).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatiereExists(id))
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

        // POST: api/Matieres
        [ResponseType(typeof(Matiere))]
        public IHttpActionResult PostMatiere(Matiere matiere)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Matieres.Add(matiere);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = matiere.Id }, matiere);
        }

        // DELETE: api/Matieres/5
        [ResponseType(typeof(Matiere))]
        public IHttpActionResult DeleteMatiere(int id)
        {
            Matiere matiere = db.Matieres.Find(id);
            if (matiere == null)
            {
                return NotFound();
            }

            db.Matieres.Remove(matiere);
            db.SaveChanges();

            return Ok(matiere);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MatiereExists(int id)
        {
            return db.Matieres.Count(e => e.Id == id) > 0;
        }
    }
}