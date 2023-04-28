using GraphQLAPI.Infrastructure.DBContext;
using System;

namespace GraphQLAPI.Models
{
    public class BookModel
    {
        public BookModel()
        {

        }

        public BookModel(Books book)
        {
            this.bookId = book.Id;
            this.title = book.Title;
            this.description = book.Description;
            this.createdDate = book.CreatedDate;
            this.publisherId = book.PublisherId;
            this.categoryId = book.CategoryId;

        }

        public long bookId { get; set; }
        public string title { get; set; }
        public DateTime? createdDate { get; set; }
        public string description { get; set; }
        public long publisherId { get; set; }
        public long categoryId { get; set; }

        public void MappingModelToEntity(Books book, BookModel bookModel)
        {
            book.Id = bookModel.bookId;
            book.Title = bookModel.title;
            book.Description = bookModel.description;
            book.CreatedDate = bookModel.createdDate;
            book.PublisherId = bookModel.publisherId;
            book.CategoryId = bookModel.categoryId;
        }

        public static implicit operator Books(BookModel BookModel)
        {
            return new Books
            {
                Id = BookModel.bookId,
                Title = BookModel.title,
                Description = BookModel.description,
                CreatedDate = BookModel.createdDate,
                PublisherId = BookModel.publisherId,
                CategoryId = BookModel.categoryId
            };

        }
    }
}
