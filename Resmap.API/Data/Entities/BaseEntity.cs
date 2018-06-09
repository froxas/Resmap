using System;
using System.ComponentModel.DataAnnotations;

namespace Resmap.API.Data
{
    public class BaseEntity : IBaseEntity
    {
        [Key()]
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
