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
    public class BorrowManagementService
    {
			public List<BorrowDTO> Get()
			{
				List<BorrowDTO> borrowsDTO = new List<BorrowDTO>();

				using (UnitOfWork unitOfWork = new UnitOfWork())
				{
					foreach (var item in unitOfWork.BorrowRepository.Get())
					{
						BorrowDTO borrowDTO = new BorrowDTO();

						borrowDTO.ID = item.ID;
						borrowDTO.StudentID = item.StudentID;
						borrowDTO.BookID = item.BookID;
						borrowDTO.DateBorrowed = item.DateBorrowed;
						borrowDTO.DateReturned = item.DateReturned;

						borrowsDTO.Add(borrowDTO);

					}
				}

				return borrowsDTO;
			}

			public BorrowDTO GetById(int id)
			{
				BorrowDTO borrowDTO = new BorrowDTO();

				using (UnitOfWork unitOfWork = new UnitOfWork())
				{
					Borrow borrow = unitOfWork.BorrowRepository.GetByID(id);

					if (borrow != null)
					{
						borrowDTO.ID = borrow.ID;
						borrowDTO.StudentID = borrow.StudentID;
						borrowDTO.BookID = borrow.BookID;
						borrowDTO.DateBorrowed = borrow.DateBorrowed;
						borrowDTO.DateReturned = borrow.DateReturned;
					}

					return borrowDTO;
				}
			}

			public bool Save(BorrowDTO borrowDTO)
			{
				Borrow borrow = new Borrow
				{
					StudentID = borrowDTO.StudentID,
					BookID = borrowDTO.BookID,
					DateBorrowed = borrowDTO.DateBorrowed,
					DateReturned = borrowDTO.DateReturned
				};

				try
				{
					using (UnitOfWork unitOfWork = new UnitOfWork())
					{
						unitOfWork.BorrowRepository.Insert(borrow);
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
						unitOfWork.BorrowRepository.Delete(id);
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



