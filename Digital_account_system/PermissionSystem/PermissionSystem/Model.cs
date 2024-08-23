using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermissionSystem
{
    public class Model
    {
        public class User
        {
            public string Username { get; set; }
            public Dictionary<string, string> Permissions { get; } = new Dictionary<string, string>();

            public User(string username)
            {
                Username = username;
            }
        }

        public class Folder
        {
            public string Name { get; set; }
            public Dictionary<string, string> Permissions { get; } = new Dictionary<string, string>();

            public Folder(string name)
            {
                Name = name;
            }
        }
    }
}
