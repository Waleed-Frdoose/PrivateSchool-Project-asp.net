using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Models
{
    public class StudentCourse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentCourseId { get; set; }

        [Required]
        public int StudentId { get; set; }
        public Student? Student { get; set; }

        [Required]
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
