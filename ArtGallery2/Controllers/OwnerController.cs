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
            return View();
        }

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

        // GET: Owner/CreateArtist
        [HttpGet]
        public ActionResult CreateArtist()
        {
            return View();
        }

        // POST: CreateNewArtViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Owner/CreateArtWork
        [HttpGet]
        public ActionResult CreateArtWork()
        {

            //var ArtistList = new List<string>();
            //ArtistList.AddRange(ArtistQry.Distinct());
            //ViewData["ArtistName"] = new SelectList(ArtistList);

            //var ArtistQry = (from a in db.Artist
            //                 orderby a.Name
            //                 select a).ToList();

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

        // GET: Owner/CreateIndividualPiece
        [HttpGet]
        public ActionResult CreateIndividualPiece()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateIndividualPiece([Bind(Include = "Title,YearOriginalCreated")] IndividualPiece createIndividualPiece)
        {
            if (ModelState.IsValid)
            {
                db.IndividualPiece.Add(createIndividualPiece);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(createIndividualPiece);
        }

        // GET: CreateNewArtViewModels/Edit/5
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

        // POST: CreateNewArtViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: CreateNewArtViewModels/Delete/5
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

        // POST: CreateNewArtViewModels/Delete/5
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
