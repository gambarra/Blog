using Blog.Domain.Entities;
using Blog.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Domain.Test.Fakes
{
    class PostRepositoryFake : BaseFake, IPostRepository
    {

        #region Fields

       public  List<Post> posts = new List<Post>();

        #endregion

        #region Constructores

        public PostRepositoryFake()
        {
           

        }
        #endregion



        #region Implements Methods
        public void Add(Entities.Post obj)
        {
            throw new NotImplementedException();
        }

        public Entities.Post GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entities.Post> GetAll()
        {
            return posts;
        }

        public void Update(Entities.Post obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(Entities.Post obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entities.Post> Find(System.Linq.Expressions.Expression<Func<Post, bool>> predicate)
        {
            return this.posts.Where(predicate.Compile()).ToList();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
