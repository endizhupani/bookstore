using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() 
            : base("BookStoreConnection")
        {
            
        }

        public ApplicationDbContext Create() => new ApplicationDbContext();

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #region DbSets
        public DbSet<Book> Books { get; set; }
        public DbSet<Tag> Tags { get; set; }
        #endregion
    }
}
