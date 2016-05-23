using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery2.Models
{
    public class LineItem
    {
        public int LineItemId { get; set; }
        public int IndividualPieceId { get; set; }
        public int InvoiceId { get; set; }
    }
}
