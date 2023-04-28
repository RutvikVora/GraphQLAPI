using GraphQLAPI.Infrastructure.DBContext;
using GraphQLAPI.Models;
using System.Linq;

namespace GraphQLAPI.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IQueryable<Categories> GetCategorysList();
        Categories GetCategoryById(long? CategoryId);
        Categories UpsertCategory(CategoryModel categoryModel);
        void DeleteCategory(int categoryId);

    }
}
