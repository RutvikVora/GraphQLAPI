using GraphQLAPI.Infrastructure.DBContext;
using GraphQLAPI.Repositories;
using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using System.Linq;

namespace GraphQLAPI.GraphQLCore.Category
{
    [ExtendObjectType(Name = "Query")]
    public class CategoryQuery
    {
        [UsePaging(IncludeTotalCount = true, DefaultPageSize = 5)]
        //public IQueryable<Categories> CategoryList([Service] CategoryRepository categoryRepository) =>
        //    categoryRepository.GetCategorysList();
        public IQueryable<CategoryType> CategoryList([Service] CategoryRepository categoryRepository)
        {
            IQueryable<Categories> categories = categoryRepository.GetCategorysList();

            return categories.Select(c => new CategoryType()
            {
                Id= c.Id,
                Name = c.Name,
                CreatedDate = c.CreatedDate,
            });
        }

        public Categories CategoryById([Service] CategoryRepository categoryRepository,
           [Service] ITopicEventSender eventSender, int id)
        {
            Categories gottenCategory = categoryRepository.GetCategoryById(id);
            eventSender.SendAsync("ReturnedCategory", gottenCategory);
            return gottenCategory;
        }
    }
}
