using Eve.Core.Context;
using Eve.Core.Entities;
using Eve.Infraestructure.Base;
using Eve.Infraestructure.Repositories.Interfaces;

namespace Eve.Infraestructure.Repositories
{
    public class UserLoginRepository : _BaseRepository<UserLogin>, IUserLoginRepository
    {        
        public UserLoginRepository(EveContext context) : base(context) { }
    }
}
