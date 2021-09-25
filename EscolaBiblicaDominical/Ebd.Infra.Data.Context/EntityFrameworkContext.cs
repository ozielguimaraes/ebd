using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Ebd.Infra.Data.Context
{
    public class EntityFrameworkContext : DbContext, IEnti, IDisposable
    {
        public DataBaseConfiguration Configuration { get; }
    }
}
