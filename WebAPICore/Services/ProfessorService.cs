using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.Models;
using Aspose.Cells;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using ClosedXML.Excel;

namespace WebAPICore.Services
{
    public class ProfessorService
    {
        APICoreDBContext _dbContext;
        public ProfessorService(APICoreDBContext db)
        {
            _dbContext = db;
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

        public HttpResponseMessage CreateSheet(int id)
        {
            Workbook temp = new Workbook();
            Worksheet ws = temp.Worksheets[0];
            Cell cell = ws.Cells["A1"];

            // Input the "Hello World!" text into the "A1" cell.
            cell.PutValue("Hello World!");

            // Used to test the excel populates correctly
            temp.Save("Excel.xlsx", SaveFormat.Xlsx);

            MemoryStream ms = new MemoryStream();
            temp.Save(ms, SaveFormat.Xlsx);
            byte[] bytes = ms.ToArray();

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new ByteArrayContent(bytes);
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = "fajl" + ".xlsx";
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("Application/x-msexcel");
            
             
            return response;
        }

        public FileResult ExportToExcell()
        {
            using (XLWorkbook wb = new XLWorkbook()) //Install ClosedXml from Nuget for XLWorkbook  
            {
                var worksheet = wb.Worksheets.Add("Sample Sheet");
                worksheet.Cell("A1").Value = "Hello World!";
                worksheet.Cell("A2").FormulaA1 = "=MID(A1, 7, 5)";
                wb.SaveAs("HelloWorld.xlsx");
                using (MemoryStream stream = new MemoryStream()) //using System.IO;  
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ExcelFile.xlsx");
                }
            }
        }

        private FileResult File(byte[] vs, string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
}
