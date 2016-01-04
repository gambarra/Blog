using Blog.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Blog.APIService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BlogService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BlogService.svc or BlogService.svc.cs at the Solution Explorer and start debugging.
    public class BlogService : IBlogService
    {
        #region Properties

        private readonly IPostAppService _postApp;

        #endregion

        #region Constructores

        public BlogService(IPostAppService postApp)
        {
            this._postApp = postApp;
        }
        #endregion


        public bool CriarPost(Application.ViewModels.PostViewModel novoPost)
        {
            throw new NotImplementedException();
        }

        public bool AdicionarComentario(Application.ViewModels.PostViewModel post, Application.ViewModels.ComentarioViewModel novoComentario)
        {
            throw new NotImplementedException();
        }

        public List<Application.ViewModels.PostViewModel> PostPorAutor(Application.ViewModels.UsuarioViewModel usuario)
        {
            throw new NotImplementedException();
        }

        public List<Application.ViewModels.PostViewModel> PostPorData(DateTime dataInicial, DateTime dataFinal)
        {
            throw new NotImplementedException();
        }

        public List<Application.ViewModels.PostViewModel> PostRelacionados(Application.ViewModels.PostViewModel post)
        {
            throw new NotImplementedException();
        }
    }
}
