using AutoMapper;
using Blog.Application.Interfaces;
using Blog.Application.ViewModels;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces.Services;
using Blog.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application
{
    public class PostAppService : AppServiceBase<BlogContext>, IPostAppService
    {

        #region Fields
        private readonly IPostService _postService;
        #endregion

        #region Constructores
        public PostAppService(IPostService postService)
        {
            _postService = postService;
        }
        #endregion

        #region Methods
        public void Add(ViewModels.PostViewModel postViewModel)
        {
            var post = Mapper.Map<PostViewModel, Post>(postViewModel);
            BeginTransaction();
            _postService.Add(post);
            Commit();
        }

        public ViewModels.PostViewModel GetById(Guid id)
        {
            return Mapper.Map<Post, PostViewModel>(_postService.GetById(id));
        }

        public IEnumerable<ViewModels.PostViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(_postService.GetAll());
        }

        public void Update(ViewModels.PostViewModel postViewModel)
        {
            var cidade = Mapper.Map<PostViewModel, Post>(postViewModel);
            BeginTransaction();
            _postService.Update(cidade);
            Commit();
        }

        public void Remove(ViewModels.PostViewModel postViewModel)
        {
            var cidade = Mapper.Map<PostViewModel, Post>(postViewModel);
            BeginTransaction();
            _postService.Remove(cidade);
            Commit();
        }

        public void Dispose()
        {
            _postService.Dispose();
        }

        public IEnumerable<PostViewModel> PostsRelacionados(PostViewModel postViewModel)
        {
            var post = Mapper.Map<PostViewModel, Post>(postViewModel);
            return Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(_postService.PostsRelacionados(post));
        }

        public IEnumerable<PostViewModel> PostPorAutor(UsuarioViewModel usuarioViewModel)
        {
            var usuario = Mapper.Map<UsuarioViewModel, Usuario>(usuarioViewModel);
            return Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(_postService.PostPorAutor(usuario));
        }
        #endregion


    
    }
}
