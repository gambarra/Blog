using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infra.Data.EntityConfig
{
    public class ComentarioConfiguration : EntityTypeConfiguration<Comentario>
    {
        #region Constructores

        public ComentarioConfiguration()
        {
            HasKey(c => c.Id);
        }
        #endregion
    }
}
