using MaxFit.Models.Dto;
using MaxFit.Models.Repository;
using MaxFit.Models.Service.Record;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxFit.Models.Service
{
    public class UserService : IUserService
    {
        readonly UserRepository _userRepository = new UserRepository();
        readonly RecordService _recordService = new RecordService();
        public bool AddUser(UserSubmitDTO userdto)
        {

            if (_userRepository.ExistUser(userdto.Identity) || ValidateParamasSaveUser(userdto))
            {
                return false;
            }
            else
            {
                var user = new User();

                user.Identity = userdto.Identity;
                user.IdentityType = userdto.IdentityType;
                user.Name = userdto.Name;
                user.Subscription = userdto.Subscription;
                user.DateInscription = DateTime.Now;

                if (_userRepository.AddUser(user))
                {
                    var record = new Entities.Record();
                    record.Docuemnt = user.Identity;
                    record.Date = user.DateInscription;
                    record.Price = CalculatePrice(user.Subscription);
                    _recordService.SaveRecord(record);
                    return true;
                }else { return false; }
            }            


        }

        private int CalculatePrice(string subscription)
        {
            return (int)(subscription == "N" ? MaxFit.Models.Price.Price.nuevo : MaxFit.Models.Price.Price.viejo);
        }

        public UserQueryDTO FindUser(string identity)
        {
            var user = _userRepository.FindUser(identity);
            var userdto = new UserQueryDTO();

            if (user != null)
            {
                userdto.Identity = user.Identity;
                userdto.IdentityType = user.Identity;
                userdto.Name = user.Name; 
                userdto.DateExpired = user.DateInscription.AddDays(30);
               
               
            }         
            
            return user.DateInscription.ToString().Equals("1/1/0001 12:00:00 AM") ?null:userdto;
        }

        public IEnumerable<UserAllQueryDTO> FindAll()
        {
            
            List<UserAllQueryDTO> users = new List<UserAllQueryDTO>();

            _userRepository.FindAll().ForEach(us =>
            {
                users.Add(new UserAllQueryDTO() { Identity = us.Identity,Name = us.Name,IdentityType = us.IdentityType,
                    DateInscription=us.DateInscription.ToString(),DateExpired=us.DateInscription.AddDays(30).ToString()});
            });

            return users;
        }

        public bool UpdateUser(UserSubmitDTO userdto){

            var user = new User();

            user.Identity = userdto.Identity;            
            user.Subscription = userdto.Subscription;
            user.DateInscription = DateTime.Now;
            if (ValidateParamasUpdateUser(userdto)) return false;
            if (_userRepository.UpdateUser(user))
            {
                var record = new Entities.Record();
                record.Docuemnt = user.Identity;
                record.Date = user.DateInscription;
                record.Price = CalculatePrice(user.Subscription);
                _recordService.SaveRecord(record);
                return true;
            }
            else { return false; }
        }

        private bool ValidateParamasSaveUser(UserSubmitDTO userdto)
        {
            return (userdto.Identity == null || userdto.IdentityType == null || userdto.Name == null || userdto.Subscription == null);
        }
        private bool ValidateParamasUpdateUser(UserSubmitDTO userdto)
        {
            return (userdto.Identity == null || userdto.Subscription == null);
        }
    }
}
