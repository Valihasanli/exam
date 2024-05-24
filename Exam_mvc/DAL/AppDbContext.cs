using Exam_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam_mvc.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options){}
        public DbSet<Service> Services { get; set; }
    }
}
