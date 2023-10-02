using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MinLength(8),MaxLength(50)]
        public string? StudentName { get; set;}

        public bool isActive { get; set;}

        [Required]
        [Range(5,18)]
        public int StudentAge { get; set; }

        public string? StudentPhoto { get; set; }
    }
}
