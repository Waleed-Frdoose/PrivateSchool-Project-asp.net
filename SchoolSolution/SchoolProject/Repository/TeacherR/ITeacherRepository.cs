using SchoolProject.Models;

namespace SchoolProject.Repository.TeacherR
{
    public interface ITeacherRepository
    {
        public List<Teacher> GetTeachers();

        public void Create(Teacher teacher);

        public void Edite(Teacher teacher);

        public void Delete(int teacherId);

        public Teacher Find(int teacherId);
    }
}
