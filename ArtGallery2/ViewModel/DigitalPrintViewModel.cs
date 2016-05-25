using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtGallery2.ViewModel
{
    public class DigitalPrintViewModel
    {
        public string Image { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public string Dimensions { get; set; }
        public string Location { get; set; }
        public int NumberInInventory { get; set; }
        public string Title { get; set; }
        public int ArtWorkId { get; set; }
    }
}