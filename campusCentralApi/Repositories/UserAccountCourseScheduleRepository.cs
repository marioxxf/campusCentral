using campusCentralApi.Interfaces;
using campusCentralApi.Models;
using Microsoft.EntityFrameworkCore;

namespace campusCentralApi.Repositories
{
    public class UserAccountCourseScheduleRepository : IUserAccountCourseScheduleRepository
    {
        private readonly UniversitySystemContext _context;
        public UserAccountCourseScheduleRepository(UniversitySystemContext context)
        {
            _context = context;
        }
        public void Create(UserAccountCourseSchedule UserAccountCourseSchedule)
        {
            _context.UserAccountCourseSchedule.Add(UserAccountCourseSchedule);
        }

        public void Delete(UserAccountCourseSchedule UserAccountCourseSchedule)
        {
            _context.UserAccountCourseSchedule.Remove(UserAccountCourseSchedule);
        }

        public void Edit(UserAccountCourseSchedule UserAccountCourseSchedule)
        {
            _context.Entry(UserAccountCourseSchedule).State = EntityState.Modified;
        }

        public async Task<IEnumerable<UserAccountCourseSchedule>> GetAll()
        {
            return await _context.UserAccountCourseSchedule.ToListAsync();
        }

        public async Task<IEnumerable<UserAccountCourseSchedule>> GetAllByUserAccountId(int id)
        {
            return await _context.UserAccountCourseSchedule.Where(x => x.UserAccountId == id).ToListAsync();
        }

        public async Task<UserAccountCourseSchedule> GetById(int id)
        {
            return await _context.UserAccountCourseSchedule.Where(x => x.UserAccountCourseScheduleId == id).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}