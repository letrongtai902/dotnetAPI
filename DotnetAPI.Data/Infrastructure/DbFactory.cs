using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetAPI.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private DotnetAPIDbContext dbcontext;
        public DotnetAPIDbContext Init()
        {
            return dbcontext ?? (dbcontext = new DotnetAPIDbContext());
        }
        protected override void DisposeCore()
        {
            if (dbcontext != null)
                dbcontext.Dispose();
        }
    }
}