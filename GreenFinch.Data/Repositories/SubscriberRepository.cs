using GreenFinch.Data.Infrastructure;
using GreenFinch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFinch.Data.Repositories
{
    public class SubscriberRepository : RepositoryBase<Subscriber>, ISubscriberRepository
    {
        public SubscriberRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public bool CheckIfEmailExists(string Email)
        {
            var subscriberExists = DbContext.Subsriber.Where(x => x.Email.Equals(Email)).FirstOrDefault();

            return (subscriberExists == null);
        }
    }

    public interface ISubscriberRepository : IRepository<Subscriber>
    {
        bool CheckIfEmailExists(string Email);
    }
}
