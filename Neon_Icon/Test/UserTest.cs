﻿using System;
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
        private readonly IUserRepository udb;
        public UserTest()
        {
            udb = new Data.Repositories.UserRepository();
        }
        [TestMethod]
        public void Find()
        {
            Assert.IsTrue("testUsername0" == db.mockUser.Object.Find(0).username);
            
        }
        [TestMethod]
        public void Create_validUser_True()
        {
            Domain.DomainEntities.User testUser = new Domain.DomainEntities.User();
            testUser.username = "backendTest";
            testUser.password = "password";
            testUser.location = "98908";
            udb.Create(testUser);
            Assert.IsTrue(udb.Find(testUser.username).username == "backendTest");
        }
        [TestMethod]
        public void Find_userId_True()
        {
            Domain.DomainEntities.User testUser = udb.Find("backendTest");
            Assert.IsTrue(udb.Find(testUser.id).username == "backendTest");
        }
        [TestMethod]
        public void Find_username_True()
        {
            Domain.DomainEntities.User testUser = udb.Find("backendTest");
            Assert.IsTrue(udb.Find(testUser.username).username == "backendTest");
        }
        [TestMethod]
        public void UpdateLocation_newZipCode_True()
        {
            Domain.DomainEntities.User testUser = udb.Find("backendTest");
            testUser.location = "95616";
            udb.UpdateLocation(testUser);
            Domain.DomainEntities.User updatedUser = udb.Find("backendTest");
            Assert.IsTrue(updatedUser.location == "95616");
        }
        [TestMethod]
        public void Delete_validUser_True()
        {
            Domain.DomainEntities.User testUser = udb.Find("backendTest");
            udb.Delete(testUser);
            Assert.IsTrue(udb.Find(testUser.id) == null);
        }
    }
}
