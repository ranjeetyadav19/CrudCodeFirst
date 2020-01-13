namespace CodeFirstCrud
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataEntity : DbContext
    {
        public DataEntity()
            : base("name=DataEntity")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Category>()
            //    .HasOptional(e => e.Category1)
            //    .WithRequired(e => e.Category2);
        }
    }
}
