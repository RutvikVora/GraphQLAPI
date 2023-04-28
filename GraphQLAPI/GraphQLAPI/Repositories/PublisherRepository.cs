using GraphQLAPI.Infrastructure.DBContext;
using GraphQLAPI.Models;
using GraphQLAPI.Repositories.Interfaces;
using System;
using System.Linq;

namespace GraphQLAPI.Repositories
{
    public class PublisherRepository : RepositoryBase<Publishers>, IPublisherRepository
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="context"></param>s
        public PublisherRepository(BookStoreContext bookStoreContext) : base(bookStoreContext)
        {

        }

        /// <summary>
        /// get list of all publishers
        /// </summary>
        /// <returns>list of all Publishers</returns>
        public IQueryable<Publishers> GetPublishersList()
        {
            return this.Find();
        }

        /// <summary>
        /// Get Publisher Details By Id
        /// </summary>
        /// <param name="PublisherId"></param>
        /// <returns>Publisher of particular Id</returns>
        public Publishers GetPublisherById(long? PublisherId)
        {
            return this.Find(x => x.Id == PublisherId).FirstOrDefault();
        }

        /// <summary>
        ///  add or edit Publisher
        /// </summary>
        /// <param name="PublisherModel"></param>
        /// <returns>Publisher Entity</returns>
        public Publishers UpsertPublisher(PublisherModel publisherModel)
        {
            try
            {
                Publishers publisherDb = GetPublisherById(publisherModel.publisherId);
                if (publisherDb != null)
                {
                    publisherModel.MappingModelToEntity(publisherDb, publisherModel);

                    this.UpdateEntity(publisherDb);
                    this.Save();
                    return publisherDb;

                }
                else
                {
                    Publishers publisher = publisherModel;
                    this.CreateEntity(publisher);
                    this.Save();
                    return publisher;

                }

            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// delete Publisher
        /// </summary>
        /// <param name="publisherId"></param>
        /// <returns></returns>
        public void DeletePublisher(int publisherId)
        {
            Publishers publisher = this.Find(x => x.Id == publisherId).FirstOrDefault();
            this.DeleteEntity(publisher);
            this.Save();
        }
    }
}
