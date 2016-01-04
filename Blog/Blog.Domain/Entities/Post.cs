using Blog.Domain.Interfaces.Validations;
using Blog.Domain.Validations.Posts;
using Blog.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    public class Post
    {

        #region  Constructores

        public Post()
        {
            this.Id = Guid.NewGuid();
            this.Comentarios = new List<Comentario>();
            this.Tags = new List<Tag>();
        }

        public Post(IValidationBase<Post> validadorDoPost)
            : this()
        {
            this.ValidadorDoPost = validadorDoPost;
        }

        #endregion

        #region  Fields
        IValidationBase<Post> _ValidadorDoPost;
        #endregion
        #region Properties
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataPostagem { get; set; }
        public DateTime? DataExclusao { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ValidationResult ResultadoValidacao { get; private set; }

        public  virtual IValidationBase<Post> ValidadorDoPost
        {
            get
            {
                //Validador Padrão
                _ValidadorDoPost = _ValidadorDoPost ?? new PostAptoParaSerPublicado();
                return _ValidadorDoPost;
            }
            private set { _ValidadorDoPost = value; }
     
        }
        #endregion

        #region Methods

        public bool IsValid()
        {
            ResultadoValidacao = this.ValidadorDoPost.Validar(this);
            return ResultadoValidacao.IsValid;
        }
        #endregion
    }
}
