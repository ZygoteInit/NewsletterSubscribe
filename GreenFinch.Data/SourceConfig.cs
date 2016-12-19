using GreenFinch.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFinch.Data
{
    class SourceConfig : EntityTypeConfiguration<Source>
    {
        public SourceConfig()
        {
            ToTable("Source");
            Property(c => c.Name).IsRequired().HasMaxLength(50);
        }
    }
}
