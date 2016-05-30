using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtGallery2.ViewModel
{
    public class ArtGalleryViewModel
    {
        public int SelectedArtistId { get; set; }
        public string Category { get; set; }
        public List<DigitalPrintViewModel> ListOfArtCollection  { get; set;}
        public IEnumerable<SelectListItem> ArtistList { get; set; }
    }
}