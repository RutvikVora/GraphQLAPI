using GraphQLAPI.Infrastructure.DBContext;
using GraphQLAPI.Models;
using GraphQLAPI.Repositories;
using HotChocolate;
using HotChocolate.Types;
using System.Threading.Tasks;

namespace GraphQLAPI.GraphQLCore.Category
{
    [ExtendObjectType(Name = "Mutation")]
    public class CategoryMutation
    {
        public async Task<Categories> upsertCategory([Service] CategoryRepository categoryRepository,
           string name, int id = 0)
        {
            CategoryModel newBook = new CategoryModel
            {
                categoryId = id,
                Name = name,
                CreatedDate = System.DateTime.Now
            };

            var createdCategory = categoryRepository.UpsertCategory(newBook);
            return createdCategory;
        }
    }
}
