using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
		public string GetData(int value)
		{
			return string.Format("You entered: {0}", value);
		}

		public CompositeType GetDataUsingDataContract(CompositeType composite)
		{
			if (composite == null)
			{
				throw new ArgumentNullException("composite");
			}
			if (composite.BoolValue)
			{
				composite.StringValue += "Suffix";
			}
			return composite;
		}

		// call the service
		private StudentManagementService studentService = new StudentManagementService();
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

		private BookManagementService bookService = new BookManagementService();
		public List<BookDTO> GetBooks()
		{
			return bookService.Get();
		}

		public BookDTO GetBookByID(int id)
		{
			return bookService.GetById(id);
		}
		public string PostBook(BookDTO bookDTO)
		{
			if (bookService.Save(bookDTO))
			{
				return "Book has been saved!";
			}
			else
			{
				return "Book has not been saved!";
			}
		}
		public string DeleteBook(int id)
		{
			if (bookService.Delete(id))
			{
				return "Book has been deleted!";
			}
			else
			{
				return "Book has not been deleted!";
			}
		}
		private BorrowManagementService borrowService = new BorrowManagementService();
		public List<BorrowDTO> GetBorrows()
		{
			return borrowService.Get();
		}

		public BorrowDTO GetBorrowByID(int id)
		{
			return borrowService.GetById(id);
		}
		public string PostBorrow(BorrowDTO borrowDTO)
		{
			if (borrowService.Save(borrowDTO))
			{
				return "Borrow has been saved!";
			}
			else
			{
				return "Borrow has not been saved!";
			}
		}
		public string DeleteBorrow(int id)
		{
			if (borrowService.Delete(id))
			{
				return "Borrow has been deleted!";
			}
			else
			{
				return "Borrow has not been deleted!";
			}
		}
    }
}

