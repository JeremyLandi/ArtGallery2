using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery2.Models
{
    public class ArtShowArtWork
    {
        public int ArtShowArtWorkId { get; set; }
        public int ArtShowId { get; set; }
        public int ArtWorkId { get; set; }
    }
}
