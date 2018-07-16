﻿using Resmap.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Resmap.API.Models
{
    public class ProjectForCreationDto
    {        
        public string ProjectId { get; set; }

        [Required]
        public string Title { get; set; }
        public string Manager { get; set; }

        public AddressDto Address { get; set; }
        public NoteDto Note { get; set; }

        public ICollection<ProjectTagDto> ProjectTags { get; set; }
    }
}


