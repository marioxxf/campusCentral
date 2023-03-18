using campusCentralApi.Models;

namespace campusCentralApi.Interfaces
{
    public interface ITopicScheduleTimeRepository
    {
        Task<IEnumerable<TopicScheduleTime>> GetAll();
        Task<IEnumerable<TopicScheduleTime>> GetTopicScheduleTimesByCourseId(int id);
    }
}
