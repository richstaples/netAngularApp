using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    /// <summary>
    /// Data Context class for EF functionality
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="options"></param>
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
    }
}