using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenFinch.Web.ViewModels
{
    public class SubscriberViewModel
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Email")]
        [Remote("CheckIfEmailExists", "NewsLetter", HttpMethod = "POST", ErrorMessage = "Email address already exists. Please enter a different email.")]
        public string Email { get; set; }

        [Required]
        [DisplayName("How did you hear about us?")]
        public int SourceId { get; set; }


        [DisplayName("Reason")]
        //  [DataType(DataType.MultilineText)]
        public string SubscriptionReason { get; set; }


        //public SourceViewModel source { get; set; }
    }
}