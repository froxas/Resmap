using System;
using System.Collections.Generic;

namespace Resmap.Data.Services
{
    public interface IEntityTypeProvider
    {
        IList<Type> GetEntityTypes();
    }
}