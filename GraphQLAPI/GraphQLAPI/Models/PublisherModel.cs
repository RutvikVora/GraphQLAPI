using GraphQLAPI.Infrastructure.DBContext;
using System;

namespace GraphQLAPI.Models
{
    public class PublisherModel
    {
        public PublisherModel()
        {

        }

        public PublisherModel(Publishers publisher)
        {
            this.publisherId = publisher.Id;
            this.Name = publisher.Name;
            this.CreatedDate = publisher.CreatedDate;

        }

        public long publisherId { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }

        public void MappingModelToEntity(Publishers publisher, PublisherModel publisherModel)
        {
            publisher.Id = publisherModel.publisherId;
            publisher.Name = publisherModel.Name;
            publisher.CreatedDate = publisherModel.CreatedDate;
        }

        public static implicit operator Publishers(PublisherModel publisherModel)
        {
            return new Publishers
            {
                Id = publisherModel.publisherId,
                Name = publisherModel.Name,
                CreatedDate = publisherModel.CreatedDate
            };

        }
    }
}
