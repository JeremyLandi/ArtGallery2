using ArtGallery2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ArtGallery2.Models
{
    public class ArtGalleryDbContext : DbContext
    {
        public DbSet<ArtWork> ArtWork { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArtWork>()
            .ToTable("ArtWork")
            .HasKey(aw => aw.ArtWorkId);
        }
    }
}