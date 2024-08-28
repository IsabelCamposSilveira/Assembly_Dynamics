using System.Collections.Generic;
using plugins_default_connection;

namespace plugins_default_console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dataverse = new Dataverse(); // Conexão


            var examples = new Functions(dataverse);
            // var id = examples.CreateSample();
            // examples.UpdateWithIdSample(id);

        }
    }
}
