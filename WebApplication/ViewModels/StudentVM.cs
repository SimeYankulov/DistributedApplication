using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.ViewModels
{
    public class StudentVM
    {
        public int Id { get; set; }
        public int StuId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Class { get; set; }
        public DateTime? DOB { get; set; }
        public string Gender { get; set; }
        public float AverageGrade { get; set; }

        public StudentVM(Task<StudentDTO> studentDto) { 
        
        }
        public StudentVM() { }
        public StudentVM(StudentDTO studentDto)
        {
            Id = studentDto.ID;
            StuId = studentDto.StuId;
            Name = studentDto.Name;
            Surname = studentDto.Surname;
            Class = studentDto.Class;
            DOB = studentDto.DOB;
            Gender = studentDto.Gender;
            AverageGrade = studentDto.AverageGrade;
        }
    }
}
