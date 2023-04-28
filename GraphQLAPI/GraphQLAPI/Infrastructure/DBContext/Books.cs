using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GraphQLAPI.Infrastructure.DBContext
{
    public partial class Books
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long CategoryId { get; set; }
        public long PublisherId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Description { get; set; }

        public virtual Categories Category { get; set; }
        public virtual Publishers Publisher { get; set; }
    }
}
