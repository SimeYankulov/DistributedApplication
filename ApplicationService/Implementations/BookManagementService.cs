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
    public class BookManagementService
    {
		public List<BookDTO> Get()
		{
			List<BookDTO> booksDTO = new List<BookDTO>();

			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				foreach (var item in unitOfWork.BookRepository.Get())
				{
					BookDTO bookDTO = new BookDTO();

					bookDTO.ID = item.ID;
					bookDTO.Name = item.Name;
					bookDTO.Author = item.Author;
					bookDTO.Pages = item.Pages;
					bookDTO.Type = item.Type;

					booksDTO.Add(bookDTO);

				}
			}

			return booksDTO;
		}

		public BookDTO GetById(int id)
		{
			BookDTO bookDTO = new BookDTO();

			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				Book book = unitOfWork.BookRepository.GetByID(id);

				if (book != null)
				{

					bookDTO.ID = book.ID;
					bookDTO.Name = book.Name;
					bookDTO.Author = book.Author;
					bookDTO.Pages = book.Pages;
					bookDTO.Type = book.Type;
				}

				return bookDTO;
			}
		}

		public bool Save(BookDTO bookDTO)
		{
			Book book = new Book
			{
				Name = bookDTO.Name,
				Author = bookDTO.Author,
				Pages = bookDTO.Pages,
				Type = bookDTO.Type
			};

			try
			{
				using (UnitOfWork unitOfWork = new UnitOfWork())
				{
					unitOfWork.BookRepository.Insert(book);
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
					unitOfWork.BookRepository.Delete(id);
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
