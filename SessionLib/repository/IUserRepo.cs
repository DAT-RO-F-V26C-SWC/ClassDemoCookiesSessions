using SessionLib.model;

namespace SessionLib.repository
{
    public interface IUserRepo
    {
        void Add(User user);
        User Delete(string userName);
        List<User> GetAll();
        User GetByUserName(string userName);
        User Update(User user);
    }
}