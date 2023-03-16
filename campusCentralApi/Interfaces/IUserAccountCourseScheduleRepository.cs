using campusCentralApi.Models;

namespace campusCentralApi.Interfaces
{
    public interface IUserAccountCourseScheduleRepository
    {
        void Create(UserAccountCourseSchedule UserAccountCourseSchedule);
        void Edit(UserAccountCourseSchedule UserAccountCourseSchedule);
        void Delete(UserAccountCourseSchedule UserAccountCourseSchedule);
        Task<UserAccountCourseSchedule> GetById(int id);
        Task<IEnumerable<UserAccountCourseSchedule>> GetAll();
        Task<IEnumerable<UserAccountCourseSchedule>> GetAllByUserAccountId(int id);
        Task<bool> SaveAllAsync();
    }
}
