﻿using Library.Web.Entities;
using System.Data.Entity;

namespace DataAccessLayer.Models
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Brochure> Brochures { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<PublicationHouse> PublicationHouses { get; set; }

        public LibraryDbContext():base("PublicationsContext") { }
        public LibraryDbContext(string connectionString) : base(connectionString)
        { }
    }
}
