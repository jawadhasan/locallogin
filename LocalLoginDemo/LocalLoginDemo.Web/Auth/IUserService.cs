using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalLoginDemo.Web.Auth
{
    public interface IUserService
    {
        Task<bool> ValidateCredentials(string userName, string passWord, out User user);
    }
}
