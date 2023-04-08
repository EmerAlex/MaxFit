using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxFit.Models.Repository
{
    public interface IUserRepository
    {

        bool AddUser(User user);
        User FindUser(string identity);
        bool ExistUser(string identity);
        bool DeleteUser(User user);
        IEnumerable<User> FindAll();
        bool UpdateUser(User user);
        

    }
}
