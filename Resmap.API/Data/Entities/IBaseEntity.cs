using System;
using System.ComponentModel.DataAnnotations;

namespace Resmap.API.Data
{
    public interface IBaseEntity
    {
        [Key()]
        Guid Id { get; set; }
        bool IsDeleted { get; set; }
    }
}
