using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOAP
{
    public class BorrowService : IBorrowService
    {
        private BorrowManagementService borrowService = new BorrowManagementService();

        public string DeleteBorrow(int id)
        {
            if (borrowService.Delete(id))
            {
                return "Borrow has been deleted!";
            }
            else
            {
                return "Book has not been deleted!";
            }
        }

        public List<BorrowDTO> GetBorrows()
        {
            return borrowService.Get();
        }

        public BorrowDTO GetBorrowsByID(int id)
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
    }
}
