using System;
using System.ComponentModel.DataAnnotations;

namespace Resmap.API.Data
{
    public class BaseEntity
    {
        [Key()]
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
