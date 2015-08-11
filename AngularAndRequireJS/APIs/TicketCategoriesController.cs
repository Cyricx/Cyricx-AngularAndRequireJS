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
using AngularAndRequireJS.DAL;
using AngularAndRequireJS.Models;
using AngularAndRequireJS.JsonModels;

namespace AngularAndRequireJS.APIs
{
    public class TicketCategoriesController : ApiController
    {
        private MyContext db = new MyContext();

        // GET: api/TicketCategories
        public IQueryable<TicketCategoryJsonModel> GetTicketCategories()
        {
            var ticketCategories = from t in db.TicketCategories
                                   select new TicketCategoryJsonModel()
                                   {
                                       TicketCategoryID = t.TicketCategoryID,
                                       Name = t.Name,
                                       IsActive = t.IsActive,
                                       TicketCount = t.Tickets.Count
                                   };
            return ticketCategories;
        }

        // GET: api/TicketCategories/5
        [ResponseType(typeof(TicketCategory))]
        public IHttpActionResult GetTicketCategory(int id)
        {
            TicketCategory ticketCategory = db.TicketCategories.Find(id);
            if (ticketCategory == null)
            {
                return NotFound();
            }

            return Ok(ticketCategory);
        }

        // PUT: api/TicketCategories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTicketCategory(int id, TicketCategory ticketCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ticketCategory.TicketCategoryID)
            {
                return BadRequest();
            }

            db.Entry(ticketCategory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketCategoryExists(id))
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

        // POST: api/TicketCategories
        [ResponseType(typeof(TicketCategory))]
        public IHttpActionResult PostTicketCategory(TicketCategory ticketCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TicketCategories.Add(ticketCategory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ticketCategory.TicketCategoryID }, ticketCategory);
        }

        // DELETE: api/TicketCategories/5
        [ResponseType(typeof(TicketCategory))]
        public IHttpActionResult DeleteTicketCategory(int id)
        {
            TicketCategory ticketCategory = db.TicketCategories.Find(id);
            if (ticketCategory == null)
            {
                return NotFound();
            }

            db.TicketCategories.Remove(ticketCategory);
            db.SaveChanges();

            return Ok(ticketCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TicketCategoryExists(int id)
        {
            return db.TicketCategories.Count(e => e.TicketCategoryID == id) > 0;
        }
    }
}