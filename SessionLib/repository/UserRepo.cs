using SessionLib.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLib.repository
{
    public class UserRepo : IUserRepo
    {
        private readonly List<model.User> _users;

        public UserRepo()
        {
            _users = new List<model.User>();
        }

        public void Add(User user)
        {
            _users.Add(user);
        }

        public List<User> GetAll()
        {
            return new List<User>(_users);
        }

        public User GetByUserName(string? userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("Username cannot be null or empty.", nameof(userName));
            }

            User? user = _users.FirstOrDefault(u => u.UserName == userName);

            return user ?? throw new KeyNotFoundException($"User with username '{userName}' not found.");
        }

        public User Delete(string userName)
        {
            User user = GetByUserName(userName);
            _users.Remove(user);
            return user;
        }

        public User Update(User user)
        {
            User existingUser = GetByUserName(user.UserName);
            existingUser.Password = user.Password;
            return existingUser;
        }
    }
}
