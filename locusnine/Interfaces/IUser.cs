using System;
using System.Collections.Generic;
using locusnine.Models;
using System.Linq;
using System.Threading.Tasks;

namespace locusnine.Interfaces
{
    public interface IUser
    {
        Task<List<Users>> GetUsers();
        Task<Users> GetUser(string id);
        Task Add(Users user);
        Task Delete(string id);
        Task Edit(string id, Users user);
    }
}
