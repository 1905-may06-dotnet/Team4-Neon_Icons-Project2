using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Entities;
using Domain.DomainEntities;
using Domain.Repositories;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void Create(User user)
        {
            DatabaseInstance.GetContext().Add(Mapper.Map(user));
        }

        public User Find(int userId)
        {
            return Mapper.Map(DatabaseInstance.GetContext().Users.Find(userId));
        }

        public User Find(string username)
        {
            return Mapper.Map(DatabaseInstance.GetContext().Users.FirstOrDefault(u => u.Username == username));
        }

        public void UpdateLocation (User user)
        {
            DatabaseInstance.GetContext().Locations.Update(Mapper.Map(user.location));
        }
    }
}
