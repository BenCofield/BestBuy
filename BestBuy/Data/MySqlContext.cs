using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using BestBuy.Models;

namespace BestBuy.Data
{
	public class MySqlContext : DbContext
	{
		private readonly IConfiguration Configuration;
		public MySqlContext(IConfiguration configuration)
		{
			Configuration = configuration;
		}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
			var connectionString = Configuration.GetConnectionString("MySql");
            optionsBuilder.UseMySQL(connectionString);
        }

        public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Product>(e =>
			{
				e.HasKey(p => p.ProductID);
				e.ToTable("products");
			});
			modelBuilder.Entity<Category>(e =>
			{
				e.HasKey(c => c.CategoryID);
				e.ToTable("categories");
			});
			modelBuilder.Entity<Department>().ToTable("departments");
        }
    }
}

