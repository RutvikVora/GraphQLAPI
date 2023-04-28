using GraphQLAPI.Infrastructure.DBContext;
using GraphQLAPI.Models;
using GraphQLAPI.Repositories;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;

namespace GraphQLAPI.GraphQLCore.Book
{
    [ExtendObjectType(Name = "Query")]
    public class BookQuery
    {
        [UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 5)]
        //public IQueryable<Books> AllBooks([Service] BookRepository bookRepository) =>
        //    bookRepository.GetBooks();
        public IQueryable<BookType> AllBooks([Service] BookRepository bookRepository)
        {
            IQueryable<Books> bookModel = bookRepository.GetBooks();

            return bookModel.Select(c => new BookType()
            {
                Id = c.Id,
                Title= c.Title,
                Description = c.Description,
                CreatedDate = c.CreatedDate,
                Category = (IQueryable<Category.CategoryType>)c.Category
            });
        }

        public Books BookById([Service] BookRepository bookRepository,
            [Service] ITopicEventSender eventSender, int id)
        {
            Books gottenBook = bookRepository.GetBookById(id);
            eventSender.SendAsync("ReturnedBook", gottenBook);
            return gottenBook;
        }
    }
}
