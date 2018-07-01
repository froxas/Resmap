using System;
using System.ComponentModel.DataAnnotations;

namespace Resmap.Domain
{
    public interface IBaseEntity
    {
        /// <summary>
        /// id property for all entities
        /// </summary>
        [Key()]
        Guid Id { get; set; }

        /// <summary>
        /// property used for to isolate tenants
        /// automatically managed by ApplicationDbContext
        /// </summary>
        Guid TenantId { get; set; }

        /// <summary>
        /// property used for soft-delete of entities
        /// automatically managed by ApplicationDbContext
        /// </summary>
        bool IsDeleted { get; set; }
    }
}
