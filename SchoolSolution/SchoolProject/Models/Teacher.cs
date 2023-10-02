using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Models
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MinLength(8), MaxLength(50)]
        public string? TeacherName { get; set; }

        [Required]
        [Range(22, 55)]
        public int TeacherAge { get; set; }
    }
}
