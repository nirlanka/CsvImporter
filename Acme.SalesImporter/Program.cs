using Acme.SalesImporter.Cli;

namespace Acme.SalesImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            CliHandler.HandleCli(args);
        }
    }
}
