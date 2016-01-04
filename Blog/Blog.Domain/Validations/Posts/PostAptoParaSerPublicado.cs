using Blog.Domain.Entities;
using Blog.Domain.Specification.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Validations.Posts
{
    public class PostAptoParaSerPublicado:ValidationBase<Post>
    {

        #region Constructores

        public PostAptoParaSerPublicado()
        {
            var postComConteudo = new PostPossuiConteudo();
            var postComTitulo = new PostPossuiTitulo();
            var postComTags = new PostPossuiAoMenosUmaTag();

            base.AdicionarRegra("PostComConteudo", new Regra<Post>(postComConteudo, "O Post precisa de um conteúdo para ser publicado."));
            base.AdicionarRegra("PostComTitulo", new Regra<Post>(postComTitulo, "O Post precisa de um título para ser publicado."));
            base.AdicionarRegra("PostComTags", new Regra<Post>(postComTags, "O post precisa ter ao menos uma TAG para ser publicado."));
        }
        #endregion
    }
}
