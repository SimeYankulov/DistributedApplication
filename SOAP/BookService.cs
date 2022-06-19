using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAP
{
    public class BookService : IBookService
    {
        private BookManagementService bookService = new BookManagementService();

        public string DeleteBook(int id)
        {
            if(bookService.Delete(id))
            {
                return "Book has been deleted!";

            }
            else
            {
                return "Book has not been deleted!";
            }
        }

        public List<BookDTO> GetBooks()
        {
            return bookService.Get();
        }

        public BookDTO GetBooksByID(int id)
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
    }
}
