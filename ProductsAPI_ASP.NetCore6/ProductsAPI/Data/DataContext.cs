using Microsoft.EntityFrameworkCore;

namespace ProductsAPI.Data;

public class DataContext :DbContext
{
    public DataContext(DbContextOptions<DataContext> options): base(options){ }
}