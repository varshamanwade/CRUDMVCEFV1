using CRUDMVCEFV1.Data.Context;
using CRUDMVCEFV1.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CRUDMVCEFV1.Data.Services
{
    public class UserService : IUserService
    {
        public readonly UserContext _context;

        public UserService(UserContext context)
        {
            _context = context;
        }

        public bool DeleteUserByID(Int32 UserId)
        {
            User objUser = _context.Users.FirstOrDefault(i => i.RecordId == UserId);
            if (objUser != null)
            {
                _context.Users.Remove(objUser);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public List<User> Get()
        {
            return _context.Users.ToList();
        }

        public User GetUserByID(int UserId)
        {
            return _context.Users.FirstOrDefault(i => i.RecordId == UserId);
        }

        public bool Save(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public bool Update(Int32 UserId, User user)
        {
            var data = GetUserByID(UserId);
            try
            {
                data.FirstName = user.FirstName;
                data.LastName = user.LastName;
                data.ModifyDate = DateTime.Now;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
