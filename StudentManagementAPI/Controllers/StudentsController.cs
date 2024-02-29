using Microsoft.AspNetCore.Mvc;
using StudentService;
using Common.Models;
namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudent _student;

        public StudentsController(IStudent student)
        {
            _student = student;
        }

        [HttpGet]
        [Route("GetAllStudents")]
        public ActionResult<Task<List<Student>>> GetStudents()
        {
            return _student.GetStudents();
        }

        /*[HttpGet]
        [Route("GetStudentById")]
        public ActionResult<Student> GetStudentById(int id)
        {
            string student = _student.GetStudentById(id);
            if (student == "-1")
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpDelete]
        [Route("DeleteStudentById")]
        public string DeleteStudentById(int id)
        {
            var status = _student.DeleteStudentById(id);
            return status;

        }
        /*[HttpGet]
        [Route("GetAllStudents")]
        public ActionResult<List<Student>> GetStudents()
        {
            var students = _student.GetStudents();
            return Ok(students);
        }

        [HttpGet]
        [Route("GetStudentById")]
        public ActionResult<string> GetStudentById(int id)
        {
            var student = _student.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpDelete]
        [Route("DeleteStudentById")]
        public ActionResult<string> DeleteStudentById(int id)
        {
            var result = _student.DeleteStudentById(id);
            return Ok(result);
        }*/


    }
}
