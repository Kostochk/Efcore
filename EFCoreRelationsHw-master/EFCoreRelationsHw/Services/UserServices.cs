using EFCoreRelationsHw.Data;
using EFCoreRelationsHw.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRelationsHw.Services
{
    public class UserService
    {
        private readonly MoviesContext _context;

        public UserService(MoviesContext context)
        {
            _context = context;
        }

        public void CreateUser(string username, string email, string password)
        {
            var user = new User { Username = username, Email = email, Password = password };
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public List<User> GetAllUsers() => _context.Users.ToList();

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public void UpdateUser(int id, string email)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                user.Email = email;
                _context.SaveChanges();
            }
        }
    }
}
