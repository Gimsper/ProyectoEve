using Eve.Core.Models.Entities;
using Eve.Core.ViewModel;
using Eve.Infraestructure.Base.Interfaces;

namespace Eve.Infraestructure.Repositories.Interfaces
{
    public interface IUserRepository : _IRepository<UserLogin>
    {
        bool CheckCredentials(UserDataViewModel request);
    }
}
