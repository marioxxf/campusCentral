using campusCentralApi.Models;

namespace campusCentralApi.Interfaces
{
    public interface ICourseRepository
    {
        void Create(Course Course);
        void Edit(Course Course);
        void Delete(Course Course);
        Task<Course> GetById(int id);
        Task<Course> GetByAproximatedName(string toFind);
        Task<IEnumerable<Course>> GetAll();
        Task<bool> SaveAllAsync();
    }
}
