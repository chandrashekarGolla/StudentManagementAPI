using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
namespace StudentService
{
    public interface IStudent
    {
        Task<List<Student>> GetStudents();
       // string GetStudentById(int id);
        //string DeleteStudentById(int id);
    }
    /*public interface IStudent
    {
        List<Student> GetStudents();
        string GetStudentById(int id);
        
        string DeleteStudentById(int id);
    }*/
}
