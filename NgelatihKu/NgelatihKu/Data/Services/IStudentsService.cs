using NgelatihKu.Models;

namespace NgelatihKu.Data.Services
{
    public interface IStudentsService
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetByIdAsync(int id);
        Task AddAsync(Student student);
        Task<Student> UpdateAsync(int id, Student newStudent);
        Task DeleteAsync(int id);
    }
}
