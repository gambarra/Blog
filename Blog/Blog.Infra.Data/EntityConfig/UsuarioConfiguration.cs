using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infra.Data.EntityConfig
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
          #region Constructores

        public UsuarioConfiguration()
        {
            HasKey(c => c.Id);

        }
        #endregion
    }
}
