using Eve.Core.Models.Entities;
using Eve.Infraestructure.Base.Interfaces;
using Eve.Shared.Utils;

namespace Eve.Infraestructure.Services.Interfaces
{
    public interface ISourceService : _IService<Source>
    {
        ResultOperation<Source> GetSourcesWithCategories();
    }
}
