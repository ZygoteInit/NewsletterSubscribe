using System.Collections.Generic;
using System.ComponentModel;

namespace GreenFinch.Models
{
    public class Source
    {
        public int SourceId { get; set; }

        [DisplayName("Source")]
        public string Name { get; set; }

        public ICollection<Subscriber> Subscriber { get; set; }
    }

}