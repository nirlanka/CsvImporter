using System;
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
                Console.WriteLine($"Importing from {options.FileName}...");
                Importer.Import(options.FileName);
            }
            else
            {
                Console.WriteLine("No arguments supplied.");
                Console.WriteLine("Quittig without doing anything.");
            }
        }
    }
}
