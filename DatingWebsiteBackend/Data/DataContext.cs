using DatingWebsiteBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingWebsiteBackend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Value> Values { get; set; }
    }
}