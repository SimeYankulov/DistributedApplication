using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationService.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class BookController : Controller
    {
        // GET: BookController
        public async Task<ActionResult> IndexAsync()
        {
            ServiceReference.Service1Client service = new ServiceReference.Service1Client();

            List<BookVM> bookVMs = new List<BookVM>();

            foreach (var item in await service.GetBooksAsync().ConfigureAwait(false))
            {
                bookVMs.Add(new BookVM(item));
            }
            return View(bookVMs);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookVM bookVM)
        {
            ServiceReference.Service1Client service = new ServiceReference.Service1Client();
            try
            {
                BookDTO bookDTO = new BookDTO
                {
                    ID = bookVM.Id,
                    Name = bookVM.Name,
                    Pages = bookVM.Pages,
                    Author = bookVM.Author,
                    Type = bookVM.Type
                };
                service.PostBookAsync(bookDTO);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            ServiceReference.Service1Client service = new ServiceReference.Service1Client();

            BookVM bookVM = new BookVM();

            var bookDto = service.GetBookByIDAsync(id);
            bookVM = new BookVM(bookDto);

            return View(bookVM);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookVM bookVM)
        {
            ServiceReference.Service1Client service = new ServiceReference.Service1Client();
            try
            {
                if (ModelState.IsValid)
                {
                    BookDTO bookDTO = new BookDTO
                    {
                        ID = bookVM.Id,
                        Name = bookVM.Name,
                        Pages = bookVM.Pages,
                        Author = bookVM.Author,
                        Type = bookVM.Type

                    };
                    service.PostBookAsync(bookDTO);
                }
                RedirectToAction("Index");
                //ViewBag.Books = LoadDataUtilities.LoadStudentsData();
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            ServiceReference.Service1Client service = new ServiceReference.Service1Client();

            BookVM bookVM = new BookVM();

            service.DeleteBookAsync(id);

            return RedirectToAction("Index");
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}
