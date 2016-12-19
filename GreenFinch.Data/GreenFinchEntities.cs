using GreenFinch.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFinch.Data
{
   public class GreenFinchEntities : DbContext
    {
        public GreenFinchEntities() : base("GreenFinchEntities") { }

        public DbSet<Source> Source { get; set; }
        public DbSet<Subscriber> Subsriber { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SourceConfig());
            modelBuilder.Configurations.Add(new SubscriberConfig());
        }
    }
}
