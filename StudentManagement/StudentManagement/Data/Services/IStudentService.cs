using StudentManagement.Models;

namespace StudentManagement.Data.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAll();
        Task AddAsync(Student student);
        Task<Student> GetByIdAsync(int id);
        Task<Student> UpdateAsync(int id, Student student);
        Task DeleteAsync(int id);
    }
}
