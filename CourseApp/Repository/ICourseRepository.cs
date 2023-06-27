using CourseApp.Context;
using CourseApp.Models.Course;

namespace CourseApp.Repository
{
    public interface ICourseRepository
    {

        Task<List<Course>> GetCourses();
        void  AddCourse(Course course);
        Task <Course> GetCourseById(int id);

        void UpdateCourse(Course course);

        void DeleteCourse(int id);

    }
}
