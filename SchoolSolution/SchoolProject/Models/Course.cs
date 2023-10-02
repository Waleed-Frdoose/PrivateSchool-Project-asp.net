using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MinLength(8), MaxLength(50)]
        public string CourseName { get; set; }

        [Required]
        [Range(0, 30)]
        public int CourseCapicity { get; set; }

        [Required]
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
