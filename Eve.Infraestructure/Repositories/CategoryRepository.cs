using Eve.Core.Models.Context;
using Eve.Core.Models.Entities;
using Eve.Infraestructure.Base;
using Eve.Infraestructure.Repositories.Interfaces;

namespace Eve.Infraestructure.Repositories
{
    public class CategoryRepository : _Repository<Category>, ICategoryRepository
    {
        private readonly EveContext _context;

        public CategoryRepository(EveContext context) : base(context) { }
    }
}
