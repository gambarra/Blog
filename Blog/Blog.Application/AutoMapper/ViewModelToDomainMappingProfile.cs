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
    public class ViewModelToDomainMappingProfile : Profile
    {
       
        public ViewModelToDomainMappingProfile()
            : base("ViewModelToDomainMappings")
        {

        }

        /// <summary>
        /// Responsável pelo mapeamento entre o view model e o domínio
        /// </summary>
        protected override void Configure()
        {
            Mapper.CreateMap<PostViewModel, Post>();
            Mapper.CreateMap<ComentarioViewModel, Comentario>();
            Mapper.CreateMap<TagViewModel, Tag>();
            Mapper.CreateMap<UsuarioViewModel, Usuario>();
        }
    }
}
