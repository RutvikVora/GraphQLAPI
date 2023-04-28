using GraphQLAPI.Infrastructure.DBContext;
using GraphQLAPI.Models;
using System.Linq;

namespace GraphQLAPI.Repositories.Interfaces
{
    public interface IPublisherRepository
    {
        IQueryable<Publishers> GetPublishersList();
        Publishers GetPublisherById(long? PublisherId);
        Publishers UpsertPublisher(PublisherModel publisherModel);
        void DeletePublisher(int publisherId);
    }
}
