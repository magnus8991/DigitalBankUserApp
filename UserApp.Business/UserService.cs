using System.Collections.Generic;
using System.Threading.Tasks;
using UserApp.Data.Interfaces;
using UserApp.Models;

namespace UserApp.Business;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    public UserService(IUserRepository repository) { _repository = repository; }

    public async Task<IEnumerable<User>> GetAllUsersAsync() => await _repository.GetAllAsync();
    public async Task<User?> GetUserByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task AddUserAsync(User user) => await _repository.AddAsync(user);
    public async Task UpdateUserAsync(User user) => await _repository.UpdateAsync(user);
    public async Task DeleteUserAsync(int id) => await _repository.DeleteAsync(id);
}