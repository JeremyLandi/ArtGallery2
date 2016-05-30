using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery2.Models
{
    public class IndividualPiece
    {
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
