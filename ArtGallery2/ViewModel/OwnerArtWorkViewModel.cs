using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArtGallery2.ViewModel
{
    public class OwnerArtWorkViewModel
    {
        public string Image { get; set; }
        public string Location { get; set; }
        [DataType(DataType.Currency)]
        public double Cost { get; set; }
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        [DataType(DataType.Currency)]
        public string Title { get; set; }
        public string Category { get; set; }
        public int ArtWorkId { get; set; }
    }
}