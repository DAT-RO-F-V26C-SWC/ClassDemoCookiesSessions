using SessionLib.repository;
using System.Security.Cryptography;
using System.Text;

namespace ClassDemoCookiesSessions.services
{
    public class UserServices
    {
        private readonly IUserRepo _repo;
        public UserServices(IUserRepo repo)
        {
            _repo = repo;
        }
        public bool ValidateUser(string userName, string password)
        {
            try
            {
                var user = _repo.GetByUserName(userName);

                using (SHA256 mySHA256 = SHA256.Create())
                {
                    byte[] passwordCode = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(password));

                    return user?.Password.SequenceEqual(passwordCode) ?? false;
                }
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }
    }
}
