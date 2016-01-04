using Blog.Domain.Entities;
using Blog.Domain.Interfaces.Repository;
using Blog.Domain.Services;
using Blog.Domain.Specification.Posts;
using Blog.Domain.Test.Fakes;
using Blog.Domain.Validations.Posts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Domain.Test.Posts.Services
{
    [TestClass]
    public class PostServiceTest
    {

        #region Fields

        private Mock<IPostRepository> _postRepository = new Mock<IPostRepository>();
        private PostRepositoryFake _postRepositoryFake = new PostRepositoryFake();
        private PostService _postService;

        #endregion

        #region Methods

        [TestMethod]
        public void PostRelacionadosPorTag()
        {
            int quantidadeRetorno = 3;
            var posts = new List<Post>();
            var usuario1 = _postRepositoryFake.createUsuario("Usuario1");
            var usuario2 = _postRepositoryFake.createUsuario("Usuario2");
            var usuario3 = _postRepositoryFake.createUsuario("Usuario3");
            var usuario4 = _postRepositoryFake.createUsuario("Usuario4");

            var Tag1 = _postRepositoryFake.createTag("TESTE1");
            var Tag2 = _postRepositoryFake.createTag("TESTE2");


            var post1 = _postRepositoryFake.createPost("Post1", "Conteudo 1", new List<Tag>() { Tag1 }, usuario1);
            var post2 = _postRepositoryFake.createPost("Post2", "Conteudo 2", new List<Tag>() { Tag2 }, usuario2);
            var post3 = _postRepositoryFake.createPost("Post3", "Conteudo 3", new List<Tag>() { Tag2, Tag1 }, usuario3);
            var post4 = _postRepositoryFake.createPost("Post4", "Conteudo 3", new List<Tag>() { Tag2, Tag1 }, usuario4);

            posts.Add(post1);
            posts.Add(post2);
            posts.Add(post3);
            posts.Add(post4);

            _postRepositoryFake.posts = posts;


            PostService postService = new PostService(_postRepositoryFake);

            var TagTest = _postRepositoryFake.createTag("TESTE1");
            var postTest = _postRepositoryFake.createPost("Post Test", "Conteudo Test", new List<Tag>() { TagTest }, _postRepositoryFake.createUsuario("UsuarioTest"));

            var postsRelacionados = postService.PostsRelacionados(postTest);

            int resultados = postsRelacionados.Count();

            Assert.AreEqual(quantidadeRetorno, resultados);
            Assert.IsTrue(postsRelacionados.All(p => p.Tags.Any(t => t.Texto == TagTest.Texto)));

        }

        [TestMethod]
        public void PostRelacionadosPorAutor()
        {
            int quantidadeRetorno = 2;
            var posts = new List<Post>();
            var usuario1 = _postRepositoryFake.createUsuario("Usuario1");
            var usuario2 = _postRepositoryFake.createUsuario("Usuario2");

            var Tag1 = _postRepositoryFake.createTag("TESTE1");
            var Tag2 = _postRepositoryFake.createTag("TESTE2");
            var Tag3 = _postRepositoryFake.createTag("TESTE3");
            var Tag4 = _postRepositoryFake.createTag("TESTE4");

            var post1 = _postRepositoryFake.createPost("Post1", "Conteudo 1", new List<Tag>() { Tag1 }, usuario1);
            var post2 = _postRepositoryFake.createPost("Post2", "Conteudo 2", new List<Tag>() { Tag2 }, usuario2);
            var post3 = _postRepositoryFake.createPost("Post3", "Conteudo 3", new List<Tag>() { Tag3 }, usuario2);
            var post4 = _postRepositoryFake.createPost("Post4", "Conteudo 3", new List<Tag>() { Tag4 }, usuario1);

            posts.Add(post1);
            posts.Add(post2);
            posts.Add(post3);
            posts.Add(post4);

            _postRepositoryFake.posts = posts;


            PostService postService = new PostService(_postRepositoryFake);

            var TagTest = _postRepositoryFake.createTag("TESTE1");
            var postTest = _postRepositoryFake.createPost("Post Test", "Conteudo Test", new List<Tag>() { TagTest }, usuario1);

            var postsRelacionados = postService.PostsRelacionados(postTest);

            int resultados = postsRelacionados.Count();

            Assert.AreEqual(quantidadeRetorno, resultados);
            Assert.IsTrue(postsRelacionados.All(p => p.Usuario.Id == usuario1.Id));
        }

        [TestMethod]
        public void PostRelacionadosPorAutorETag()
        {
            int quantidadeRetorno = 3;
            var posts = new List<Post>();
            var usuario1 = _postRepositoryFake.createUsuario("Usuario1");
            var usuario2 = _postRepositoryFake.createUsuario("Usuario2");

            var Tag1 = _postRepositoryFake.createTag("TESTE1");
            var Tag2 = _postRepositoryFake.createTag("TESTE2");
            var Tag3 = _postRepositoryFake.createTag("TESTE3");
            var Tag4 = _postRepositoryFake.createTag("TESTE4");

            var post1 = _postRepositoryFake.createPost("Post1", "Conteudo 1", new List<Tag>() { Tag1 }, usuario1);
            var post2 = _postRepositoryFake.createPost("Post2", "Conteudo 2", new List<Tag>() { Tag2 }, usuario2);
            var post3 = _postRepositoryFake.createPost("Post3", "Conteudo 3", new List<Tag>() { Tag3, Tag1 }, usuario2);
            var post4 = _postRepositoryFake.createPost("Post4", "Conteudo 3", new List<Tag>() { Tag4 }, usuario1);

            posts.Add(post1);
            posts.Add(post2);
            posts.Add(post3);
            posts.Add(post4);

            _postRepositoryFake.posts = posts;


            PostService postService = new PostService(_postRepositoryFake);

            var TagTest = _postRepositoryFake.createTag("TESTE1");
            var postTest = _postRepositoryFake.createPost("Post Test", "Conteudo Test", new List<Tag>() { TagTest }, usuario1);

            var postsRelacionados = postService.PostsRelacionados(postTest);

            int resultados = postsRelacionados.Count();

            Assert.AreEqual(quantidadeRetorno, resultados);
            Assert.IsTrue(postsRelacionados.All(p => p.Usuario.Id == usuario1.Id || p.Tags.Any(t => t.Texto == TagTest.Texto)));

        }

        [TestMethod]
        public void AdicionarPostSemTitulo() 
        {
            Post post = new Post(new PostAptoParaSerPublicado());
            _postService = new PostService(this._postRepository.Object);
            _postRepository.Setup(p => p.Add(post));

            post.Conteudo = "Conteudo Teste";
            post.Tags = new List<Tag>() { new Tag() };

            var result = _postService.AdicionarPost(post);

            Assert.AreEqual(1, result.Erros.Count());

            var erro = "O Post precisa de um título para ser publicado.";
            Assert.AreEqual(erro, result.Erros.First().Message);

        }


        #endregion
    }
}
