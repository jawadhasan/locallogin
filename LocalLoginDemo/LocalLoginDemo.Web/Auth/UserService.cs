using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalLoginDemo.Web.Auth
{
    public class UserService : IUserService
    {
        private IDictionary<string, (string passWord, User user)> _users = 
            new Dictionary<string, (string passWord, User user)>();

        //ctor: dictionary<username,password>
        public UserService(IDictionary<string, string> credentials)
        {
            foreach (var cred in credentials)
            {
                // _users.Add(cred.Key.ToLower(),(cred.Value, new User(cred.Key)));
                
                _users.Add(cred.Key.ToLower(), (BCrypt.Net.BCrypt.HashPassword(cred.Value), new User(cred.Key)));
            }
        }
        public Task<bool> ValidateCredentials(string userName, string passWord, out User user)
        {
            user = null;
            var key = userName.ToLower();

            if (_users.ContainsKey(key))
            {
                //check password
                //if (passWord == _users[key].passWord)

                if(BCrypt.Net.BCrypt.Verify(passWord, _users[key].passWord))
                {
                    user = _users[key].user;
                    return Task.FromResult(true);
                }
            }
            return Task.FromResult(false);
        }
    }
}
