using Blog.Domain.Entities;
using Blog.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Interfaces.Services
{
    public interface IPostService:IServiceBase<Post>
    {
        ValidationResult AdicionarPost(Post post);
        ValidationResult AtualizarPost(Post post);
        IEnumerable<Post> PostsRelacionados(Post post);
        IEnumerable<Post> PostPorAutor(Usuario usuario);

    }
}
