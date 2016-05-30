using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArtGallery2.ViewModel
{
    public class ArtViewModel
    {
        public string Image { get; set; }
        public int IndividualPieceId { get; set; }
        public string Location { get; set; }
        [DataType(DataType.Currency)]
        public double Cost { get; set; }
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        [DataType(DataType.Currency)]
        public double Profit { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public int ArtWorkId { get; set; }
        public string Name { get; set; }
        public string Dimensions { get; set; }
        public string Medium { get; set; }
        public int NumberInInventory { get; set; }
        public int Edition { get; set; }
    }
}