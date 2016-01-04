using Blog.Domain.Entities;
using Blog.Domain.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Specification.Posts
{
    public class PostPossuiAoMenosUmaTag : ISpecification<Post>
    {
        public bool IsSatisfiedBy(Post post)
        {
            return post.Tags != null && post.Tags.Count >= 1;
        }
    }
}
