using Acme.SalesImporter.Log;
using CommandLine;

namespace Acme.SalesImporter.Cli
{
    public static class CliHandler
    {
        public static void HandleCli(string[] args)
        {
            if (args.Length == 0)
            {
                args = new string[] { "-f", "sales.csv" };
            }

            Parser.Default
                .ParseArguments<CliOptions>(args)
                .WithParsed(HandleOptions);
        }

        public static void HandleOptions(CliOptions options)
        {
            if (!string.IsNullOrWhiteSpace(options.FileName))
            {
                Logger.LogLine($"Importing from {options.FileName}...");

                var importer = new Importer(new CsvToMySqlServiceMapper());
                importer.Import(options.FileName);
            }
            else
            {
                Logger.LogLine("No arguments supplied.");
                Logger.LogLine("Quittig without doing anything.");
            }
        }
    }
}
