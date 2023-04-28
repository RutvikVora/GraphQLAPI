using GraphQLAPI.GraphQLCore.Publisher;
using GraphQLAPI.Infrastructure.DBContext;
using GraphQLAPI.Repositories;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace GraphQLAPI.GraphQLCore
{
    [ExtendObjectType(Name = "Query")]
    public class PublisherQuery
    {
        [UsePaging(IncludeTotalCount = true, DefaultPageSize = 5)]
        //public IQueryable<Publishers> PublisherList([Service] PublisherRepository publisherRepository) =>
        //      publisherRepository.GetPublishersList();
        public IQueryable<PublisherType> PublisherList([Service] PublisherRepository publisherRepository)
        {
            IQueryable<Publishers> publishers = publisherRepository.GetPublishersList();

            return publishers.Select(c => new PublisherType()
            {
                Id= c.Id,
                Name = c.Name,
                CreatedDate = c.CreatedDate
            });
        }

        public Publishers PublisherById([Service] PublisherRepository publisherRepository, int id) =>
           publisherRepository.GetPublisherById(id);
    }
}
