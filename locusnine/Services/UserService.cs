using locusnine.Data;
using locusnine.Interfaces;
using locusnine.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace locusnine.Services
{
    public class UserService : IUser
    {
        private readonly locusnineDbContext _locusnineDbContext;

        public UserService(locusnineDbContext locusnineDbContext)
        {
            _locusnineDbContext = locusnineDbContext;
        }
        public async Task Add(Users user)
        {
            try
            {
                if (string.IsNullOrEmpty(user.Email))
                {
                    throw new ArgumentNullException("Id is mandatory");
                }
                await _locusnineDbContext.AddAsync(user);
                await _locusnineDbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(string id)
        {
            try
            {
                var entity = await _locusnineDbContext.Users.FindAsync(id);
                _locusnineDbContext.Users.Remove(entity);

                await _locusnineDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Edit(string id, Users user)
        {
            try
            {
                var exists = await _locusnineDbContext.Users.AnyAsync(f => f.Id == id);
                if (!exists)
                {
                    throw new Exception("Record Not Found");
                }
                _locusnineDbContext.Users.Update(user);

                await _locusnineDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Users>> GetUsers()
        {
            try
            {
                return await _locusnineDbContext.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Users> GetUser(string id)
        {
            try
            {
                return await _locusnineDbContext.Users.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
