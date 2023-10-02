using SchoolProject.Context;
using SchoolProject.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace SchoolProject.Repository.StudentR
{
    public interface IStudentRepository
    {
        public List<Student> GetStudents();

        public void Create(Student student);

        public void Delete(int id);

        public void Edit(Student student);

        public void Register(int studentId, int courseId);

        public Student Find(int id);

        public void Uplodephoto(Student student, IFormFile studentPhoto, IHostingEnvironment environment);
    }
}
