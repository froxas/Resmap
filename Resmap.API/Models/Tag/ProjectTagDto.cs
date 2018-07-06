using Resmap.Domain;
using System;

namespace Resmap.API.Models
{
    public class ProjectTagDto
    {
        public Guid Id { get; set; }        
        public TagDto Tag { get; set; }
    }
}
