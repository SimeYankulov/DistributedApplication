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
    public class BorrowController : Controller
    {
        // GET: BorrowController
        public async Task<ActionResult> IndexAsync()
        {
            ServiceReference.Service1Client service = new ServiceReference.Service1Client();

            List<BorrowVM> borrowVMs = new List<BorrowVM>();

            foreach (var item in await service.GetBorrowsAsync().ConfigureAwait(false))
            {
                borrowVMs.Add(new BorrowVM(item));
            }
            return View(borrowVMs);
        }

        // GET: BorrowController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BorrowController/Create
        public ActionResult Create()
        {

                return View();
            
        }

        // POST: BorrowController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BorrowVM borrowVM)
        {
            ServiceReference.Service1Client service = new ServiceReference.Service1Client();
            try
            {
                BorrowDTO borrowDTO = new BorrowDTO
                {
                    ID = borrowVM.ID,
                    StudentID = borrowVM.stuID,
                    BookID = borrowVM.bookID,
                    DateBorrowed = borrowVM.DateBorrowed,
                    DateReturned = borrowVM.DateReturned
                };
                service.PostBorrowAsync(borrowDTO);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: BorrowController/Edit/5
        public ActionResult Edit(int id)
        {
            ServiceReference.Service1Client service = new ServiceReference.Service1Client();

            BorrowVM borrowVM = new BorrowVM();

            var borrowDto = service.GetBorrowByIDAsync(id);
            borrowVM = new BorrowVM(borrowDto);

            return View(borrowVM);
        }

        // POST: BorrowController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BorrowVM borrowVM)
        {
            ServiceReference.Service1Client service = new ServiceReference.Service1Client();
            try
            {
                if (ModelState.IsValid)
                {
                    BorrowDTO borrowDTO = new BorrowDTO
                    {
                        ID = borrowVM.ID,
                        StudentID = borrowVM.stuID,
                        BookID = borrowVM.bookID,
                        DateBorrowed = borrowVM.DateBorrowed,
                        DateReturned = borrowVM.DateReturned

                    };
                    service.PostBorrowAsync(borrowDTO);
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

        // GET: BorrowController/Delete/5
        public ActionResult Delete(int id)
        {
            ServiceReference.Service1Client service = new ServiceReference.Service1Client();

            BorrowVM borrowVM = new BorrowVM();

            service.DeleteBorrowAsync(id);

            return RedirectToAction("Index");
        }

        // POST: BorrowController/Delete/5
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
