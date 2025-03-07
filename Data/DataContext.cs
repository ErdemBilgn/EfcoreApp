using Microsoft.EntityFrameworkCore;

namespace EfcoreApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Course> Courses => Set<Course>();

        public DbSet<Student> Students => Set<Student>();

        public DbSet<CourseRecord> CourseRecords => Set<CourseRecord>();

        public DbSet<Teacher> Teachers => Set<Teacher>();
    }
}