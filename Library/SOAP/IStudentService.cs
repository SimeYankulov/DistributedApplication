using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SOAP
{
		[ServiceContract]
		public interface IStudentService
		{
			// TODO: Add your service operations here
			[OperationContract]
			List<StudentDTO> GetStudents();
			[OperationContract]
			StudentDTO GetStudentByID(int id);
			[OperationContract]
			string PostStudent(StudentDTO studentDTO);
			[OperationContract]
			string DeleteStudent(int id);
		}
}
