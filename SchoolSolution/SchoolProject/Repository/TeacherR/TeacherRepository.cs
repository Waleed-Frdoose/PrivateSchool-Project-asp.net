using SchoolProject.Context;
using SchoolProject.Models;

namespace SchoolProject.Repository.TeacherR
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext dbContext;

        public TeacherRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Create(Teacher teacher)
        {
            if (teacher != null)
            {
                dbContext.Teachers.Add(teacher);
                dbContext.SaveChanges();
            }
        }

        public void Delete(int teacherId)
        {
            var teacher = Find(teacherId);
            if (teacher != null)
            {
                dbContext.Teachers.Remove(teacher);
                dbContext.SaveChanges();
            }
        }

        public void Edite(Teacher teacher)
        {
            dbContext.Teachers.Update(teacher);
            dbContext.SaveChanges();
        }

        public Teacher Find(int teacherId)
        {
            // find Teacher base id
            if (teacherId > 0)
            {
                return dbContext.Teachers.Where(x => x.TeacherId == teacherId).First();
            }
            return null!;
        }

        public List<Teacher> GetTeachers()
        {
            return dbContext.Teachers.ToList();
        }
    }
}
