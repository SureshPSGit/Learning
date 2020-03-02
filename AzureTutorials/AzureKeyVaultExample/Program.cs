using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AzureKeyVaultExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(builder =>
                {
                    var root = builder.Build();
                    var vaultName = root["KeyVault:Vault"];

                    if (!string.IsNullOrEmpty(vaultName))
                    {
                        builder.AddAzureKeyVault($"https://{vaultName}.vault.azure.net/",
                            root["KeyVault:ClientId"], GetCertificate(root["KeyVault:Thumbprint"]),
                            new PrefixKeyVaultSecretManager("AzureKeyVaultExample"));
                    }
                })
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        
        private static X509Certificate2 GetCertificate(string thumbprint)
        {
            var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            try
            {
                store.Open(OpenFlags.ReadOnly);
                var certificateCollection = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false);

                if (certificateCollection.Count == 0)
                {
                    throw new Exception("Certificate is not installed");
                }
                return certificateCollection[0];
            }
            finally
            {
                store.Close();
            }
        }
    }
}