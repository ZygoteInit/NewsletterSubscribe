using GreenFinch.Data.Infrastructure;
using GreenFinch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFinch.Data.Repositories
{
    public class SourceRepository : RepositoryBase<Source>, ISourceRepository
    {
        public SourceRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface ISourceRepository : IRepository<Source>
    {
       
    }
}
