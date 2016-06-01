using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtGallery2.ViewModel
{
    public class ArtListViewModel
    {
        public List<ArtViewModel> artViewModel { get; set; }
        public string Location { get; set; }
    }
}