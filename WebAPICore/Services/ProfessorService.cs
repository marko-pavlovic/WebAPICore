using Aspose.Cells;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebAPICore.DbModels;

namespace WebAPICore.Services
{
    public class ProfessorService
    {
        APICoreDBContext _dbContext;
        APICoreDBContext _dbContext2;
        public ProfessorService(APICoreDBContext db, APICoreDBContext db2)
        {
            _dbContext = db;
            _dbContext2 = db2;
        }

        public Mark AddMark(int studentId, int courseId, int mark, DateTime date, string comment)
        {
            Mark markm = new Mark();
            markm.StudentId = studentId;
            markm.CourseId = courseId;
            markm.Mark1 = mark;
            markm.Date = date; 
            markm.Comment = comment;
            _dbContext.Mark.Add(markm);
            _dbContext.SaveChanges();

            return markm;
        }

        public bool EditMark(int Id, int studentId, int courseId, int mark, DateTime date, string comment)
        {
            //var comm = _dbContext.Mark.FirstOrDefault(x => x.Id == Id).Comment;   // ne znam kako
            if (comment == null)
            {
                return false;
            }
            else
            {
                Mark markm = new Mark();
                markm.Id = Id;
                markm.StudentId = studentId;
                markm.CourseId = courseId;
                markm.Mark1 = mark;
                markm.Date = date;
                markm.Comment = comment;
                _dbContext.Entry(markm).State = EntityState.Modified;
                _dbContext.SaveChanges();

                //UpdateAverageRating(studentId);

                return true;
            }
            
        }

        public Professor AddProfessor(Professor professor)
        {
            if (professor != null)
            {
                _dbContext.Professor.Add(professor);
                _dbContext.SaveChanges();
                return professor;
            }
            return null;
        }

        public Professor DeleteProfessor(int id)
        {
            var professor = _dbContext.Professor.FirstOrDefault(x => x.Id == id);
            _dbContext.Entry(professor).State = EntityState.Deleted;
            _dbContext.SaveChanges();
            return professor;
        }

        public IEnumerable<Course> GetCourses(Professor professor)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Professor> GetProfessor()
        {
            var professor = _dbContext.Professor.ToList();
            return professor;
        }

        public Professor GetProfessorById(int id)
        {
            var professor = _dbContext.Professor.FirstOrDefault(x => x.Id == id);
            return professor;
        }

        public IEnumerable<Student> GetStudentsByCourse()
        {
            throw new NotImplementedException();
        }

        public Professor UpdateProfessor(Professor professor)
        {
            _dbContext.Entry(professor).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return professor;
        }

        public IEnumerable<Course> TeachingCourses(int id)
        {
            var courses = _dbContext.Course.Where(x => x.ProfessorId == id).ToList();
            return courses;
        }

        public IEnumerable<Student> GetAllTeachingStudents(int id)
        {
            var students = _dbContext.ProfessorCourse
                .Where(pc => pc.ProfessorId == id)
                .Select(pc => new
                {
                    Students = pc.Course.StudentCourse.Select(sc => sc.Student)
                })
                .SelectMany(pc => pc.Students)
                .Distinct() //ukoiko ne zelimo duplikate
                .AsEnumerable();

            return students;
        }

        public Dictionary<int?, IEnumerable<Student>> GetAllStudentsPerCourse(int id)
        {
            var students = _dbContext.ProfessorCourse
                .Where(pc => pc.ProfessorId == id)
                .ToDictionary(
                    pc => pc.CourseId,
                    pc => pc.Course.StudentCourse.Select(sc => sc.Student));

            return students;
        }

        public decimal AverageRating(IEnumerable<Mark> marks)
        {
            decimal ar = 0;
            foreach (var mark in marks)
                ar += (decimal)mark.Mark1;
              
            ar /= marks.Count();
            return ar;
            //var marks = _dbContext.Mark.Where(x => x.StudentId == studentId);
            //decimal ar = 0;
            //foreach (var mark in marks)
            //{
            //    ar += (decimal)mark.Mark1;
            //    ar /= marks.Count();
            //}
        }

        public IEnumerable<Student> GetStudentsByCourse(int courseId)
        {
            var students = _dbContext.StudentCourse
                .Where(sc => sc.CourseId == courseId)

                .Select(sc => sc.Student)
                .AsEnumerable();

            return students;
        }

        public FileContentResult ExportXlsx(Course course)
        {
            var studentsWithAvgMarks = _dbContext.StudentCourse
                .Where(sc => sc.CourseId == course.Id)
                .Select(sc => new 
                {
                    sc.Student,
                    AvgMark = sc.Student.Mark
                        .Where(m => m.CourseId == course.Id)
                        .Average(m => m.Mark1)
                })
                .AsEnumerable();


            Workbook temp = new Workbook();
            Worksheet ws = temp.Worksheets[0];
            //Cell cell = ws.Cells["A1"];
            
            Cell cell = ws.Cells[0, 0];
            cell.PutValue("Name");

            cell = ws.Cells[0, 1];
            cell.PutValue("Year");

            cell = ws.Cells[0, 2];
            cell.PutValue("Average rating");

            foreach (var s in studentsWithAvgMarks)
            {
                cell = ws.Cells[1, 0];
                cell.PutValue(s.Student.Name + " " + s.Student.Surname);

                cell = ws.Cells[1, 1];
                cell.PutValue(s.Student.Year);

                cell = ws.Cells[1, 2];
                cell.PutValue(s.AvgMark);

                if(s.AvgMark >= 2.50)
                {
                    cell = ws.Cells[1, 3];
                    cell.PutValue("Passed");
                }
            }


            temp.Save("report.xlsx", SaveFormat.Xlsx);

            var path = Path.Combine(Directory.GetCurrentDirectory(), "report.xlsx");
            var file = new FileInfo(path);
            var bytes = File.ReadAllBytes(file.FullName);
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            var fileContentResult = new FileContentResult(bytes, contentType)
            {
                FileDownloadName = file.Name
            };

            return fileContentResult;

        }
    }
}
