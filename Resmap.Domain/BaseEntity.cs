using System;
using System.ComponentModel.DataAnnotations;

namespace Resmap.Domain
{
    public abstract class BaseEntity : IBaseEntity
    {
        [Key()]
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
