using campusCentralApi.Models;

namespace campusCentralApi.Interfaces
{
    public interface IClassGroupRepository
    {
        void Create(ClassGroup ClassGroup);
        void Edit(ClassGroup ClassGroup);
        void Delete(ClassGroup ClassGroup);
        Task<ClassGroup> GetById(int id);
        Task<IEnumerable<ClassGroup>> GetByCourseIdAndAvailabilityByCourse(int id);
        Task<IEnumerable<ClassGroup>> GetAll();
        Task<bool> SaveAllAsync();
    }
}
