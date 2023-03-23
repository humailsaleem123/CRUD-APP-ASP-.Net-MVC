using System.ComponentModel.DataAnnotations;

namespace CRUD_App.Models
{
    public class Departments
    {
        [Key]
        public int ID { get; set; }

        public string Department { get; set; }
    }
}
