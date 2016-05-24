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
        // GET: Home
        public ActionResult Index()
        {
            ArtGalleryDbContext _context = new ArtGalleryDbContext();

            var listOfArt = (from aw in _context.ArtWork
                             select aw).ToList();
            return View(listOfArt);
        }
    }
}