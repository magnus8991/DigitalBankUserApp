
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserApp.Data.Context;
using UserApp.Data.Interfaces;
using UserApp.Models;

namespace UserApp.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserDbContext _context;

    public UserRepository(UserDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllAsync() => await _context.Users.ToListAsync();
    public async Task<User?> GetByIdAsync(int id) => await _context.Users.FindAsync(id);
    public async Task AddAsync(User user) { _context.Users.Add(user); await _context.SaveChangesAsync(); }
    public async Task UpdateAsync(User user) { _context.Users.Update(user); await _context.SaveChangesAsync(); }
    public async Task DeleteAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user != null) { _context.Users.Remove(user); await _context.SaveChangesAsync(); }
    }
}