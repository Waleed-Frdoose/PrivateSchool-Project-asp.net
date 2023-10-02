using Microsoft.EntityFrameworkCore;
using SchoolProject.Context;
using SchoolProject.Repository.CourseR;
using SchoolProject.Repository.RoomR;
using SchoolProject.Repository.StudentR;
using SchoolProject.Repository.TeacherR;

namespace SchoolProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Dependance inject
            builder.Services.AddDbContext<AppDbContext>(option => 
                    option.UseSqlServer(builder.Configuration.GetSection("constr").Value));

            // مهم  
            builder.Services.AddTransient<IStudentRepository, StudentRepository>();
            builder.Services.AddTransient<ITeacherRepository, TeacherRepository>();
            builder.Services.AddTransient<IRoomRepository, RoomRepository>();
            builder.Services.AddTransient<ICourseRepository, CourseRepository>();

            /*
             AddTransient =>  رح يبعثلي نسخة جديدة دائما كل ما اطلب نسخة Dependance inject تعني انه 
             AddScoped => request رح يبعثلي نسخة جديدة في كل مرة بعمل 
             AddSingleton => فقط نسخة وحدة رح يتم استخدامها لكل اشي
             */


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
             
            // Route => النمط يلي بمشي عليه الريكويسك او كيف بنفهم الريكويست
            // Route بقدر اضيف اكثر من 
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Student}/{action=Index}/{id?}");

            app.Run();
        }
    }
}