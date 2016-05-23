using ArtGallery2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtGallery2.Controllers
{
    public class HomeController : Controller
    {
        //private ArtGalleryDbContext _context;

        //public HomeController(ArtGalleryDbContext context)
        //{
        //    _context = context;
        //}
        ArtGalleryDbContext _context = new ArtGalleryDbContext();
        
        // GET: Home
        public ActionResult Index()
        {
            var listOfArt = (from aw in _context.ArtWork
                             select aw);
            return View(listOfArt.ToList());
        }
    }
}