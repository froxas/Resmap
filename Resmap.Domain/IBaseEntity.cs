using System;
using System.ComponentModel.DataAnnotations;

namespace Resmap.Domain
{
    public interface IBaseEntity
    {
        [Key()]
        Guid Id { get; set; }      
    }
}
