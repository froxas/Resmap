﻿using System;

namespace Resmap.API.Models
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }

        public AddressDto Address { get; set; }
        public NoteDto Note { get; set; }
    }
}
