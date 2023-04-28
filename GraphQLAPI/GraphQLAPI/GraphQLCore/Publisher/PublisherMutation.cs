using GraphQLAPI.Infrastructure.DBContext;
using GraphQLAPI.Models;
using GraphQLAPI.Repositories;
using HotChocolate;
using HotChocolate.Types;
using System.Threading.Tasks;

namespace GraphQLAPI.GraphQLCore.Publisher
{
    [ExtendObjectType(Name = "Mutation")]
    public class PublisherMutation
    {
        public async Task<Publishers> upsertPublisher([Service] PublisherRepository categoryRepository,
           string name, int id = 0)
        {
            PublisherModel newPublisher = new PublisherModel
            {
                publisherId = id,
                Name = name,
                CreatedDate = System.DateTime.Now
            };

            var createdPublisher = categoryRepository.UpsertPublisher(newPublisher);
            return createdPublisher;
        }
    }
}
