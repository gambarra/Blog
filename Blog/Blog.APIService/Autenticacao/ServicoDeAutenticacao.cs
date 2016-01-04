using Microsoft.IdentityModel.Claims;
using Microsoft.IdentityModel.SecurityTokenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Domain.Interfaces.Repository;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;

namespace Blog.APIService.Autenticacao
{
    public class ServicoDeAutenticacao : SecurityTokenService
    {

        #region Constructores

        public ServicoDeAutenticacao(ConfiguradorDoServicoDeAutenticacao configurador)
            : base(configurador)
        {
            //_usuarioRepository = usuarioRepository;
            this._relyingParties = new List<string>();
            this._relyingParties.Add("http://localhost:9000/BlogService");
        }
        #endregion

        #region Fields
        IUsuarioRepository _usuarioRepository;
        private List<string> _relyingParties;
        #endregion
        protected override Microsoft.IdentityModel.Claims.IClaimsIdentity GetOutputClaimsIdentity(Microsoft.IdentityModel.Claims.IClaimsPrincipal principal, Microsoft.IdentityModel.Protocols.WSTrust.RequestSecurityToken request, Scope scope)
        {

            var usuario = _usuarioRepository.RecuperarUsuario(principal.Identity.Name);

            if (usuario != null)
                principal.Identities[0].Claims.Add(new Claim(ClaimTypes.Role, "Integrador"));

            return principal.Identity as IClaimsIdentity;
        }

        protected override Scope GetScope(Microsoft.IdentityModel.Claims.IClaimsPrincipal principal, Microsoft.IdentityModel.Protocols.WSTrust.RequestSecurityToken request)
        {
            Scope scope = new Scope(request.AppliesTo.Uri.AbsoluteUri);
            scope.EncryptingCredentials = this.GetCredentialsForAppliesTo(request.AppliesTo);
            scope.SigningCredentials = new X509SigningCredentials(
                CertificateUtil.GetCertificate(
                    StoreName.My,
                    StoreLocation.LocalMachine,
                    "CN=Autenticador"));

            return scope;
        }

        private EncryptingCredentials GetCredentialsForAppliesTo(EndpointAddress appliesTo)
        {
            if (appliesTo == null || appliesTo.Uri == null || string.IsNullOrEmpty(appliesTo.Uri.AbsoluteUri))
                throw new InvalidRequestException("AppliesTo must be supplied in the RST.");

            X509EncryptingCredentials creds = null;

            if (this._relyingParties.Exists(s => s.StartsWith(appliesTo.Uri.AbsoluteUri, StringComparison.InvariantCultureIgnoreCase)))
                creds = new X509EncryptingCredentials(
                    CertificateUtil.GetCertificate(StoreName.TrustedPeople, StoreLocation.LocalMachine, "CN=Servico"));
            else
                throw new InvalidRequestException(string.Format("Invalid relying party address: {0}", appliesTo.Uri.AbsoluteUri));

            return creds;
        }
    }
}