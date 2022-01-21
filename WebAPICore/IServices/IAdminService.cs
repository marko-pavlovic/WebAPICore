using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.Models;

namespace WebAPICore.IServices
{
    public interface IAdminService
    {
        IEnumerable<Kurs> GetKurs();
        Kurs AddKurs(Kurs kurs);
        IEnumerable<Student> GetStudent();
        Student AddStudent(Student student);
    }
}
