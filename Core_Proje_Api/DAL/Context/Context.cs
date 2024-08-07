using Core_Proje_Api.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace Core_Proje_Api.DAL.Context
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-6F9GQRG\\SQLEXPRESS;database=CoreCVDB4API;integrated security=true");
        }
        public DbSet<Category> Categories { get; set; }
    }
}
