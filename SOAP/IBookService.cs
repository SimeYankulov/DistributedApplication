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
    public interface IBookService
    {
        [OperationContract]
        List<BookDTO> GetBooks();
        [OperationContract]
        BookDTO GetBooksByID(int id);
        [OperationContract]
        string PostBook(BookDTO bookDTO);
        [OperationContract]
        string DeleteBook(int id);
    }
}
