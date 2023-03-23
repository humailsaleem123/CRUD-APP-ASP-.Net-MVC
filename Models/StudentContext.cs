using Microsoft.EntityFrameworkCore;

namespace CRUD_App.Models
{
    public class StudentContext : DbContext
    {

        public StudentContext(DbContextOptions<StudentContext> options) : base(options) 
        {
        }
 
        public DbSet<Student> tabl_Students { get; set; }
        public DbSet<Departments> tabl_Department{ get; set; }

    }
}
