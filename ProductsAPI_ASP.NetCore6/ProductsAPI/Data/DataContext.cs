
using ProductsAPI.Core;

namespace ProductsAPI.Data;

public class DataContext :DbContext
{
    public DataContext(DbContextOptions<DataContext> options): base(options){ }

    public DbSet<ProductEntity> ProductEntities { get; set; }
}