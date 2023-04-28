using HotChocolate.Types;
using System;

namespace GraphQLAPI.GraphQLCore
{
    public class TimeStampDirective : DirectiveType
    {
        protected override void Configure(IDirectiveTypeDescriptor descriptor)
        {
            descriptor.Name("timestamp");
            descriptor.Description("Adds a timestamp to the response.");

            descriptor.Location(DirectiveLocation.Field);

            descriptor.Use(next => async context =>
            {
                // Execute the field resolver to get the result
                await next(context);

                // Add a timestamp to the result
                context.Result = DateTime.UtcNow;
            });
        }
    }

}
