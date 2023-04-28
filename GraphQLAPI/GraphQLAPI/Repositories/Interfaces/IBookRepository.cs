using GraphQLAPI.Infrastructure.DBContext;
using GraphQLAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLAPI.Repositories.Interfaces
{
    public interface IBookRepository
    {
        IQueryable<Books> GetBooks();
        Books GetBookById(long id);
        Books upsertBook(BookModel bookModel);
    }
}
