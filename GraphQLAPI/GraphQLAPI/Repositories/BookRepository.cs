using GraphQLAPI.Infrastructure.DBContext;
using GraphQLAPI.Models;
using GraphQLAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLAPI.Repositories
{
    public class BookRepository : RepositoryBase<Books>, IBookRepository
    {

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="context"></param>
        public BookRepository(BookStoreContext bookStoreContext) : base(bookStoreContext)
        {

        }

        /// <summary>
        /// Get All Book list.
        /// </summary>
        /// <returns>list of all books</returns>
        public IQueryable<Books> GetBooks()
        {
            return this.Find()
                .Include(c => c.Category)
                .Include(p => p.Publisher);
        }

        /// <summary>
        /// Get Book Details By Id
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns>Category of particular bookId</returns>
        public Books GetBookById(long bookId)
        {
            return this.Find(x => x.Id == bookId)
                .Include(c => c.Category)
                .Include(p => p.Publisher)
                .FirstOrDefault();
        }

        /// <summary>
        ///  add or edit Book
        /// </summary>
        /// <param name="bookModel"></param>
        /// <returns>Book Entity</returns>
        public Books upsertBook(BookModel bookModel)
        {
            try
            {
                Books bookDb = GetBookById(bookModel.bookId);
                if (bookDb != null)
                {
                    bookModel.MappingModelToEntity(bookDb, bookModel);

                    this.UpdateEntity(bookDb);
                    this.Save();
                    return bookDb;

                }
                else
                {
                    Books book = bookModel;
                    this.CreateEntity(book);
                    this.Save();
                    return book;

                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// delete Book
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public void DeleteCategory(int bookId)
        {
            Books book = this.Find(x => x.Id == bookId).FirstOrDefault();
            this.DeleteEntity(book);
            this.Save();
        }
    }
}
