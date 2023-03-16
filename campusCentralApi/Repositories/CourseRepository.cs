using campusCentralApi.Interfaces;
using campusCentralApi.Models;
using Microsoft.EntityFrameworkCore;

namespace campusCentralApi.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly UniversitySystemContext _context;
        public CourseRepository(UniversitySystemContext context)
        {
            _context = context;
        }
        public void Create(Course Course)
        {
            _context.Course.Add(Course);
        }

        public void Delete(Course Course)
        {
            _context.Course.Remove(Course);
        }

        public void Edit(Course Course)
        {
            _context.Entry(Course).State = EntityState.Modified;
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            return await _context.Course.ToListAsync();
        }

        public async Task<Course> GetById(int id)
        {
            return await _context.Course.Where(x => x.CourseId == id).FirstOrDefaultAsync();
        }

        public async Task<Course> GetByAproximatedName(string toFind)
        {
            return await _context.Course.Where(x => x.Name.Contains(toFind)).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}