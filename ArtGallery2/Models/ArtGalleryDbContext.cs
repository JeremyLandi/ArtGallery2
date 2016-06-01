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
        public DbSet<Agent> Agent { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<ArtShow> ArtShow { get; set; }
        public DbSet<ArtShowArtWork> ArtShowArtWork { get; set; }
        public DbSet<ArtWork> ArtWork { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<IndividualPiece> IndividualPiece { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<LineItem> LineItem { get; set; }
        public DbSet<Category> Category { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ArtGalleryDbContext>(null);

            modelBuilder.Entity<Agent>()
            .ToTable("Agent")
            .HasKey(a => a.AgentId);

            modelBuilder.Entity<Category>()
            .ToTable("Category")
            .HasKey(a => a.CategoryId);

            modelBuilder.Entity<Artist>()
            .ToTable("Artist")
            .HasKey(at=> at.ArtistId);

            modelBuilder.Entity<ArtShow>()
            .ToTable("ArtShow")
            .HasKey(aw => aw.ArtShowId);

            modelBuilder.Entity<ArtShowArtWork>()
            .ToTable("ArtShowArtWork")
            .HasKey(asw => asw.ArtShowArtWorkId);

            modelBuilder.Entity<ArtWork>()
            .ToTable("ArtWork")
            .HasKey(aw => aw.ArtWorkId);

            modelBuilder.Entity<Customer>()
            .ToTable("Customer")
            .HasKey(c => c.CustomerId);

            modelBuilder.Entity<IndividualPiece>()
            .ToTable("IndividualPiece")
            .HasKey(i => i.IndividualPieceId);

            modelBuilder.Entity<Invoice>()
            .ToTable("Invoice")
            .HasKey(i => i.InvoiceId);

            modelBuilder.Entity<LineItem>()
            .ToTable("LineItem")
            .HasKey(l => l.LineItemId);
        }

<<<<<<< HEAD
        public System.Data.Entity.DbSet<ArtGallery2.ViewModel.CreateArtistViewModel> CreateNewArtViewModels { get; set; }
=======
        public System.Data.Entity.DbSet<ArtGallery2.ViewModel.CreateNewArtistViewModel> CreateNewArtViewModels { get; set; }

        public System.Data.Entity.DbSet<ArtGallery2.ViewModel.CreateNewArtViewModel> CreateNewArtViewModels1 { get; set; }
>>>>>>> ownerView
    }
}