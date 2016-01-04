using Blog.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Blog.Infra.Data.EntityConfig
{
    public class PostConfiguration : EntityTypeConfiguration<Post>
    {
        #region Constructores

        public PostConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Conteudo)
                .HasColumnType("text");
        }
        #endregion
    }
}
