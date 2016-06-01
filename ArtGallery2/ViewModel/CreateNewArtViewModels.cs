﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtGallery2.ViewModel
{
	public class CreateNewArtViewModels
	{
        [Key]
        public int PrimaryTrackingkey { get; set; }
        //Artist
        public string Name { get; set; }
        public DateTime BirthYear { get; set; }
        public DateTime DeathYear { get; set; }

        [Display(Name = "Art Work")]
        public int SelectedArtWorkId { get; set; }
        public IEnumerable<SelectListItem> ArtWorkList { get; set; }

        //ArtWork
        public string Title { get; set; }
        public DateTime YearOriginalCreated { get; set; }
        public string Medium { get; set; }
        public string Dimensions { get; set; }
        public int NumberMade { get; set; }
        public int NumberInInventory { get; set; }
        public int NumberSold { get; set; }

        //Ind Piece
        public string Category { get; set; }
        public string Image { get; set; }
        public double Cost { get; set; }
        public double Price { get; set; }
        public bool Sold { get; set; }
        public string Location { get; set; }
        public int EditionNumber { get; set; }
    }
}