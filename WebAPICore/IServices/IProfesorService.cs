using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.Models;

namespace WebAPICore.IServices
{
    public interface IProfesorService
    {
        IEnumerable<Profesor> GetProfesor();
        Profesor GetProfesorById(int id);
        Profesor AddProfesor(Profesor profesor);
        Profesor UpdateProfesor(Profesor profesor);
        Profesor DeleteProfesor(int id);
    }
}
