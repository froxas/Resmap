using System;

namespace Resmap.Data.Services
{
    public class TenantProvider : ITenantProvider
    {
        public Guid GetTenantId()
        {           
            return Guid.Parse("4d0b6b71-549f-47aa-b692-744f478e5e45");
            // another one "4d0b6b71-549f-47aa-b692-744f478e5e45"
            // bfd9e9bc-913d-4eca-b51c-ace7a3ceff7f

        }
    }
}
