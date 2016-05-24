using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery2.Models
{
    public class ArtShow
    {
        public int ArtShowId { get; set; }
        public string ShowName { get; set; }
        public string ShowLocation { get; set; }
        public float Overhead { get; set; }
    }
}
