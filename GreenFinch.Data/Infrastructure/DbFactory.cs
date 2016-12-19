using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFinch.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        GreenFinchEntities dbContext;

        public GreenFinchEntities Init()
        {
            return dbContext ?? (dbContext = new GreenFinchEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
