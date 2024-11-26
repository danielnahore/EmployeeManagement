using EmployeeManagement;
using Microsoft.EntityFrameworkCore;

// TODO
// in package console tool:
// Add-Migration InitialCreate
// Update-Datebase

namespace Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id = 1,
                    Name = "IT",
                });
            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id = 2,
                    Name = "HR",
                });
            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id = 3,
                    Name = "PR",
                });
            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id = 4,
                    Name = "Finance",
                });
            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id = 5,
                    Name = "Admin",
                });

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Smith",
                    Email = "john@gmail.com",
                    DateOfBirth = new DateTime(1980, 10, 5),
                    Gender = Gender.Male,
                    DepartmentId = 1,
                    PhotoPath = "images/john.png"
                });
            
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 2,
                    FirstName = "Daniel",
                    LastName = "Rabbit",
                    Email = "daniel@gmail.com",
                    DateOfBirth = new DateTime(1996, 8, 22),
                    Gender = Gender.Male,
                    DepartmentId = 5, 
                    PhotoPath = "images/daniel.png"
                });

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 3,
                    FirstName = "Leonard",
                    LastName = "White",
                    Email = "leonard@gmail.com",
                    DateOfBirth = new DateTime(1985, 6, 6),
                    Gender = Gender.Male,
                    DepartmentId = 3, 
                    PhotoPath = "images/leonard.png"
                });

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 4,
                    FirstName = "Rafael",
                    LastName = "Singer",
                    Email = "rafael@gmail.com",
                    DateOfBirth = new DateTime(1991, 5, 5),
                    Gender = Gender.Male,
                    DepartmentId = 4, 
                    PhotoPath = "images/rafael.png"
                });
            
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 5,
                    FirstName = "Jane",
                    LastName = "Hobbit",
                    Email = "jane@gmail.com",
                    DateOfBirth = new DateTime(1999, 1, 1),
                    Gender = Gender.Female,
                    DepartmentId = 2, 
                    PhotoPath = "images/jane.png"
                });
        }
    }
}
