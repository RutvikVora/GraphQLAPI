using GraphQL.Types;
using GraphQLAPI.Infrastructure.DBContext;
using GraphQLAPI.Repositories.Interfaces;

namespace GraphQLAPI.GraphQLCore
{
    public class BookType : ObjectGraphType<Books>
    {
        public BookType(IBookRepository repository)
        {
            Field(x => x.Id).Description("Book id.");
            Field(x => x.Title).Description("Book Title.");
            Field(x => x.CategoryId).Description("Book Category.");
            Field(x => x.PublisherId).Description("Book Publisher.");
            Field(x => x.CreatedDate).Description("Created Date.");
            Field(x => x.Description).Description("Book Description.");

        }
    }
}
