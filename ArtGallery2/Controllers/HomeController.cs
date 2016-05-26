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


        public ActionResult ArtCollection(string category)
        {
            var ArtWorkSold = (from ip in _context.IndividualPiece
                               join aw in _context.ArtWork
                               on ip.ArtWorkId equals aw.ArtWorkId
                               select ip.ArtWorkId).Count();

            var listOfDigitalPrint = (from ip in _context.IndividualPiece
                                      where (ip.Category).Replace(" ","") == category.Replace(" ", "")
                                      join aw in _context.ArtWork
                                      on ip.ArtWorkId equals aw.ArtWorkId
                                      group ip by new
                                      {
                                          ip.Image,
                                          ip.ArtWorkId,
                                          ip.Price,
                                          ip.Dimensions,
                                          //aw.NumberInInventory,
                                          ip.Location,
                                          aw.Title
                                      }
                                      into g  

                             select new DigitalPrintViewModel
                             {
                                 Image = g.Key.Image,
                                 ArtWorkId = g.Key.ArtWorkId,
                                 Price = g.Key.Price,
                                 Dimensions = g.Key.Dimensions,
                                 Location = g.Key.Location,
                                 //NumberInInventory = g.Key.NumberInInventory,
                                 Title = g.Key.Title

                             }).ToList();

            return View(listOfDigitalPrint);
        }

        public ActionResult Detail(int ArtWorkId)
        {
            var artWorkDetails = (from ip in _context.IndividualPiece
                                  where ip.ArtWorkId == ArtWorkId

                                  join aw in _context.ArtWork
                                  on ip.ArtWorkId equals aw.ArtWorkId
                                  group ip by new
                                  {
                                      ip.Image,
                                      aw.ArtWorkId,
                                      ip.Category,
                                      ip.Price,
                                      ip.Dimensions,
                                      ip.Location,
                                      //aw.NumberInInventory,
                                      aw.Title
                                  }
                                      into g

                                  select new DigitalPrintViewModel
                                  {
                                      Image = g.Key.Image,
                                      ArtWorkId = g.Key.ArtWorkId,
                                      Category = g.Key.Category,
                                      Price = g.Key.Price,
                                      Dimensions = g.Key.Dimensions,
                                      Location = g.Key.Location,
                                      //NumberInInventory = g.Key.NumberInInventory,
                                      Title = g.Key.Title

                                  }).FirstOrDefault();
            return View(artWorkDetails);
        }
    }
}