using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Protocol.Core.Types;
using SchoolProject.Context;
using SchoolProject.Models;
using System;

namespace SchoolProject.Repository.StudentR
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext dbContext;

        public StudentRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Student> GetStudents()
        {
            return dbContext.Students.ToList();
        }

        public void Create(Student student)
        {
            if (student != null)
            {
                dbContext.Students.Add(student);
                dbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var student = Find(id);
            if (student != null)
            {
                dbContext.Students.Remove(student);
                dbContext.SaveChanges();
            }
        }

        public void Register(int studentId, int courseId)
        {
            var student = dbContext.Students.FirstOrDefault(x => x.StudentId == studentId);
            var course = dbContext.Courses.FirstOrDefault(x => x.CourseId == courseId);

            if (student != null && course != null) 
            {
                var studentCourse = new StudentCourse { StudentId = studentId, CourseId = courseId};
                dbContext.StudentCourses.Add(studentCourse);
                dbContext.SaveChanges();
            }
        }

        public Student Find(int id)
        {
            // find Student base id
            if (id > 0)
            {
                return dbContext.Students.Where(x => x.StudentId == id).First();
            }
            return null!;
        }

        public void Edit(Student student)
        {
            dbContext.Students.Update(student);
            dbContext.SaveChanges();
        }

        public void Uplodephoto(Student student, IFormFile studentPhoto, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            try
            {
                var wwwRootPath = environment.WebRootPath + "/StudentPictures/";// وصلت للملف يلي بدي احفظ فيه الصور

                //StudentPictures بدي اخذ اسم الفايل واخزنه جوا الملف 

                Guid guid = Guid.NewGuid(); // خاص لكل واحد يكون مختلف عن الاخر id بيعطيني 

                string fullPath = Path.Combine(wwwRootPath, guid + studentPhoto.FileName); // عملت الباث يلي رح يتخزن فيه مه اسمه

                // عملية الحفظ    
                using (var fillStream = new FileStream(fullPath, FileMode.Create))
                {
                    // يلي رح يعملنا انشاء له في الموقع يلي حددناه fillStream رح ياخذ الملف ويعمله كوبي ع 
                    studentPhoto.CopyTo(fillStream);
                }

                student.StudentPhoto = guid + studentPhoto.FileName;

                
            }
            catch
            {
                
            }
        }
    }
}
