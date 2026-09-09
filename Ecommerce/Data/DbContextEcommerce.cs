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
  }
}