using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
		[OperationContract]
		string GetData(int value);

		[OperationContract]
		CompositeType GetDataUsingDataContract(CompositeType composite);

		// TODO: Add your service operations here
		[OperationContract]
		List<StudentDTO> GetStudents();
		[OperationContract]
		StudentDTO GetStudentByID(int id);
		[OperationContract]
		string PostStudent(StudentDTO studentDTO);
		[OperationContract]
		string DeleteStudent(int id);

		[OperationContract]
		List<BookDTO> GetBooks();
		[OperationContract]
		BookDTO GetBookByID(int id);
		[OperationContract]
		string PostBook(BookDTO bookDTO);
		[OperationContract]
		string DeleteBook(int id);

		[OperationContract]
		List<BorrowDTO> GetBorrows();
		[OperationContract]
		BorrowDTO GetBorrowByID(int id);
		[OperationContract]
		string PostBorrow(BorrowDTO borrowDTO);
		[OperationContract]
		string DeleteBorrow(int id);
	}

	// Use a data contract as illustrated in the sample below to add composite types to service operations.
	// You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "SOAP.ContractType".
	[DataContract]
	public class CompositeType
	{
		bool boolValue = true;
		string stringValue = "Hello ";

		[DataMember]
		public bool BoolValue
		{
			get { return boolValue; }
			set { boolValue = value; }
		}

		[DataMember]
		public string StringValue
		{
			get { return stringValue; }
			set { stringValue = value; }
		}
	}
}

