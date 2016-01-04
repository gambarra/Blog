using Blog.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Interfaces
{
    public interface IPostAppService:IDisposable
    {
        void Add(PostViewModel postViewModel);
        PostViewModel GetById(Guid id);
        IEnumerable<PostViewModel> GetAll();
        void Update(PostViewModel postViewModel);
        void Remove(PostViewModel postViewModel);
        IEnumerable<PostViewModel> PostsRelacionados(PostViewModel post);
        IEnumerable<PostViewModel> PostPorAutor(UsuarioViewModel usuario);

    }
}
