using CoreProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataProject
{
    public class AcademicContext : DbContext
    {
        public AcademicContext(DbContextOptions<AcademicContext> options)
            : base(options)
        { }

        public DbSet<Student> Users { get; set; }
    }
}