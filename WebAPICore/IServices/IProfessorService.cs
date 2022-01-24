using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
