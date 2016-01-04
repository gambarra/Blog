using Blog.Domain.Entities;
using Blog.Domain.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Specification.Posts
{
    public class PostPossuiTitulo : ISpecification<Post>
    {
        public bool IsSatisfiedBy(Post post)
        {
            return !string.IsNullOrEmpty(post.Titulo);
        }
    }
}
