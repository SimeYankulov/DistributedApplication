using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.ViewModels;
using ApplicationService.DTOs;

namespace WebApplication.Controllers
{
    public class StudentController : Controller
    {
        // GET: StudentController
        public async Task<ActionResult> IndexAsync()
        {
            ServiceReference.Service1Client service = new ServiceReference.Service1Client();

            List<StudentVM> studentVMs = new List<StudentVM>();
            
            foreach(var item in await service.GetStudentsAsync().ConfigureAwait(false))
            {
                studentVMs.Add(new StudentVM(item));
            }
                return View(studentVMs);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentVM studentVM)
        {
            ServiceReference.Service1Client service = new ServiceReference.Service1Client();
            try
            {
                StudentDTO studentDTO = new StudentDTO
                {
                    ID = studentVM.Id,
                    StuId = studentVM.StuId,
                    Name = studentVM.Name,
                    Surname = studentVM.Surname,
                    Class = studentVM.Class,
                    DOB = studentVM.DOB,
                    Gender = studentVM.Gender,
                    AverageGrade = studentVM.AverageGrade

                };
                service.PostStudentAsync(studentDTO);
                return RedirectToAction("Index");
  
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            ServiceReference.Service1Client service = new ServiceReference.Service1Client();

            StudentVM studentVM = new StudentVM();

            var studentDto = service.GetStudentByIDAsync(id);
            studentVM = new StudentVM(studentDto);

            return View(studentVM);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentVM studentVM)
        {
            ServiceReference.Service1Client service = new ServiceReference.Service1Client();
            try
            {
             
                    StudentDTO studentDTO = new StudentDTO
                    {
                        ID = studentVM.Id,
                        StuId = studentVM.StuId,
                        Name = studentVM.Name,
                        Surname = studentVM.Surname,
                        Class = studentVM.Class,
                        Gender = studentVM.Gender,
                        DOB = studentVM.DOB,
                        AverageGrade = studentVM.AverageGrade
                    };
                    service.PostStudentAsync(studentDTO);
                
                RedirectToAction("Index");
                //ViewBag.Students = LoadDataUtilities.LoadStudentsData();
                return View();
            }

            catch
            {
                // ViewBag.Students = LoadDataUtilities.LoadStudentsData();
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            
                ServiceReference.Service1Client service = new ServiceReference.Service1Client();

                StudentVM studentVM = new StudentVM();

                service.DeleteStudentAsync(id);

                return RedirectToAction("Index");
            
        }
        /* POST: StudentController/Delete/5
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
        }*/
    }
}
