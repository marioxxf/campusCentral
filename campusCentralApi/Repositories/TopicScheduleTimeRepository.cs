using campusCentralApi.Interfaces;
using campusCentralApi.Models;
using Microsoft.EntityFrameworkCore;

namespace campusCentralApi.Repositories
{
    public class TopicScheduleTimeRepository : ITopicScheduleTimeRepository
    {
        private readonly UniversitySystemContext _context;
        public TopicScheduleTimeRepository(UniversitySystemContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TopicScheduleTime>> GetAll()
        {
            return await _context.TopicScheduleTime.ToListAsync();
        }

        public async Task<IEnumerable<TopicScheduleTime>> GetTopicScheduleTimesByCourseId(int courseId)
        {
            return await _context.TopicScheduleTime.Where(x => x.CourseId == courseId).ToListAsync();
        }
    }
}