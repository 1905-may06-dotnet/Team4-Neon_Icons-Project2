using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test
{
    [TestClass]
    public class UserTest
    {
        Dummydb db = new Dummydb();
        public UserTest()
        {
            
        }
        [TestMethod]
        public void Find()
        {
            Assert.IsTrue("testUsername0" == db.mockUser.Object.Find(0).username);
            
        }
        public void Create_validUser_NotNull()
        {

        }
        public void Delete_validUser_Null()
        {

        }
    }
}
