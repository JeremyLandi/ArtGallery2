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

        // GET: CreateNewArtViewModels
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

        public ActionResult ArtCollection(string location)
        {
            var listOfIndividualPieces = (from ip in db.IndividualPiece
                                      where (ip.Location).Replace(" ", "") == location.Replace(" ", "")
                                      select ip).ToList();

            return View(listOfIndividualPieces);
        }

        // GET: CreateNewArtViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateNewArtViewModel createNewArtViewModel = db.CreateNewArtViewModels.Find(id);
            if (createNewArtViewModel == null)
            {
                return HttpNotFound();
            }
            return View(createNewArtViewModel);
        }

        // GET: CreateNewArtViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreateNewArtViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrimaryTrackingkey,Name,BirthYear,DeathYear,Title,YearOriginalCreated,Medium,Dimensions,NumberMade,NumberInInventory,NumberSold,Category,Image,Cost,Price,Sold,Location,EditionNumber")] CreateNewArtViewModel createNewArtViewModel)
        {
            if (ModelState.IsValid)
            {
                db.CreateNewArtViewModels.Add(createNewArtViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(createNewArtViewModel);
        }

        // GET: CreateNewArtViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateNewArtViewModel createNewArtViewModel = db.CreateNewArtViewModels.Find(id);
            if (createNewArtViewModel == null)
            {
                return HttpNotFound();
            }
            return View(createNewArtViewModel);
        }

        // POST: CreateNewArtViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrimaryTrackingkey,Name,BirthYear,DeathYear,Title,YearOriginalCreated,Medium,Dimensions,NumberMade,NumberInInventory,NumberSold,Category,Image,Cost,Price,Sold,Location,EditionNumber")] CreateNewArtViewModel createNewArtViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(createNewArtViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(createNewArtViewModel);
        }

        // GET: CreateNewArtViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateNewArtViewModel createNewArtViewModel = db.CreateNewArtViewModels.Find(id);
            if (createNewArtViewModel == null)
            {
                return HttpNotFound();
            }
            return View(createNewArtViewModel);
        }

        // POST: CreateNewArtViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CreateNewArtViewModel createNewArtViewModel = db.CreateNewArtViewModels.Find(id);
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
