
using Blog.Application;
using Blog.Application.Interfaces;
using Blog.Domain.Interfaces.Repository;
using Blog.Domain.Interfaces.Services;
using Blog.Domain.Services;
using Blog.Infra.Data.Context;
using Blog.Infra.Data.Interfaces;
using Blog.Infra.Data.Repositories;
using Blog.Infra.Data.UoW;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Domain.CrossCutting.IoC
{
    public class NinjectModulo : NinjectModule
    {
        public override void Load()
        {

            // app
            Bind<IPostAppService>().To<PostAppService>();

            // service
            Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            Bind<IPostService>().To<PostService>();

            // data repos
            Bind(typeof(IBaseRepository<>)).To(typeof(BaseRepository<,>));
            Bind<IPostRepository>().To<PostRepository>();
            Bind<IUsuarioRepository>().To<UsuarioRepository>();
          

            // data configs
            Bind(typeof(IContextManager<>)).To(typeof(ContextManager<>));
            Bind<IDbContext>().To<BlogContext>();
            Bind(typeof(IUnitOfWork<>)).To(typeof(UnitOfWork<>));
        }
    }
}
