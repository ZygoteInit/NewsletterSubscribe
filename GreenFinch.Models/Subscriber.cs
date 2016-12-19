using System.ComponentModel;

namespace GreenFinch.Models

{
    public class Subscriber
    {
  
        public int Id { get; set; }

        public string Email { get; set; }
      
        public int SourceId { get; set; }

        public string SubscriptionReason { get; set; }

        public Source source { get; set; }

    }
}