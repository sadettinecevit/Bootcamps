using Microsoft.EntityFrameworkCore;

namespace SadettinEcevitOdevHafta2_2.Data
{
    public class EducationDbContext : DbContext
    {
        public EducationDbContext(DbContextOptions<EducationDbContext> options) : base(options) 
        {

        }

        DbSet<School> Schools { get; set; }
        DbSet<Class> Class { get; set; }
        DbSet<Lesson> Lessons { get; set; } 
        DbSet<Teacher> Teachers { get; set; }
        DbSet<Student> Students { get; set; }
    }
}
