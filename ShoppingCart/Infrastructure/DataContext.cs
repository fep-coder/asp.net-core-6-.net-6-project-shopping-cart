using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Infrastructure
{
        public class DataContext : DbContext
        {
                public DataContext(DbContextOptions<DataContext> options) : base(options)
                {
                }
        }
}
