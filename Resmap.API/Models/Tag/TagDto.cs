using Resmap.Domain;
using System;

namespace Resmap.API.Models
{
    public class TagDto : ITag
    {
        public Guid Id { get; set; }
        public string Title { get; set; }        
        public TagLevel Level { get; set; }

        // not needed properties
        public Guid TenantId { get; set; }
        public bool IsDeleted { get; set; }
    }

}
