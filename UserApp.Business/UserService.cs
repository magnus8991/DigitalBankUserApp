using System.Collections.Generic;
using UserApp.Data.Repositories;
using UserApp.Models;

namespace UserApp.Business;

public class UserService : IUserService
{
    private readonly UserRepository _repository;

    public UserService(UserRepository repository)
    {
        _repository = repository;
    }

    public List<User> GetAll() => _repository.GetAll();

    public User? GetById(int id) => _repository.GetById(id);

    public void Add(User user) => _repository.Insert(user);

    public void Update(User user) => _repository.Update(user);

    public void Delete(int id) => _repository.Delete(id);
}