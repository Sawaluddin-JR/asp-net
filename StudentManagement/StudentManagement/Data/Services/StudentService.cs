using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.Data.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;
        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            var result = await _context.Students.ToListAsync();
            return result;
        }
        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Students.FirstOrDefaultAsync(n => n.Id == id);
            _context.Students.Remove(result);
            await _context.SaveChangesAsync();
        }


        public async Task<Student> GetByIdAsync(int id)
        {
            var result = await _context.Students.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public async Task<Student> UpdateAsync(int id, Student newStudent)
        {
            _context.Update(newStudent);
            await _context.SaveChangesAsync();
            return newStudent;
        }
    }
}
