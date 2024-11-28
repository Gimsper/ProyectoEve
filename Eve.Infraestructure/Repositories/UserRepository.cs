using Eve.Core.Models.Context;
using Eve.Core.Models.Entities;
using Eve.Core.ViewModel;
using Eve.Infraestructure.Base;
using Eve.Infraestructure.Repositories.Interfaces;

namespace Eve.Infraestructure.Repositories
{
    public class UserRepository : _Repository<UserLogin>, IUserRepository
    {
        private readonly EveContext _context;

        public UserRepository(EveContext context) : base(context)
        {
            _context = context;
        }

        public bool CheckCredentials(UserDataViewModel request)
        {
            return _context.Users.Any(e => e.Username == request.Username && e.Password == request.Password);
        }
    }
}
