using System;

namespace Resmap.Data.Services
{
    public interface ITenantProvider
    {
        Guid GetTenantId();
    }
}
