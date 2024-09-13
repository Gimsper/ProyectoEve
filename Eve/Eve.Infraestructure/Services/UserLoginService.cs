using Eve.Core.Entities;
using Eve.Infraestructure.Base;
using Eve.Infraestructure.Repositories.Interfaces;
using Eve.Infraestructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eve.Infraestructure.Services
{
    public class UserLoginService : _BaseService<UserLogin>, IUserLoginService
    {
        public UserLoginService(IUserLoginRepository repository) : base(repository) { }
    }
}
