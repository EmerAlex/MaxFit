using MaxFit.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxFit.Models.Service
{
    interface IUserService
    {
        bool AddUser(UserSubmitDTO userdto);
        UserQueryDTO FindUser(string identity);
        IEnumerable<UserAllQueryDTO> FindAll();
        IEnumerable<UserAllQueryDTO> FindAllUsersExpired();
        bool UpdateUser(UserSubmitDTO userdto);
    }
}
