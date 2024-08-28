using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plugins_default_connection
{
    public class Dataverse
    {
        //Constructor
        public Dataverse()
        {
            //AppConfig
            string appconfigPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = Path.Combine(Path.GetFullPath($"{appconfigPath}\\{typeof(Dataverse).Namespace.Replace("_", "-")}\\app-sensitive.config")) };
            var config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            var settings = config.AppSettings.Settings;

            string friendlyName = settings[this.friendlyName].Value.ToString();
            string url = settings[this.url].Value.ToString();
            string tenantid = settings[this.tenantid].Value.ToString();
            string applicationid = settings[this.applicationId].Value.ToString();
            string secret = settings[this.secret].Value.ToString();
            string user = settings[this.user].Value.ToString();
            string password = settings[this.password].Value.ToString();
            string multipleFa = settings[this.multipleFa].Value.ToString();

            if (multipleFa == "true")
                this.ServiceClient = UserMultipleFa();
            else if (!string.IsNullOrEmpty(url) && !string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(password))
                this.ServiceClient = UserPassword();
            else if (!string.IsNullOrEmpty(url) && !string.IsNullOrEmpty(tenantid) && !string.IsNullOrEmpty(applicationid) && !string.IsNullOrEmpty(secret))
                this.ServiceClient = ClientSecret();

            if (this.ServiceClient != null && this.ServiceClient.IsReady)
            {
                Console.WriteLine("Conexão bem-sucedida!");
            }
            else
                throw new System.Exception(this.ServiceClient.LastCrmException.Message);



            CrmServiceClient UserMultipleFa()
            {
                string conn = $"AuthType=OAuth;Username={user};Password={password};Url={url};AppId={applicationid};RedirectUri=app://{tenantid};LoginPrompt=Auto";

                CrmServiceClient service = new CrmServiceClient(conn);


                return service;
            }

            CrmServiceClient ClientSecret()
            {
                string conn = $@"Url={url};
                            AuthType=ClientSecret;
                            TenantId={tenantid};
                            ClientId={applicationid};
                            ClientSecret={secret};
                            RequireNewInstance=True";

                return new CrmServiceClient(conn);
            }

            CrmServiceClient UserPassword()
            {
                string conn = $@"Url={url};
                            AuthType=Office365;
                            UserName={user};
                            Password={password};
                            RequireNewInstance=True";

                return new CrmServiceClient(conn);
            }
        }
        //Constantes
        public string friendlyName = "friendlyName";
        public string url = "url";
        public string tenantid = "tenantid";
        public string applicationId = "applicationid";
        public string secret = "secret";
        public string user = "user";
        public string password = "password";
        public string multipleFa = "multipleFa";

        public enum eAuthType
        {
            UserPassword = 0,
            ClientSecret = 1
        }
        //Service
        public CrmServiceClient ServiceClient { get; private set; }

    }

}
