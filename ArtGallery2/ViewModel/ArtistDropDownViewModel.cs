<<<<<<< HEAD
﻿using ArtGallery2.Models;
using System;
=======
﻿using System;
>>>>>>> ownerView
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtGallery2.ViewModel
{
    public class ArtistDropDownViewModel
    {
<<<<<<< HEAD
        //public List<Artist> artist;

        [Display(Name = "Artist")]
        public int SelectedArtistId { get; set; }
        public IEnumerable<SelectListItem> ArtistList { get; set; }

        public int ArtistId { get; set; }
        public string  Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime YearOriginalCreated { get; set; }
    }
=======
         //public List<Artist> artist;
 
         [Display(Name = "Artist")]
         public int SelectedArtistId { get; set; }
         public IEnumerable<SelectListItem> ArtistList { get; set; }
 
         public int ArtistId { get; set; }
         public string Title { get; set; }

        public string Location { get; set; }
 
         [DataType(DataType.Date)]
         public DateTime YearOriginalCreated { get; set; }
     }
>>>>>>> ownerView
}