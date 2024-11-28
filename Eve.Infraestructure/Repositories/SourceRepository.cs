using Eve.Core.Models.Context;
using Eve.Core.Models.Entities;
using Eve.Infraestructure.Base;
using Eve.Infraestructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Eve.Infraestructure.Repositories
{
    public class SourceRepository : _Repository<Source>, ISourceRepository
    {
        private readonly EveContext _context;

        public SourceRepository(EveContext context) : base(context)
        {
            _context = context;
        }

        public List<Source> GetSourcesWithCategories()
        {
            return _context.Sources
                .Include(e => e.Categories)
                .ToList();
        }
    }
}
