using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace Blog.APIService.Autenticacao
{
    public static class CertificateUtil
    {
        public static X509Certificate2 GetCertificate(StoreName storeName, StoreLocation location, string subjectName)
        {
            X509Store store = new X509Store(storeName, location);
            X509Certificate2Collection certificates = null;
            store.Open(OpenFlags.ReadOnly);

            try
            {
                X509Certificate2 result = null;

                certificates = store.Certificates;

                for (int i = 0; i < certificates.Count; i++)
                {
                    X509Certificate2 cert = certificates[i];

                    if (cert.SubjectName.Name.ToLower() == subjectName.ToLower())
                    {
                        if (result != null)
                            throw new ApplicationException(string.Format("There is more than one certificate found for subject name {0}", subjectName));

                        result = new X509Certificate2(cert);
                    }
                }

                if (result == null)
                    throw new ApplicationException(string.Format("No certificate was found for subject name {0}", subjectName));

                return result;
            }
            finally
            {
                if (certificates != null)
                    for (int i = 0; i < certificates.Count; i++)
                        certificates[i].Reset();

                store.Close();
            }
        }
    }
}