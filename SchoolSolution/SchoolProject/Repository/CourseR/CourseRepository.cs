using SchoolProject.Context;
using SchoolProject.Models;

namespace SchoolProject.Repository.CourseR
{
    public class CourseRepository : ICourseRepository
    {

        private readonly AppDbContext dbContext;

        public CourseRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Course course)
        {
            if (course != null)
            {
                dbContext.Courses.Add(course);
                dbContext.SaveChanges();
            }
        }

        public void Delete(int courseId)
        {
            var course = Find(courseId);
            if (course != null)
            {
                dbContext.Courses.Remove(course);
                dbContext.SaveChanges();
            }
        }

        public void Edite(Course course)
        {
            dbContext.Courses.Update(course);
            dbContext.SaveChanges();
        }

        public Course Find(int courseId)
        {
            // find Course base id
            if (courseId > 0)
            {
                return dbContext.Courses.Where(x => x.CourseId == courseId).First();
            }
            return null!;
        }

        public List<Course> GetCourses()
        {
            return dbContext.Courses.ToList();
        }
    }
}
