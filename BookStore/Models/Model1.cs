using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BookStore.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<FormDetail> FormDetails { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(e => e.Books)
                .WithOptional(e => e.Author)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Books)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.BookTypeID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Publisher>()
                .HasMany(e => e.Books)
                .WithOptional(e => e.Publisher)
                .WillCascadeOnDelete();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.User)
                .WillCascadeOnDelete();
        }
    }
}
