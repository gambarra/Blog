using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    public class Tag
    {

        #region Constructores

        public Tag()
        {
            this.Id = Guid.NewGuid();
        }
        #endregion

        #region Properties
        public Guid Id { get; set; }
        public string Texto { get; set; }
        public virtual Post Post { get; set; }
        public virtual Comentario Comentario { get; set; }
        #endregion
    }
}
