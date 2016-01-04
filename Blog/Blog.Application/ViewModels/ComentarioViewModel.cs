using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.ViewModels
{
    public class ComentarioViewModel
    {
        #region Constructores

        public ComentarioViewModel()
        {
            this.Id = Guid.NewGuid();
        }
        #endregion

        #region Properties

        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Mensagem { get; set; }
        [Required]
        public DateTime DataPostagem { get; set; }
        public DateTime? DataExclusao { get; set; }
        public virtual PostViewModel Post { get; set; }
        public virtual UsuarioViewModel Usuario { get; set; }
        public virtual List<ComentarioViewModel> Comentarios { get; set; }
        public IEnumerable<TagViewModel> Tags { get; set; }

        #endregion
    }
}
