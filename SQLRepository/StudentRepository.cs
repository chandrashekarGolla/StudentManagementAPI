
using System.Data;
using System.Reflection.Metadata.Ecma335;
using Common.Models;
using Microsoft.Data.SqlClient;

namespace SQLRepository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudents();
        //string GetStudentById(int id);
        //
        /*public class Student
        {
            public int Id { get; set; }
            public string? Name { get; set; }
        }*/
        /*public interface IStudentRepository
        {
            List<Student> GetStudents();
            String GetStudentById(int id);

            string DeleteStudentById(int id);
        }*/
    }
        public class StudentRepository : IStudentRepository
        {
            private readonly IDbConnection _connection;
            public StudentRepository(IDbConnection connection)
            {
                _connection = connection;
            }
            //string[] students = { "chandu", "ravi", "koushik", "akshay", "rayudu", "xyz" };
            /*private List<Student> students = new List<Student>
            {
                new Student { Id = 1, Name = "Chandu" },
                new Student { Id = 2, Name = "Ravi" },
                new Student { Id = 3, Name = "Koushik" },
                new Student { Id = 4, Name = "Akshay" },
                new Student { Id = 5, Name = "Rayudu" },
                new Student { Id = 6, Name = "XYZ" }
            };*/

            public async Task<List<Student>> GetStudents()
            {
                List<Student> students = new List<Student>();
                _connection.Open();

                string query = "Select Rollno,Name,Branch,Address from Students";
                SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Student student = new Student()
                        {
                            Rollno = Convert.ToString(reader["Rollno"]),
                            Name = Convert.ToString(reader["Name"]),
                            Branch = Convert.ToString(reader["Branch"]),
                            Address = Convert.ToString(reader["Address"])

                        };
                        students.Add(student);
                    }
                }
              

                return students;

            }

            /*public string GetStudentById(int id)
            {
                bool present = students.Contains(students[id]);
                if (!present)
                    return "-1";

                return students[id];
            }
            /*public List<Student> GetStudents()
            {
                return students;
            }

            public String GetStudentById(int id)
            {
                var student = students.FirstOrDefault(s => s.Id == id);
                if (student != null)
                {
    #pragma warning disable CS8603 // Possible null reference return.
                    return student.Name;
    #pragma warning restore CS8603 // Possible null reference return.
                }
                return "student not found";

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
            /*public string DeleteStudentById(int id)
            {
                var student = students.FirstOrDefault(s => s.Id == id);
                if (student != null)
                {
                    students.Remove(student);
                    return "Successfully deleted.";
                }
                return "Student not found.";
            }*/
        }
    }

