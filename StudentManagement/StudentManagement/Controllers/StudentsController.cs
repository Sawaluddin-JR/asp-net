using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data.Services;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _service;
        public StudentsController(IStudentService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }

        public async Task<IActionResult> Details(int id)
        {
            var dStudent = await _service.GetByIdAsync(id);
            return View(dStudent);
        }

        //Get : /Students/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Prodi,Address")] Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            await _service.AddAsync(student);
            return RedirectToAction(nameof(Index));
        }

        //Get : /Students/Edit/Id
        public async Task<IActionResult> Edit(int id)
        {
            var dStudent = await _service.GetByIdAsync(id);
            return View(dStudent);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Prodi,Address")] Student newStudent)
        {
            if (!ModelState.IsValid)
            {
                return View(newStudent);
            }
            await _service.UpdateAsync(id, newStudent);
            return RedirectToAction(nameof(Index));
        }

        //Get : /Students/Delete/Id
        public async Task<IActionResult> Delete(int id)
        {
            var dStudent = await _service.GetByIdAsync(id);
            return View(dStudent);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
