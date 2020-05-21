using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SFF_Api_App.Models;
using Microsoft.EntityFrameworkCore;

namespace SFF_Api_App.DB
{
    public class SFF_DbContext :DbContext
        {

        public SFF_DbContext(DbContextOptions<SFF_DbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Trivias> Trivias { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=SFF_Databas.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>().Property(r => r.Grade).IsRequired();
            modelBuilder.Entity<Movie>().Property(r => r.Title).IsRequired();
            modelBuilder.Entity<Studio>().Property(r => r.Name).IsRequired();
            modelBuilder.Entity<Trivias>().Property(r => r.Title).IsRequired();
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed categories
            modelBuilder.Entity<Studio>().HasData(new Studio { StudioId = 1, Name = "Studio 1", Ort ="Ort 1" });
            modelBuilder.Entity<Studio>().HasData(new Studio { StudioId = 2, Name = "Studio 2", Ort = "Ort 2" });
            modelBuilder.Entity<Studio>().HasData(new Studio { StudioId = 3, Name = "Studio 3", Ort = "Ort 3" });

            //seed Movies

            modelBuilder.Entity<Movie>().HasData(new Movie
            {
               Id = 1, 
               Title = "ABC_Movie",
               Genre = "Action",
               Stock = 5,
               StudioName = "Studio1",
               MaxStock = false,
               MaxStudios = 5,
               TriviasId = 1,
               ReviewId = 2
            });

            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = 2,
                Title = "ABCD_Movie",
                Genre = "Action",
                Stock = 5,
                StudioName = "Studio1",
                MaxStock = false,
                MaxStudios = 5,
                TriviasId = 1,
                ReviewId = 2
            });

            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = 3,
                Title = "ABCDE_Movie",
                Genre = "Action",
                Stock = 5,
                MaxStock = false,
                MaxStudios = 5,
                StudioName = "Studio2",
                TriviasId = 1,
                ReviewId = 2
            });
            modelBuilder.Entity<Trivias>().HasData(new Trivias
            {
                Id = 1,
                Title = "Trivias 1",
                
               
            });
            modelBuilder.Entity<Trivias>().HasData(new Trivias
            {
                Id = 2,
                Title = "Trivias 2",


            });
            modelBuilder.Entity<Review>().HasData(new Review
            {
                Id = 1,
                MovieId =  2,
                Grade= 5,
                


            });
            modelBuilder.Entity<Review>().HasData(new Review
            {
                Id = 2,
                MovieId = 3,
                Grade = 4,


            });
            modelBuilder.Entity<Rental>().HasData(new Rental
            {
                Id = 1,
                MovieId = 3,
               StudioId = 4,


            });
            modelBuilder.Entity<Rental>().HasData(new Rental
            {
                Id = 2,
                MovieId = 3,
                StudioId = 4,


            });
        }
    }
}
