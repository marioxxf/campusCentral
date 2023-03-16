using campusCentralApi.Models;

namespace campusCentralApi.Interfaces
{
    public interface ITopicRepository
    {
        void Create(Topic Topic);
        void Edit(Topic Topic);
        void Delete(Topic Topic);
        Task<Topic> GetById(int id);
        Task<Topic> GetByAproximatedName(string toFind);
        Task<IEnumerable<Topic>> GetAll();
        Task<bool> SaveAllAsync();
    }
}
