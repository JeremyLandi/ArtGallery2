using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtGallery2.Models
{
    public class SYSUser
    {
        public int SYSUserID { get; set; }
        public string LoginName { get; set; }
        public string PasswordEncry { get; set; }
    }
}