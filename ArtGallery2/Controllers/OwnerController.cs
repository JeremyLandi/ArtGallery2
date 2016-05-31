using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArtGallery2.Models;
using ArtGallery2.ViewModel;

namespace ArtGallery2.Controllers
{
    public class OwnerController : Controller
    {
        private ArtGalleryDbContext db = new ArtGalleryDbContext();

        // GET: Owner View
        public ActionResult Index()
        {
            var locations = (from ip in db.IndividualPiece
                              select ip.Location).ToList().Distinct();

            List<OwnerIndexViewModel> LocationImages = new List<OwnerIndexViewModel>();

            foreach (var item in locations)
            {
                OwnerIndexViewModel vw = new OwnerIndexViewModel
                {
                    Image = (from ip in db.IndividualPiece
                             where ip.Location == item
                             select ip.Image).FirstOrDefault(),
                    Location = item.Replace(" ", "")
                };
                LocationImages.Add(vw);
            }
            return View(LocationImages);
        }

        #region Owner View

        [HttpGet]
        public ActionResult OwnerArtCollection(OwnerIndexViewModel ownerIndexViewModel)
        {
            var artWork = (from ip in db.IndividualPiece
                           join aw in db.ArtWork
                           on ip.ArtWorkId equals aw.ArtWorkId
                           join ar in db.Artist
                           on aw.ArtistId equals ar.ArtistId
                           where ip.Sold == false
                           where ip.Location.Replace(" ", "") == ownerIndexViewModel.Location.Replace(" ", "")

                           select new ArtViewModel
                           {
                               ArtWorkId = ip.ArtWorkId,
                               Title = aw.Title,
                               Category = ip.Category,
                               Name = ar.Name,
                               Image = ip.Image,
                               Medium = ip.Medium,
                               Price = ip.Price,
                               Cost = ip.Cost,
                               Edition = ip.EditionNumber,
                               IndividualPieceId = ip.IndividualPieceId,
                               Location = ownerIndexViewModel.Location
                           });

            return View(artWork.ToList());
        }

        #endregion

        #region SoldWork

        [HttpGet]
        public ActionResult SoldWork(string location)
        {
            var artWork = (from ip in db.IndividualPiece
                           join aw in db.ArtWork
                           on ip.ArtWorkId equals aw.ArtWorkId
                           join ar in db.Artist
                           on aw.ArtistId equals ar.ArtistId
                           where ip.Sold == true
                           where ip.Location.Replace(" ", "") == location.Replace(" ", "")

                           select new ArtViewModel
                           {
                               ArtWorkId = ip.ArtWorkId,
                               Title = aw.Title,
                               Category = ip.Category,
                               Name = ar.Name,
                               Image = ip.Image,
                               Medium = ip.Medium,
                               Price = ip.Price,
                               Profit = (ip.Price - ip.Cost),
                               Edition = ip.EditionNumber
                           });

            return View(artWork.ToList());
        }

        #endregion

        #region Details

        // GET: CreateNewArtViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateNewArtistViewModel createNewArtViewModel = db.CreateNewArtViewModels.Find(id);
            if (createNewArtViewModel == null)
            {
                return HttpNotFound();
            }
            return View(createNewArtViewModel);
        }

        #endregion

        #region CRUD Artist

        // GET: Owner/CreateArtist
        [HttpGet]
        public ActionResult CreateArtist()
        {
            return View();
        }

        // POST: Owner/CreateArtist
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateArtist([Bind(Include = "Name,BirthYear,DeathYear")] Artist createArtist)
        {
            if (ModelState.IsValid)
            {
                db.Artist.Add(createArtist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(createArtist);
        }

        // GET: Owner/EditArtist/5
        public ActionResult EditArtist(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artist.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);

        }
        
        // GET: Owner/Delete/5
        public ActionResult DeleteArtist(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateNewArtistViewModel createNewArtViewModel = db.CreateNewArtViewModels.Find(id);
            if (createNewArtViewModel == null)
            {
                return HttpNotFound();
            }
            return View(createNewArtViewModel);
        }

        // POST: Owner/Delete/5
        [HttpPost, ActionName("DeleteArtist")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteArtistConfirmed(int id)
        {
            CreateNewArtistViewModel createNewArtViewModel = db.CreateNewArtViewModels.Find(id);
            db.CreateNewArtViewModels.Remove(createNewArtViewModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    

        #endregion

        #region CRUD ArtWork
        // GET: Owner/CreateArtWork
        [HttpGet]
        public ActionResult CreateArtWork()
        {

            IEnumerable<SelectListItem> selectList =
                from a in db.Artist
                select new SelectListItem
                {
                    Text = a.Name,
                    Value = a.ArtistId.ToString()
                };

            ArtistDropDownViewModel artistList = new ArtistDropDownViewModel()
            {
                ArtistList = selectList
            };
            return View(artistList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateArtWork(ArtistDropDownViewModel createArtWork)
        {
            if (ModelState.IsValid)
            {
                var artwork = new ArtWork
                {
                    ArtistId = createArtWork.SelectedArtistId,
                    Title = createArtWork.Title,
                    YearOriginalCreated = createArtWork.YearOriginalCreated
                };
                db.ArtWork.Add(artwork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(createArtWork);
        }

        #endregion

        #region CRUD Individual Piece

        // GET: Owner/CreateIndividualPiece
        [HttpGet]
        public ActionResult CreateIndividualPiece()
        {
            IEnumerable<SelectListItem> selectList =
            from a in db.ArtWork
            select new SelectListItem
            {
                Text = a.Title,
                Value = a.ArtWorkId.ToString()
            };

            IEnumerable<SelectListItem> locactionSelectList =
             from a in db.IndividualPiece
             select new SelectListItem
             {
                 Text = a.Location,
                 Value = a.Location.ToString()
             };

            ArtWorkDropDownViewModel artWorkList = new ArtWorkDropDownViewModel()
            {
                LocationList = locactionSelectList.Distinct(),
                ArtWorkList = selectList
            };
            return View(artWorkList);
   
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateIndividualPiece(ArtWorkDropDownViewModel createIndividualPiece)
        {
            if (ModelState.IsValid)
            {
                var ip = new IndividualPiece
                {
                    ArtWorkId = createIndividualPiece.SelectedArtWorkId,
                    Category = createIndividualPiece.Category,
                    Image = createIndividualPiece.Image,
                    Cost = createIndividualPiece.Cost,
                    Price = createIndividualPiece.Price,
                    Sold = createIndividualPiece.Sold,
                    Location = createIndividualPiece.SelectedLocation.ToString(),
                    EditionNumber = createIndividualPiece.EditionNumber,
                    Medium = createIndividualPiece.Medium,
                    Dimensions = createIndividualPiece.Dimensions
                };

                db.IndividualPiece.Add(ip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(createIndividualPiece);
        }

        // GET: Owner/Edit/5
        public ActionResult EditIp(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndividualPiece individualPiece = db.IndividualPiece.Find(id);
            if (individualPiece == null)
            {
                return HttpNotFound();
            }
            return View(individualPiece);
        }

        // POST: Owner/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditIp([Bind(Include = "IndividualPieceId, ArtWorkId, Category, Image, Cost, Price, Sold, Location, EditionNumber, Medium, Dimensions")] IndividualPiece individualPiece)
        {
            if (ModelState.IsValid)
            {
                db.Entry(individualPiece).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(individualPiece);
        }

        // GET: Owner/Delete/5
        public ActionResult DeleteIp(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndividualPiece individualPiece = db.IndividualPiece.Find(id);
            if (individualPiece == null)
            {
                return HttpNotFound();
            }
            return View(individualPiece);
        }

        // POST: Owner/Delete/5
        [HttpPost, ActionName("DeleteIp")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteIpConfirmed(int id)
        {
            IndividualPiece individualPiece = db.IndividualPiece.Find(id);
            db.IndividualPiece.Remove(individualPiece);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

        // GET: Owner/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateNewArtistViewModel createNewArtViewModel = db.CreateNewArtViewModels.Find(id);
            if (createNewArtViewModel == null)
            {
                return HttpNotFound();
            }
            return View(createNewArtViewModel);
        }


        // POST: Owner/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrimaryTrackingkey,Name,BirthYear,DeathYear,Title,YearOriginalCreated,Medium,Dimensions,NumberMade,NumberInInventory,NumberSold,Category,Image,Cost,Price,Sold,Location,EditionNumber")] CreateNewArtistViewModel createNewArtViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(createNewArtViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(createNewArtViewModel);
        }

        // GET: Owner/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateNewArtistViewModel createNewArtViewModel = db.CreateNewArtViewModels.Find(id);
            if (createNewArtViewModel == null)
            {
                return HttpNotFound();
            }
            return View(createNewArtViewModel);
        }

        // POST: Owner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CreateNewArtistViewModel createNewArtViewModel = db.CreateNewArtViewModels.Find(id);
            db.CreateNewArtViewModels.Remove(createNewArtViewModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
