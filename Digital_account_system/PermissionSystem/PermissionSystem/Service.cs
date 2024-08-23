using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PermissionSystem.Model;

namespace PermissionSystem
{
    public class Service
    {
        public void GrantPermission(Model.User user, Model.Folder folder, string role)
        {
            folder.Permissions[user.Username] = role;
        }

        public bool HasPermission(Model.User user, Model.Folder folder, string action)
        {
            if (folder.Permissions.TryGetValue(user.Username, out string role))
            {
                if (role == "Admin")
                    return true;
                if (role == "Contributor" && (action == "read" || action == "write"))
                    return true;
                if (role == "Reader" && action == "read")
                    return true;
            }
            return false;
        }
    }
}
