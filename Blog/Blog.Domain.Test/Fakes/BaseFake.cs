using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Domain.Test.Fakes
{
    public class BaseFake
    {
        #region Methods
        public  Usuario createUsuario(string nome)
        {
            return new Usuario() { Id = Guid.NewGuid(), Nome = nome };
        }
        public Tag createTag(string texto)
        {
            return new Tag()
            {
                Id = Guid.NewGuid(),
                Texto = texto
            };
        }
        public Post createPost(string titulo, string conteudo, List<Tag> tags, Usuario usuario)
        {
            return new Post()
            {
                Id = Guid.NewGuid(),
                Titulo = titulo,
                Conteudo = conteudo,
                DataPostagem = DateTime.Now,
                Usuario = usuario,
                Tags = tags
            };
        }
        public Comentario createComentario(string mensagem, ICollection<Comentario> comentarios) 
        {
            return new Comentario()
            {
                Id = Guid.NewGuid(),
                Mensagem = mensagem,
                DataPostagem = DateTime.Now,
                Comentarios=comentarios

            };
        }
        #endregion
    }
}
