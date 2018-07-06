using System;

namespace Resmap.API.Models
{
    public class ProjectForCreation
    {
        public string ProjectId { get; set; }
        public string Title { get; set; }
        public string Manager { get; set; }

        public NoteDto Note { get; set; }

        public IEquatable<TagDto> Tags { get; set; }
    }
}
