using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLib.model
{
    public class User
    {
        public string? UserName { get; set; }
        public byte[]? Password { get; set; }
        public User(string userName, byte[] password)
        {
            UserName = userName;
            Password = password;
        }
        public User()
        {
            UserName = null;
            Password = null;
        }

        public override string ToString()
        {
            string passwordString = Password != null ? BitConverter.ToString(Password) : "null";
            
            return $"{{{nameof(UserName)}={UserName}, {nameof(Password)}={passwordString}}}";
        }
    }
}
