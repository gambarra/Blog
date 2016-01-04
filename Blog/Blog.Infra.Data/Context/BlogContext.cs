using Blog.Domain.Entities;
using Blog.Infra.Data.EntityConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infra.Data.Context
{
    public class BlogContext:BaseDbContext
    {
        #region Constructores

        public BlogContext()
            : base("Blog")
        {

        }
        #endregion

        #region DbSets
        public IDbSet<Post> Post { get; set; }
        public IDbSet<Comentario> Comentario { get; set; }
        public IDbSet<Tag> Tag { get; set; }
        public IDbSet<Usuario> Usuario { get; set; }

        #endregion

        #region Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Conventions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // General Custom Context Properties
            modelBuilder.Properties()
                .Where(p => p.Name == "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            // ModelConfiguration
            modelBuilder.Configurations.Add(new PostConfiguration());
            modelBuilder.Configurations.Add(new TagConfiguration());
            modelBuilder.Configurations.Add(new ComentarioConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());

            base.OnModelCreating(modelBuilder);
        }
     
        #endregion
    }
}
