using Eve.Core.Models.Entities;
using Eve.Infraestructure.Base.Interfaces;

namespace Eve.Infraestructure.Repositories.Interfaces
{
    public interface ISourceRepository : _IRepository<Source>
    {
        List<Source> GetSourcesWithCategories();
    }
}
