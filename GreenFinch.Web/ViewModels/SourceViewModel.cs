using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace GreenFinch.Web.ViewModels
{
    public class SourceViewModel
    {
        public int SourceId { get; set; }

        [DisplayName("Source")]
        public string Name { get; set; }

        public ICollection<SubscriberViewModel> Subscriber { get; set; }
    }
}