namespace ModelEF.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NguyenHuynhPhiLongContext : DbContext
    {
        public NguyenHuynhPhiLongContext()
            : base("name=NguyenHuynhPhiLongContext")
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<UserAccount> UserAccount { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Product)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.ProductType);

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitCost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
