using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using WystawkaDB;

namespace WystawkaAPI.Controllers
{
    public class ItemsController : ApiController
    {
        private WystawkaDBEntities db = new WystawkaDBEntities();

        // GET: api/Items
        public List<Models.Item> GetItems()
        {
            var result = new List<Models.Item>();
            foreach (var item in db.Items)
            {
                result.Add(new Models.Item
                {
                    ItemID = item.ItemID,
                    Name = item.Name,
                    Description = item.Description,
                    DatePosted = item.DatePosted,
                    DateEnd = item.DateEnd,
                    Foto = new Models.Foto
                    {
                        FotoID = item.FotoID,
                        FotoLocalization = item.Foto.Localization
                    },
                    Localization = new Models.Localization
                    {
                        LocalizationID = item.LocalizationID,
                        City = item.Localization.City,
                        Street = item.Localization.Street,
                        Coords = new Models.Coords
                        {
                            CoordsID = item.Localization.Coord.CoordsID,
                            Latitude = item.Localization.Coord.Latitude,
                            Longitude = item.Localization.Coord.Longitude
                        }
                    }
                });
            }

            return result;
        }

        // GET: api/Items/5
        [ResponseType(typeof(Item))]
        public IHttpActionResult GetItem(int id)
        {
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            var result = new Models.Item
            {
                ItemID = item.ItemID,
                Name = item.Name,
                Description = item.Description,
                DatePosted = item.DatePosted,
                DateEnd = item.DateEnd,
                Foto = new Models.Foto
                {
                    FotoID = item.FotoID,
                    FotoLocalization = item.Foto.Localization
                },
                Localization = new Models.Localization
                {
                    LocalizationID = item.LocalizationID,
                    City = item.Localization.City,
                    Street = item.Localization.Street,
                    Coords = new Models.Coords
                    {
                        CoordsID = item.Localization.Coord.CoordsID,
                        Latitude = item.Localization.Coord.Latitude,
                        Longitude = item.Localization.Coord.Longitude
                    }
                }
            };

            return Ok(result);
        }

        // PUT: api/Items/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutItem(int id, Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.ItemID)
            {
                return BadRequest();
            }

            db.Entry(item).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
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

        // POST: api/Items
        [ResponseType(typeof(Item))]
        public IHttpActionResult PostItem(Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Items.Add(item);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = item.ItemID }, item);
        }

        // DELETE: api/Items/5
        [ResponseType(typeof(Item))]
        public IHttpActionResult DeleteItem(int id)
        {
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            db.Items.Remove(item);
            db.SaveChanges();

            return Ok(item);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemExists(int id)
        {
            return db.Items.Count(e => e.ItemID == id) > 0;
        }
    }
}