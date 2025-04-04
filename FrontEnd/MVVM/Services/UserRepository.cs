using FrontEnd.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.MVVM.Services
{
    public class UserRepository :IUserRepository
    {
        private readonly List<User> _users = new List<User>
        {
            new User { Id = 1, Name = "John Doe"},
            new User { Id = 2, Name = "Jane Smith" }
        };

        public User GetUserById(int id)
        {
            return _users.FirstOrDefault(u=>u.Id ==id);
        }
        public List<User> GetAllUsers()
        {
            return _users;
        }
        public void AddUser(User user)
        {
            _users.Add(user);
        }
        public void UpdateUser(User user)
        {
            var existingUser = GetUserById(user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
            }
        }

        public void DeleteUser(int id)
        {
            var user = GetUserById(id);
            if(user != null)
            {
                _users.Remove(user);
            }
        }
    }
}
