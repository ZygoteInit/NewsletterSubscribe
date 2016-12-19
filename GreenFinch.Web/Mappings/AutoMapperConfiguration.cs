using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenFinch.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configuration()
        {
            Mapper.Initialize(c => c.AddProfile<DomainToViewModelMappingProfile>());
        }
    }
}