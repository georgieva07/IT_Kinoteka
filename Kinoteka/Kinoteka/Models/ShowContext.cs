using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Kinoteka.Models
{
    public class ShowContext : DbContext
    {
        public DbSet<Person> Person { get; set; }

        public DbSet<Show> Show { get; set; }

        public DbSet<Genre> Genre { get; set; }

        public ShowContext() : base("DefaultConnection") { }

        public static ShowContext Create()
        {
            return new ShowContext();
        }
    }
}