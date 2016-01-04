using Blog.Domain.Entities;
using Blog.Domain.Interfaces.Repository;
using Blog.Infra.Data.Context;

namespace Blog.Infra.Data.Repositories
{
    public class PostRepository : BaseRepository<Post, BlogContext>, IPostRepository
    {
    }
}
