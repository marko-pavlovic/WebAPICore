using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.DbModels;

namespace WebAPICore.Services
{
    public class StudentService
    {
        APICoreDBContext _dbContext;
        public StudentService(APICoreDBContext db)
        {
            _dbContext = db;
        }

        public int AddStudent(Student student)
        {
            _dbContext.Student.Add(student);
            _dbContext.SaveChanges();

            return student.Id;
        }

        public bool DeleteStudent(Student student)
        {
            _dbContext.Remove(student);
            _dbContext.SaveChanges();

            return true;
        }

        public IEnumerable<Student> GetStudent()
        {
            var student = _dbContext.Student
                .AsEnumerable();

            return student;
        }

        public Student GetStudentById(int id)
        {
            var student = _dbContext.Student
                .FirstOrDefault(s => s.Id == id);

            return student;
        }

        public bool UpdateStudent(Student student)
        {
            _dbContext.Update(student);
            _dbContext.SaveChanges();

            return true;
        }

        public IEnumerable<Course> AttendingCourses(int id)
        {
            var courses = _dbContext.StudentCourse
                .Where(sc => sc.StudentId == id)
                .Select(sc => sc.Course)
                .AsEnumerable();

            return courses;
        }

        public async Task<IEnumerable<Course>> AttendingCoursesAsync(int id)
        {
            var courses = await _dbContext.StudentCourse
                .Where(sc => sc.StudentId == id)
                .Select(sc => sc.Course)
                .ToListAsync();

            return courses;
        }

        public IEnumerable<Mark> Marks(int id, int cId)
        {
            var marks = _dbContext.Mark
                .Where(ss => ss.StudentId == id)
                .Where(sc => sc.CourseId == cId)
                .AsEnumerable();

            return marks;
        }
    }
}
