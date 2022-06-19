using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.ViewModels
{
    public class BookVM
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public string Author { get; set; }
        public string Type { get; set; }

        public BookVM(Task<BookDTO> bookDto) { }
        public BookVM(BookDTO bookDTO)
        {
            Id = bookDTO.ID;
            Name = bookDTO.Name;
            Pages = bookDTO.Pages;
            Author = bookDTO.Author;
            Type = bookDTO.Type;
        }

        public BookVM() { }
    }
}
