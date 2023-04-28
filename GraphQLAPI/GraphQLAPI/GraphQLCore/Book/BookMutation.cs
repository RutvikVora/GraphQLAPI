using GraphQLAPI.Infrastructure.DBContext;
using GraphQLAPI.Models;
using GraphQLAPI.Repositories;
using HotChocolate;
using HotChocolate.Types;
using System.Threading.Tasks;

namespace GraphQLAPI.GraphQLCore.Book
{
    [ExtendObjectType(Name = "Mutation")]
    public class BookMutation
    {
        public async Task<Books> upsertBooks([Service] BookRepository bookRepository,
            string title, int categoryId, int publisherId, string description, int id = 0)
        {
            BookModel newBook = new BookModel
            {
                bookId = id,
                title = title,
                categoryId = categoryId,
                publisherId = publisherId,
                description = description,
                createdDate = System.DateTime.Now
            };

            var createdBook = bookRepository.upsertBook(newBook);
            return createdBook;
        }
    }
}
