using System.Collections.Generic;
using UserApp.Models;

namespace UserApp.Business;

public interface IUserService
{
    List<User> GetAll();
    User? GetById(int id);
    void Add(User user);
    void Update(User user);
    void Delete(int id);
}