using campusCentralApi.Interfaces;
using campusCentralApi.Models;
using Microsoft.EntityFrameworkCore;

namespace campusCentralApi.Repositories
{
    public class ClassGroupRepository : IClassGroupRepository
    {
        private readonly UniversitySystemContext _context;
        public ClassGroupRepository(UniversitySystemContext context)
        {
            _context = context;
        }
        public void Create(ClassGroup ClassGroup)
        {
            _context.ClassGroup.Add(ClassGroup);
        }

        public void Delete(ClassGroup ClassGroup)
        {
            _context.ClassGroup.Remove(ClassGroup);
        }

        public void Edit(ClassGroup ClassGroup)
        {
            _context.Entry(ClassGroup).State = EntityState.Modified;
        }

        public async Task<IEnumerable<ClassGroup>> GetAll()
        {
            return await _context.ClassGroup.ToListAsync();
        }

        public async Task<ClassGroup> GetById(int id)
        {
            return await _context.ClassGroup.Where(x => x.ClassGroupId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ClassGroup>> GetByCourseIdAndAvailabilityByCourse(int id)
        {
            return await _context.ClassGroup.Where(x => x.CourseId == id).Where(x => x.ClassGroupEnrolledUsersQuantity <= x.MaxEnrolledUsers).ToListAsync();

        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}