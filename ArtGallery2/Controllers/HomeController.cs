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
            return View();
        }

        public ActionResult DigitalPrint()
        {
            var listOfDigitalPrint = (from ip in _context.IndividualPiece
                                      where ip.Category == "Digital Print"

                                      join aw in _context.ArtWork
                                      on ip.ArtWorkId equals aw.ArtWorkId
                                      group ip by new
                                      {
                                          ip.Image,
                                          aw.ArtWorkId,
                                          ip.Price,
                                          aw.Dimensions,
                                          ip.Location,
                                          aw.NumberInInventory,
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
                                 NumberInInventory = g.Key.NumberInInventory,
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
                                      ip.Price,
                                      aw.Dimensions,
                                      ip.Location,
                                      aw.NumberInInventory,
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
                                      NumberInInventory = g.Key.NumberInInventory,
                                      Title = g.Key.Title

                                  }).FirstOrDefault();
            return View(artWorkDetails);
        }
    }
}