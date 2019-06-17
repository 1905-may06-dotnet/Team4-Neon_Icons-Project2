using System;
using System.Collections.Generic;
using System.Text;
using Domain.Repositories;

namespace Test
{
    class UserTest
    {
        private readonly IUserRepository udb;
        UserTest(IUserRepository udb)
        {
            this.udb = udb;
        }

        public void Create_validUser_NotNull()
        {

        }
        public void Delete_validUser_Null()
        {

        }
    }
}
