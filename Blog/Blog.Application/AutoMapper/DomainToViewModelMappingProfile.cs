using AutoMapper;
using Blog.Application.ViewModels;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.AutoMapper
{
   public  class DomainToViewModelMappingProfile:Profile
    {
     

        public DomainToViewModelMappingProfile()
            : base("DomainToViewModelMappings")
        {

        }

        protected override void Configure()
        {

            Mapper.CreateMap<Post, PostViewModel>();
            Mapper.CreateMap<Comentario, ComentarioViewModel>();
            Mapper.CreateMap<Tag, TagViewModel>();
            Mapper.CreateMap<Usuario, UsuarioViewModel>();
        }
    }
}
