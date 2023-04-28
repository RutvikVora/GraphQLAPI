using HotChocolate.Types;
using System;

namespace GraphQLAPI.GraphQLCore.Directives
{
    public class UpperCaseDirective : DirectiveType
    {
        protected override void Configure(IDirectiveTypeDescriptor descriptor)
        {
            descriptor.Name("upperCase");

            descriptor.Location(DirectiveLocation.Field);

            descriptor.Use(next => async context =>
            {
                // Execute the field resolver to get the result
                await next(context);

                // Make the result uppercase
                context.Result = context.Result.ToString().ToUpper();
            });
        }
    }
}
