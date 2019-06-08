using System;
using System.Collections.Generic;
using System.Text;
using Domain.DomainEntities;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        void Create(User user);
        User Find(int userId);
        User Find(string userName);
    }
}
