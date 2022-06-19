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
    public interface IBorrowService
    {
        [OperationContract]
        List<BorrowDTO> GetBorrows();
        [OperationContract]
        BorrowDTO GetBorrowsByID(int id);
        [OperationContract]
        string PostBorrow(BorrowDTO borrowDTO);
        [OperationContract]
        string DeleteBorrow(int id);
    }
}
