using Microsoft.EntityFrameworkCore;
using RabbitBAU.Abstract;

namespace RabbitBAU.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        { }

        public DbSet<Message> Messages { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
