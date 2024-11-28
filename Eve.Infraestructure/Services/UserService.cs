using Eve.Core.Models.Entities;
using Eve.Core.ViewModel;
using Eve.Infraestructure.Base;
using Eve.Infraestructure.Repositories.Interfaces;
using Eve.Infraestructure.Services.Interfaces;
using Eve.Shared.Utils;

namespace Eve.Infraestructure.Services
{
    public class UserService : _Service<UserLogin>, IUserService
    {
        private readonly IUserRepository _repository;
        private enum RolType
        {
            God,
            Admin,
            PseudoAdmin,
            Normal,
        };

        public UserService(IUserRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public ResultOperation<bool> CheckCredentials(UserDataViewModel request)
        {
            ResultOperation<bool> rst = new();
            try
            {
                rst.Result = _repository.CheckCredentials(request);
            }
            catch (Exception ex)
            {
                rst.StateOperation = false;
                rst.Result = false;
                rst.MessageError = ex.Message;
            }

            return rst;
        }

        public ResultOperation<UserLogin> Register(RegisterViewModel request)
        {
            ResultOperation<UserLogin> rst = new();
            try
            {
                UserLogin obj = new()
                {
                    Username = request.Username,
                    Password = request.Password,
                    Email = request.Email,
                    RolId = ((int)RolType.Normal),
                };
                rst.Result = _repository.Add(obj);
            }
            catch (Exception ex)
            {
                rst.StateOperation = false;
                rst.Result = null;
                rst.MessageError = ex.Message;
            }

            return rst;
        }
    }
}
