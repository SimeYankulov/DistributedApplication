using ApplicationService.DTOs;
using Library.Entities;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementations
{
    public class StudentManagementService
    {
		public List<StudentDTO> Get()
		{
			List<StudentDTO> studentsDTO = new List<StudentDTO>();

			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				foreach (var item in unitOfWork.StudentRepository.Get())
				{
					StudentDTO studentDTO = new StudentDTO();

					studentDTO.ID = item.ID;
					studentDTO.StuId = item.StuId;
					studentDTO.Name = item.Name;
					studentDTO.Surname = item.Surname;
					studentDTO.Class = item.Class;
					studentDTO.DOB = item.DOB;
					studentDTO.Gender = item.Gender;
					studentDTO.AverageGrade = item.AverageGrade;

					studentsDTO.Add(studentDTO);

				}
			}

			return studentsDTO;
		}

		public StudentDTO GetById(int id)
		{
			StudentDTO studentDTO = new StudentDTO();

			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				Student student = unitOfWork.StudentRepository.GetByID(id);

				if (student != null)
				{
					studentDTO.StuId = student.StuId;
					studentDTO.Name = student.Name;
					studentDTO.Surname = student.Surname;
					studentDTO.Class = student.Class;
					studentDTO.DOB = student.DOB;
					studentDTO.Gender = student.Gender;
					studentDTO.AverageGrade = student.AverageGrade;
				}

				return studentDTO;
			}
		}

		public bool Save(StudentDTO studentDTO)
		{
			Student student = new Student
			{
				StuId = studentDTO.StuId,
				Name = studentDTO.Name,
				Surname = studentDTO.Surname,
				Class = studentDTO.Class,
				DOB = studentDTO.DOB,
				Gender = studentDTO.Gender,
				AverageGrade = studentDTO.AverageGrade
				
			};

			try
			{
				using (UnitOfWork unitOfWork = new UnitOfWork())
				{
					unitOfWork.StudentRepository.Insert(student);
					unitOfWork.Save();
				}

				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Delete(int id)
		{
			try
			{
				using (UnitOfWork unitOfWork = new UnitOfWork())
				{
					unitOfWork.StudentRepository.Delete(id);
					unitOfWork.Save();
				}
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
