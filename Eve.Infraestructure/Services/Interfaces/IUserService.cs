using Eve.Core.Models.Entities;
using Eve.Core.ViewModel;
using Eve.Infraestructure.Base.Interfaces;
using Eve.Shared.Utils;

namespace Eve.Infraestructure.Services.Interfaces
{
    public interface IUserService : _IService<UserLogin>
    {
        ResultOperation<bool> CheckCredentials(UserDataViewModel request);
        ResultOperation<UserLogin> Register(RegisterViewModel request);
    }
}
