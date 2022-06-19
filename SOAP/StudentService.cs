using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAP
{
    public class StudentService : IStudentService
    {
        private StudentManagementService studentService = new StudentManagementService();

        public string DeleteStudent(int id)
        {
            if (studentService.Delete(id))
            {
                return "Student has been deleted!";
            }
            else
            {
                return "Student has not been deleted!";
            }
        }

        public List<StudentDTO> GetStudents()
        {
            return studentService.Get();
        }

        public StudentDTO GetStudentByID(int id)
        {
            return studentService.GetById(id);
        }

        public string PostStudent(StudentDTO studentDTO)
        {
            if (studentService.Save(studentDTO))
            {
                return "Student has been saved!";
            }
            else
            {
                return "Student has not been saved!";
            }
        }
    }
}

