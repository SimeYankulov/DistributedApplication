using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.ViewModels
{
    public class BorrowVM
    {
        public int ID { get; set; }
        public int bookID { get; set; }
        public int stuID { get; set; }
        public DateTime? DateBorrowed { get; set; }
        public DateTime? DateReturned { get; set; }

        public BorrowVM(Task<BorrowDTO> borrowDto) { }
        public BorrowVM(BorrowDTO borrowDTO)
        {
            ID = borrowDTO.ID;
            DateBorrowed = borrowDTO.DateBorrowed;
            DateReturned = borrowDTO.DateReturned;

            stuID = borrowDTO.StudentID;
            bookID = borrowDTO.BookID;
        }

        public BorrowVM()
        {
        }
    }
}
