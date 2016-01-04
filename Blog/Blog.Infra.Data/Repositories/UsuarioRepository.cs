using Blog.Domain.Entities;
using Blog.Domain.Interfaces.Repository;
using Blog.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infra.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario, BlogContext>, IUsuarioRepository
    {

        public Usuario RecuperarUsuario(string username)
        {
            return this.GetAll().Where(u => u.Nome == username).FirstOrDefault();
        }

    }
}
