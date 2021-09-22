using Northwind.Entities;
using System.Data.Entity;

namespace Northwind.Data
{
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext()
            : base("name=NorthwindConnection")
        {
        }

        public virtual DbSet<Territories> Territories { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Territories>()
                .Property(e => e.TerritoryDescription)
                .IsFixedLength();
        }
    }
}
