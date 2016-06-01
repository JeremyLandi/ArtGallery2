using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtGallery2.ViewModel
{
    public class ArtWorkDropViewModel
    {
        [Key]
        public int PrimaryTrackingkey { get; set; }

        [Display(Name = "Art Work")]
        public int SelectedArtWorkId { get; set; }
        public IEnumerable<SelectListItem> ArtWorkList { get; set; }

        [Display(Name = "Location")]
        public int SelectedLocation { get; set; }
        public IEnumerable<SelectListItem> LocationList { get; set; }

        public int IndividualPieceId { get; set; }
        public int ArtWorkId { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public double Cost { get; set; }
        public double Price { get; set; }
        public bool Sold { get; set; }
        public string Location { get; set; }
        public int EditionNumber { get; set; }
        public string Medium { get; set; }
        public string Dimensions { get; set; }
    }
}