using GreenFinch.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFinch.Data
{
   public class GreenFinchEntitiesSeedData : DropCreateDatabaseIfModelChanges<GreenFinchEntities>
    {
        protected override void Seed(GreenFinchEntities context)
        {
            GetSources().ForEach(c => context.Source.Add(c));
            context.Commit();
        }

        private static List<Source> GetSources()
        {
            return new List<Source>
            {
                new Source {
                    Name = "Advert",
                    SourceId=1
                },
                new Source {
                    Name = "Word Of Mouth",
                    SourceId=2
                },
                 new Source {
                    Name = "Other",
                    SourceId=3
                }
            };
        }
    }
}
