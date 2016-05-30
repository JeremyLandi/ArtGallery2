using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery2.Models
{
    public class ArtWork
    {
        public int ArtWorkId { get; set; }
        public int ArtistId { get; set; }
        public string Title { get; set; }
        public DateTime YearOriginalCreated { get; set; }

        //public int NumberMade { get; set; }
        //public int NumberInInventory { get; set; }
        //public int NumberSold { get; set; }
    }
}
