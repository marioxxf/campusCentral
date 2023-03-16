using campusCentralApi.Interfaces;
using campusCentralApi.Models;
using Microsoft.EntityFrameworkCore;

namespace campusCentralApi.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly UniversitySystemContext _context;
        public TopicRepository(UniversitySystemContext context)
        {
            _context = context;
        }
        public void Create(Topic Topic)
        {
            _context.Topic.Add(Topic);
        }

        public void Delete(Topic Topic)
        {
            _context.Topic.Remove(Topic);
        }

        public void Edit(Topic Topic)
        {
            _context.Entry(Topic).State = EntityState.Modified;
        }

        public async Task<IEnumerable<Topic>> GetAll()
        {
            return await _context.Topic.ToListAsync();
        }

        public async Task<Topic> GetById(int id)
        {
            return await _context.Topic.Where(x => x.TopicId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Topic>> GetTopicsByCourseId(int courseId)
        {
            return await _context.Topic.Where(x => x.CourseId == courseId).ToListAsync();
        }

        public async Task<Topic> GetByAproximatedName(string toFind)
        {
            return await _context.Topic.Where(x => x.Name.Contains(toFind)).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}