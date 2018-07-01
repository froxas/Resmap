using System;

namespace Resmap.API.Models
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string ProjectId { get; set; }
        public string Title { get; set; }
        public string Manager { get; set; }
    }
}
