using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.ViewModels
{
    public class UsuarioViewModel
    {
        #region Constructores

        public UsuarioViewModel()
        {
            this.Id = Guid.NewGuid();
        }
        #endregion

        #region Properties
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public virtual IEnumerable<ComentarioViewModel> Comentarios { get; set; }
        #endregion
    }
}
