using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLRepository;
using Common.Models;
namespace StudentService
{
    

    public class StudentServices : IStudent
    {
        public readonly IStudentRepository _studentRepository;

        public StudentServices(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Task<List<Student>> GetStudents()
        {
            return _studentRepository.GetStudents();
        }
        

        /*public string GetStudentById(int id)
        {
            return _studentRepository.GetStudentById(id);
        }
        

        public string DeleteStudentById(int id)
        {
            return _studentRepository.DeleteStudentById(id);
        }*/
    }
}
