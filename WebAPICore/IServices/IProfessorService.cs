using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebAPICore.Models;

namespace WebAPICore.IServices
{
    public interface IProfessorService
    {
        IEnumerable<Professor> GetProfessor();
        Professor GetProfessorById(int id);
        Professor AddProfessor(Professor professor);
        Professor UpdateProfessor(Professor professor);
        Professor DeleteProfessor(int id);
        IEnumerable<Course> GetCourses(Professor professor);
        IEnumerable<Student> GetStudentsByCourse();
        Mark AddMark(int studentId, int courseId, int mark, DateTime date, string comment);
        HttpResponseMessage CreateSheet(int id);
        FileResult ExportToExcell();
    }
}
