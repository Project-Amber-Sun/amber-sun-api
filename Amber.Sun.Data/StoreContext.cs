using Amber.Sun.Domain.catalog;
using Microsoft.EntityFrameworkCore;

namespace Amber.Sun.Data{
    public class storecontext : DbContext {
        public storecontext(DbContextOptions<storecontext> options) : base(options){ }
        public DbSet<Item> Items { get; set; } 
    }
}

