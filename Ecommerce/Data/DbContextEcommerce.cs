using Microsoft.EntityFrameworkCore;

public class DbContextEcommerce : DbContext
{
  public DbContextEcommerce(DbContextOptions options) : base(options)
  {

  }

  public DbSet<Product> Products { get; set; }
  public DbSet<Sale> Sales { get; set; }
  public DbSet<Category> Categories { get; set; }
  public DbSet<ProductSaleItem> ProductSaleItems { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Product>()
      .HasIndex(p => p.Name)
      .IsUnique();

    modelBuilder.Entity<Category>().HasQueryFilter(c => !c.IsDeleted);
    modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);
    modelBuilder.Entity<Sale>().HasQueryFilter(s => !s.IsDeleted);
    modelBuilder.Entity<ProductSaleItem>().HasQueryFilter(psi => !psi.IsDeleted);
  }
}