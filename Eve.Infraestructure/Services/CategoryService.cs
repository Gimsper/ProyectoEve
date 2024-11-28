using Eve.Core.Models.Entities;
using Eve.Infraestructure.Base;
using Eve.Infraestructure.Repositories.Interfaces;
using Eve.Infraestructure.Services.Interfaces;

namespace Eve.Infraestructure.Services
{
    public class CategoryService : _Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository) : base(repository)
        {         
            _repository = repository;
        }
    }
}
