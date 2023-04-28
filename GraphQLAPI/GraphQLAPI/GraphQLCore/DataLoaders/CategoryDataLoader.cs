using GreenDonut;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using GraphQL.DataLoader;
using GraphQLAPI.Models;
using GraphQLAPI.Repositories;
using System.Linq;

namespace GraphQLAPI.GraphQLCore.DataLoaders
{
    public class CategoryDataLoader : BatchDataLoader<Guid, CategoryModel>
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryDataLoader(
            Func<IEnumerable<Guid>, 
                CancellationToken, 
                Task<IDictionary<Guid, CategoryModel>>> loader, 
            IEqualityComparer<Guid> keyComparer = null, 
            CategoryModel defaultValue = null,
            CategoryRepository categoryRepository) 
            : base(loader, keyComparer, defaultValue)
        {
            _categoryRepository = categoryRepository;
        }

        //public CategoryDataLoader(
        //    CategoryRepository categoryRepository,
        //    IBatchScheduler batchScheduler,
        //    DataLoaderOptions<Guid> options = null)
        //    : base(batchScheduler, options)
        //{
        //    categoryRepository = categoryRepository;
        //}

        protected async Task<IReadOnlyDictionary<Guid, CategoryModel>> BatchDataLoader(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
            IEnumerable<CategoryModel> categories = await CategoryRepository.GetManyByIds(keys);

            return (IReadOnlyDictionary<Guid, CategoryModel>)categories.ToDictionary(i => i.categoryId);
        }
    }
}
