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
        public virtual void Create(User user)
        {
            DatabaseInstance.GetContext().Add(Mapper.Map(user));
            DatabaseInstance.GetContext().SaveChanges();
        }
        public virtual User Find(int userId)
        {
            return Mapper.Map(DatabaseInstance.GetContext().Users.Find(userId));
        }
        public virtual User Find(string username)
        {
            return Mapper.Map(DatabaseInstance.GetContext().Users.FirstOrDefault(u => u.Username == username));
        }
        public virtual void UpdateLocation (User user)
        {
            DatabaseInstance.GetContext().Users.Find(user.id).Location=user.location;
            DatabaseInstance.GetContext().SaveChanges();
        }
        public virtual void Delete (User user)
        {
            DatabaseInstance.GetContext().Remove(Mapper.Map(user));
            DatabaseInstance.GetContext().SaveChanges();
        }
    }
}
