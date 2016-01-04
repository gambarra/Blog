using Microsoft.IdentityModel.Configuration;
using Microsoft.IdentityModel.SecurityTokenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Blog.APIService.Autenticacao
{
    public class ConfiguradorDoServicoDeAutenticacao : SecurityTokenServiceConfiguration
    {
        public ConfiguradorDoServicoDeAutenticacao()
            : base("ServicoDeAutenticacao")
        {
            this.SecurityTokenService = typeof(ServicoDeAutenticacao);
            this.SigningCredentials = new X509SigningCredentials(
                CertificateUtil.GetCertificate(
                    StoreName.My,
                    StoreLocation.LocalMachine,
                    "CN=Autenticador"));
        }
    }
}
