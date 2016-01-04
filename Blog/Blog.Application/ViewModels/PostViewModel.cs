using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Application.ViewModels
{
    public class PostViewModel
    {
        #region Constructores

        public PostViewModel()
        {

        }
        #endregion

        #region Properties

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Conteudo { get; set; }
        [Required]
        
        public DateTime DataPostagem { get; set; }
        public DateTime? DataExclusao { get; set; }

        public virtual UsuarioViewModel Usuario { get; set; }
        public virtual IEnumerable<ComentarioViewModel> Comentarios { get; set; }
        public virtual IEnumerable<TagViewModel> Tags { get; set; }
        #endregion
    }
}
