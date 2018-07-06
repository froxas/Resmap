using Resmap.Domain;
using System;

namespace Resmap.API.Models
{
    public class TagDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }        
        public TagLevel Level { get; set; }
    }
}
