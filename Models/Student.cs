using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_App.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Required*")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Fname { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Required")]
        [Display(Name = "Department")]
        public int DepID { get; set; }



        [Required(ErrorMessage = "Required")]
        public string Mobile { get; set; }

        public string Description { get; set; }



        [NotMapped]
        public string Department { get; set; }

    }
}
