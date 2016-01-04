using Blog.Domain.Entities;
using Blog.Domain.Interfaces.Repository;
using Blog.Domain.Interfaces.Services;
using Blog.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Services
{
    public class PostService : ServiceBase<Post>, IPostService
    {
        #region Fields
        private readonly IPostRepository _postRepository;
        #endregion

        #region Constructores
        public PostService(IPostRepository postRepository)
            : base(postRepository)
        {
            _postRepository = postRepository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Método responsável por validar e adicionar um novo Post
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public ValidationResult AdicionarPost(Post post)
        {
            var resultadoValidacao = new ValidationResult();

            if (!post.IsValid())
            {
                resultadoValidacao.AdicionarErro(post.ResultadoValidacao);
                return resultadoValidacao;
            }

            base.Add(post);

            return resultadoValidacao;
        }

        /// <summary>
        /// Método responsável por retornar os post relacionados a um post
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public IEnumerable<Post> PostsRelacionados(Post post)
        {
            Expression<Func<Post, bool>> criteria = p => (
                (p.Usuario.Id == post.Usuario.Id) //Busco todos os post do mesmo autor
                ||
                (p.Tags.Any(t => post.Tags.Any(pt => pt.Texto == t.Texto))));//Busco todos os post que contem tags em comum

            return _postRepository.Find(criteria);
        }


        public ValidationResult AtualizarPost(Post post)
        {
            var resultadoValidacao = new ValidationResult();

            if (!post.IsValid())
            {
                resultadoValidacao.AdicionarErro(post.ResultadoValidacao);
                return resultadoValidacao;
            }

            base.Update(post);

            return resultadoValidacao;
        }

        public IEnumerable<Post> PostPorAutor(Usuario usuario)
        {

            //Busco todos os post do mesmo autor
            Expression<Func<Post, bool>> criteria = p => (
                (p.Usuario.Id == usuario.Id));

            return _postRepository.Find(criteria);
        }

     


        #endregion

    }
}
