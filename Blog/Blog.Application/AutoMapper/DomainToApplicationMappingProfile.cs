using AutoMapper;
using Blog.Application.Validation;
using Blog.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.AutoMapper
{
    public class DomainToApplicationMappingProfile : Profile
    {
       
        public DomainToApplicationMappingProfile()
            : base("DomainToApplicationMapping")
        {

        }
        protected override void Configure()
        {
            Mapper.CreateMap<ValidationError, ValidationAppError>();
            Mapper.CreateMap<ValidationResult, ValidationAppResult>();
        }
    }
}
