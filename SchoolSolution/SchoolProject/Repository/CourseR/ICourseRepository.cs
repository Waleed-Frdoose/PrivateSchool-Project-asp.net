using SchoolProject.Models;

namespace SchoolProject.Repository.CourseR
{
    public interface ICourseRepository
    {
        public List<Course> GetCourses();

        public void Create(Course course);

        public void Edite(Course course);

        public void Delete(int courseId);

        public Course Find(int courseId);
    }
}
