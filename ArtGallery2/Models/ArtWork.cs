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

        //get from id is ind piece
           // public int NumberMade { get; set; }
        // get from ^  minus number sold
           // public int NumberInInventory { get; set; }
        // get from invoice(lineItem)
            //public int NumberSold { get; set; }
    }
}
