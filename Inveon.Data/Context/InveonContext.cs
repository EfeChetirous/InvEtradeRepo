using Inveon.Data.Entity;
using Inveon.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inveon.Data.Context
{
    public class InveonContext : DataContext, IDisposable
    {
        static InveonContext()
        {
            Database.SetInitializer<DbContext>(null);
        }

        public InveonContext()
            : base("Name=InveonContext")
        {
        }

        //public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        //public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        //public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        //public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductImage> ProductImage { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<AspNetRoleClaims>().ToTable("AspNetRoleClaims");

            //modelBuilder.Entity<AspNetRoles>().ToTable("AspNetRoles");

            //modelBuilder.Entity<AspNetUserClaims>().ToTable("AspNetUserClaims");

            //modelBuilder.Entity<AspNetUsers>().ToTable("AspNetUsers");

            modelBuilder.Entity<Product>().ToTable("Product");

            modelBuilder.Entity<ProductImage>().ToTable("ProductImage");
        }
    }
}
