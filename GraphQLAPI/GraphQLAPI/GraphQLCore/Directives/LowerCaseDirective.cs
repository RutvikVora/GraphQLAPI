using HotChocolate.Types;

namespace GraphQLAPI.GraphQLCore.Directives
{
    public class LowerCaseDirective : DirectiveType
    {
        protected override void Configure(IDirectiveTypeDescriptor descriptor)
        {
            descriptor.Name("lowerCase");

            descriptor.Location(DirectiveLocation.Field);

            descriptor.Use(next => async context =>
            {
                // Execute the field resolver to get the result
                await next(context);

                // Make the result lowercase
                context.Result = context.Result.ToString().ToLower();
            });
        }
    }
}
