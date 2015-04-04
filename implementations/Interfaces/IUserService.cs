using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using core.Models;

namespace implementations.Interfaces
{
    public interface IUserService
    {
        int Login(LoginModel model);
    }
}
