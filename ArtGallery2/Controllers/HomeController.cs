using ArtGallery2.Models;
using ArtGallery2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtGallery2.Controllers
{
    public class HomeController : Controller
    {
        ArtGalleryDbContext _context = new ArtGalleryDbContext();

        // GET: Home
        public ActionResult Index()
        {
            var categories = (from ip in _context.IndividualPiece
                              select ip.Category).ToList().Distinct();

            List<IndexViewModel> catigoryImages = new List<IndexViewModel>();

            foreach (var item in categories)
            {
                IndexViewModel vw = new IndexViewModel
                {
                    Image = (from ip in _context.IndividualPiece
                             where ip.Category == item
                             select ip.Image).FirstOrDefault(),
                    Category = item.Replace(" ", "")
                };
                catigoryImages.Add(vw);
            }
            return View(catigoryImages);
        }


        [HttpGet]
        public ActionResult ArtCollection(IndexViewModel indexViewModel)
        {

            var artWork = (from aw in _context.ArtWork
                           join ar in _context.Artist
                           on aw.ArtistId equals ar.ArtistId
                           join ip in _context.IndividualPiece
                           on aw.ArtWorkId equals ip.ArtWorkId
                           where ip.Sold == false
                           where ip.Category.Replace(" ", "") == indexViewModel.Category
                           group ip by new
                           {
                               aw.ArtWorkId,
                               aw.Title,
                               ip.Category,
                               ar.Name,
                               ip.Image,
                               ip.Medium,
                               ip.Price
                           }
                              into g
                           select new ArtViewModel
                           {
                               ArtWorkId = g.Key.ArtWorkId,
                               Title = g.Key.Title,
                               Category = g.Key.Category,
                               Name = g.Key.Name,
                               Image = g.Key.Image,
                               Medium = g.Key.Medium,
                               Price = g.Key.Price
                           });

            return View(artWork.ToList());
        }

        public ActionResult ArtCollection(IndexViewModel indexViewModel,
                                  string searchString,
                                  int? searchId,
                                  int? minPrice,
                                  int? maxPrice)
        {

            var artWork = (from aw in _context.ArtWork
                           join ar in _context.Artist
                           on aw.ArtistId equals ar.ArtistId
                           join ip in _context.IndividualPiece
                           on aw.ArtWorkId equals ip.ArtWorkId
                           where ip.Sold == false
                           where ip.Category.Replace(" ", "") == indexViewModel.Category.Replace(" ", "")
                           group ip by new
                           {
                               aw.ArtWorkId,
                               aw.Title,
                               ar.Name,
                               ip.Image,
                               ip.Medium,
                               ip.Price
                           }
                                into g
                           select new ArtViewModel
                           {
                               ArtWorkId = g.Key.ArtWorkId,
                               Title = g.Key.Title,
                               Name = g.Key.Name,
                               Image = g.Key.Image,
                               Medium = g.Key.Medium,
                               Price = g.Key.Price
                           }).Distinct();

            // Filter by artist name
            if (!string.IsNullOrEmpty(searchString) && searchId == 1)
            {
                artWork = artWork.Where(aw => aw.Name.Contains(searchString));
            }

            // Filter by price range
            if ((minPrice != null || maxPrice != null) && searchId == 2)
            {
                if (minPrice == null)
                {
                    artWork = artWork.Where(aw => aw.Price <= maxPrice);
                }
                else if (maxPrice == null)
                {
                    artWork = artWork.Where(aw => aw.Price >= minPrice);
                }
                else
                {
                    artWork = artWork.Where(aw => aw.Price <= maxPrice && aw.Price >= minPrice);
                }
            }

            ModelState.Clear();
            return View(artWork.ToList());
        }

        public ActionResult Detail(int? id)
        {
            var artWorkDetails = (from ip in _context.IndividualPiece
                                  where ip.ArtWorkId == id

                                  join aw in _context.ArtWork
                                  on ip.ArtWorkId equals aw.ArtWorkId
                                  group ip by new
                                  {
                                      ip.Image,
                                      ip.IndividualPieceId,
                                      aw.ArtWorkId,
                                      ip.Category,
                                      ip.Price,
                                      ip.Dimensions,
                                      ip.Location,
                                      aw.Title,
                                      ip.EditionNumber
                                  }
                                      into g

                                  select new ArtViewModel
                                  {
                                      Image = g.Key.Image,
                                      IndividualPieceId = g.Key.IndividualPieceId,
                                      ArtWorkId = g.Key.ArtWorkId,
                                      Category = (g.Key.Category).Replace(" ",""),
                                      Price = g.Key.Price,
                                      Dimensions = g.Key.Dimensions,
                                      Location = g.Key.Location,
                                      Title = g.Key.Title,
                                      NumberInInventory = g.Key.EditionNumber

                                  }).FirstOrDefault();
            return View(artWorkDetails);
        }
    }
}