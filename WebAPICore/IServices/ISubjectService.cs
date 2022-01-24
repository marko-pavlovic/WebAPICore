using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.Models;

namespace WebAPICore.IServices
{
    public interface ISubjectService
    {
        IEnumerable<Subject> GetSubject();
        Subject GetSubjectById(int id);
        Subject AddSubject(Subject subject);
        Subject UpdateSubject(Subject subject);
        Subject DeleteSubject(int id);

    }
}
