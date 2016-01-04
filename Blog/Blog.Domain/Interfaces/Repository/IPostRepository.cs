using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Interfaces.Repository
{
    public interface IPostRepository : IBaseRepository<Post>
    {
    }
}
