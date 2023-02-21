using campusCentralApi.Interfaces;
using campusCentralApi.Models;
using Microsoft.EntityFrameworkCore;

namespace campusCentralApi.Repositories
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly UniversitySystemContext _context;
        public UserAccountRepository(UniversitySystemContext context)
        {
            _context = context;
        }
        public void Create(UserAccount userAccount)
        {
            _context.UserAccount.Add(userAccount);
        }

        public void Delete(UserAccount userAccount)
        {
            _context.UserAccount.Remove(userAccount);
        }

        public void Edit(UserAccount userAccount)
        {
            _context.Entry(userAccount).State = EntityState.Modified;
        }

        public async Task<IEnumerable<UserAccount>> GetAll()
        {
            return await _context.UserAccount.ToListAsync();
        }

        public async Task<UserAccount> GetById(int id)
        {
            return await _context.UserAccount.Where(x => x.UserAccountId == id).FirstOrDefaultAsync();
        }

        public async Task<UserAccount> GetByAproximatedName(string toFind)
        {
            return await _context.UserAccount.Where(x => x.Name.Contains(toFind)).FirstOrDefaultAsync();
        }

        public async Task<UserAccount> GetByEmail(string emailToFind)
        {
            return await _context.UserAccount.Where(x => x.Email == emailToFind).FirstOrDefaultAsync();
        }

        public async Task<UserAccount> GetByUsername(string nameToFind)
        {
            return await _context.UserAccount.Where(x => x.Username == nameToFind).FirstOrDefaultAsync();
        }

        public async Task<UserAccount> GetByPass(string passToFind, string emailToFind)
        {
            return await _context.UserAccount.Where(x => x.Password == passToFind && x.Email == emailToFind).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}