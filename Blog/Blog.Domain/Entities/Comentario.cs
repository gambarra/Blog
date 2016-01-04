using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    public class Comentario
    {
        #region Constructores

        public Comentario()
        {
            this.Id = Guid.NewGuid();
            Comentarios = new List<Comentario>();
            Tags = new List<Tag>();
        }
        #endregion

        #region Properties
        public Guid Id { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataPostagem { get; set; }
        public DateTime? DataExclusao { get; set; }
        public virtual Post Post { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        #endregion
    }
}
