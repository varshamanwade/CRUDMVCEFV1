using CRUDMVCEFV1.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDMVCEFV1.Data.Services
{
    public interface IUserService
    {
        List<User> Get();
        User GetUserByID(Int32 UserId);
        bool Save(User user);
        bool Update(Int32 UserId,User user);
        bool DeleteUserByID(Int32 UserId);
    }

}

