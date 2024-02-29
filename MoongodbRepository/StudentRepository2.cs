using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongodbRepository
{
    public interface IStudentRepository
    {
        string[] GetStudents();
        string GetStudentById(int id);
        string DeleteStudentById(int id);
    }
    public class StudentRepository2 : IStudentRepository
    {

        string[] students = { "chandu", "ravi", "koushik", "akshay", "rayudu", "xyz","VNR" };

        public string[] GetStudents()
        {
            return students;
        }

        public string GetStudentById(int id)
        {
            bool present = students.Contains(students[id]);
            if (!present)
                return "-1";

            return students[id];
        }

        public string DeleteStudentById(int id)
        {
            bool student = students.Contains(students[id]);
            if (student)
            {
                students = students.Where(s => s != students[id]).ToArray();
                return "scucessfully deleted";
            }
            else
                return "student doesnt exists";
        }
    }
}
