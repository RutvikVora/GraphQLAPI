using GraphQLAPI.GraphQLCore.Category;
using HotChocolate;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using GraphQLAPI.Models;
using GraphQLAPI.GraphQLCore.DataLoaders;

namespace GraphQLAPI.GraphQLCore.Book
{
    public class BookType
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }

        [GraphQLNonNullType]
        public async Task<CategoryType> Category([Service] CategoryDataLoader categoryDataLoader)
        {
            CategoryModel categoryModel = await categoryDataLoader.LoadAsync(categoryId, CancellationToken.None);

            return new CategoryType()
            {
                Id = categoryModel.categoryId,
                Name = categoryModel.Name,
                CreatedDate = categoryModel.CreatedDate
            };
        }
    }
}
