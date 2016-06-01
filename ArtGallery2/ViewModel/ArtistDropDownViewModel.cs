using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtGallery2.ViewModel
{
    public class ArtistDropDownViewModel
    {
        [Display(Name = "Artist")]
        public int SelectedArtistId { get; set; }
        public IEnumerable<SelectListItem> ArtistList { get; set; }

        public int ArtistId { get; set; }
        public string Title { get; set; }

        public string Location { get; set; }

        [DataType(DataType.Date)]
        public DateTime YearOriginalCreated { get; set; }
    }
}