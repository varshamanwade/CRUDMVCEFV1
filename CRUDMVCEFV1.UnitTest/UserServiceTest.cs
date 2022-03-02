using CRUDMVCEFV1.Controllers;
using CRUDMVCEFV1.Data.Context;
using CRUDMVCEFV1.Data.Data.Models;
using CRUDMVCEFV1.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CRUDMVCEFV1.UnitTest
{
    [TestClass]
    public class UserServiceTest
    {
        private readonly IUserService _service;
        private readonly UserContext userContext;
        public UserServiceTest()
        {
            userContext = new UserContext("Data Source=(localdb)\\ProjectsV13;Initial Catalog=UserDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            _service = new UserService(userContext);
        }
        [TestMethod]
        public void GetTest()
        {
            // Act
            var result = _service.Get();
            // Assert
            Assert.AreEqual(typeof(List<User>), result.GetType());
        }

        [TestMethod]
        public void GetUserByIdTest()
        {
            // Act
            var result = _service.GetUserByID(1);
            // Assert
            Assert.AreEqual(typeof(User), result.GetType());
        }

        [TestMethod]
        public void SaveUserTest() 
        {
            User user = new User
            {
                UserId = "VarshaManwade",
                FirstName = "Varsha",
                LastName = "Manwade",
                CreateDate = DateTime.Now,
                CreateBy = "Varsha"
            };
            // Act
            var result = _service.Save(user);
            // Assert
            Assert.AreEqual(typeof(bool), result.GetType());
        }

        [TestMethod]
        public void UpdateUserTest() 
        {
            var RecordId = 1;
            User user = new User
            {
                FirstName = "Varsha",
                LastName = "Manwade",
                ModifyDate = DateTime.Now,
                ModifyBy = "Varsha"
            };
            // Act
            var result = _service.Update(RecordId, user);
            // Assert
            Assert.AreEqual(typeof(bool), result.GetType());
        }

    }

}
