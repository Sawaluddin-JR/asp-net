using Microsoft.EntityFrameworkCore;
using NgelatihKu.Models;

namespace NgelatihKu.Data.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly AppDbContext _context;
        public StudentsService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Student>> GetAll()
        {
            var result = await _context.Students.ToListAsync();
            return result;
        }
        public async Task<Student> GetByIdAsync(int id)
        {
            var result = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }
        public async Task<Student> UpdateAsync(int id, Student newStudent)
        {
            _context.Update(newStudent);
            await _context.SaveChangesAsync();
            return newStudent;
        }
        public async Task DeleteAsync(int id)
        {
            var result = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            _context.Students.Remove(result);
            await _context.SaveChangesAsync();
        }
    }
}
