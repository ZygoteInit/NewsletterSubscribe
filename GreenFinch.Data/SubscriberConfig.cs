using GreenFinch.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GreenFinch.Data
{
    public class SubscriberConfig : EntityTypeConfiguration<Subscriber>
    {
        public SubscriberConfig()
        {
            ToTable("Subscriber");
            Property(g => g.Email).IsRequired().HasMaxLength(50);
            Property(g => g.SourceId).IsRequired();
            Property(g => g.SubscriptionReason).IsOptional();

        }
    }
}
