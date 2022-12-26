using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;

namespace ErpSystem.core.Common
{
    public interface IDbContext
    {
        public DbConnection connection { get; }
    }
}
