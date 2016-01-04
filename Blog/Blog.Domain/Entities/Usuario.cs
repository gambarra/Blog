using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    public class Usuario
    {

        #region Constructores

        public Usuario()
        {
            this.Id = Guid.NewGuid();
        }
        #endregion

        #region Properties
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public virtual List<Comentario> Comentarios { get; set; }
        #endregion

    }
}
