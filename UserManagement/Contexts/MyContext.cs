using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserManagement.Models;

namespace UserManagement.Contexts
{
    public class MyContext : IdentityDbContext
    {
        
        public MyContext(DbContextOptions<MyContext> options) : base(options){}

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Regency> Regencies { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Bootcamp> Bootcamps { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        IConfigurationRoot configuration = new ConfigurationBuilder()
        //           .SetBasePath(Directory.GetCurrentDirectory())
        //           .AddJsonFile("appsettings.json")
        //           .Build();
        //        var connectionString = configuration.GetConnectionString("MyConnection");
        //        optionsBuilder.UseMySql(connectionString);
        //    }
        //}
    }
}
