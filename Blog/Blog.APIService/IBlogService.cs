using Blog.Application.ViewModels;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Blog.APIService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBlogService" in both code and config file together.
    [ServiceContract]
    public interface IBlogService
    {
        [OperationContract]
        bool CriarPost(PostViewModel novoPost);

        [OperationContract]
        bool AdicionarComentario(PostViewModel post, ComentarioViewModel novoComentario);
        [OperationContract]
        List<PostViewModel> PostPorAutor(UsuarioViewModel usuario);
        [OperationContract]
        List<PostViewModel> PostPorData(DateTime dataInicial, DateTime dataFinal);
        [OperationContract]
        List<PostViewModel> PostRelacionados(PostViewModel post);

    }
}
