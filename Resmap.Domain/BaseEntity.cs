using System;
using System.ComponentModel.DataAnnotations;

namespace Resmap.Domain
{
    public class BaseEntity : IBaseEntity
    {
        [Key()]
        public Guid Id { get; set; }      
    }
}
