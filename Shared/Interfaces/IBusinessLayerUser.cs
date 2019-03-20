using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTO;

namespace Shared.Interfaces
{
    public interface IBusinessLayerUser
    {
        LoginedUserDTO SignUp(SignUpUserDTO loginUser);
        LoginedUserDTO LoginUser(LoginUserDTO loginUserDTO);
        bool CheckEmailExistence(string email);
    }
}
