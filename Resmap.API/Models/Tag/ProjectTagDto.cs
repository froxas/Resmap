using Resmap.Domain;
using System;

namespace Resmap.API.Models
{
    public class ProjectTagDto
    {
        public Guid TagId { get; set; }        
        public Guid ProjectId { get; set; }               
    }
}
