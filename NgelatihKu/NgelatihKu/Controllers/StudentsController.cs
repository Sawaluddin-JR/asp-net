using Microsoft.AspNetCore.Mvc;
using NgelatihKu.Data.Services;
using NgelatihKu.Models;

namespace NgelatihKu.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentsService _service;

        public StudentsController(IStudentsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }

        //Get : Students/Create
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

        //Get : Students/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var studentDetails = await _service.GetByIdAsync(id);

            if (studentDetails == null) return View("NotFound");
            return View(studentDetails);
        }

        //Get : Students/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var studentDetails = await _service.GetByIdAsync(id);

            if (studentDetails == null) return View("NotFound");
            return View(studentDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Prodi,Address")] Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            await _service.UpdateAsync(id, student);
            return RedirectToAction(nameof(Index));
        }

        //Get : /Students/Delete/Id
        public async Task<IActionResult> Delete(int id)
        {
            var studentDetails = await _service.GetByIdAsync(id);
            if (studentDetails == null) return View("NotFound");
            return View(studentDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentDetails = await _service.GetByIdAsync(id);
            if (studentDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
