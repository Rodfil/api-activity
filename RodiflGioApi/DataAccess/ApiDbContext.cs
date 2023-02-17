using Microsoft.EntityFrameworkCore;
using RodiflGioApi.Models;
using System.Data;
using System.Net;

namespace RodiflGioApi.DataAccess
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
        public DbSet<Address> Address { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<People> People { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<Warehouse_People> Warehouse_People { get; set; }
    }
}
