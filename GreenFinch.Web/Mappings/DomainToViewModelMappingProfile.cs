using AutoMapper;
using GreenFinch.Models;
using GreenFinch.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenFinch.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        public DomainToViewModelMappingProfile()
        {
            CreateMap<Subscriber, SubscriberViewModel>().ReverseMap();
            CreateMap<Source, SourceViewModel>();
        }
    }
}