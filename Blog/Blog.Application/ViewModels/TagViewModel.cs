using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.ViewModels
{
    public class TagViewModel
    {
        #region Constructores

        public TagViewModel()
        {
            this.Id = Guid.NewGuid();
        }
        #endregion

        #region Properties

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Texto { get; set; }
        public virtual PostViewModel Post { get; set; }
        public virtual ComentarioViewModel Comentario { get; set; }
        #endregion
    }
}
