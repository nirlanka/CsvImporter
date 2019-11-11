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

            Parser.Default.ParseArguments<CliOptions>(args)
                .WithParsed(o =>
                {
                    if (!string.IsNullOrWhiteSpace(o.FileName))
                    {
                        Console.WriteLine($"Reading from {o.FileName}...");
                        Importer.Import(o.FileName).GetAwaiter().GetResult(); //TODO: See if this could be async, for example showing progress
                    }
                    else
                    {
                        Console.WriteLine("No arguments supplied.");
                        Console.WriteLine("Quittig without doing anything.");
                    }
                });
        }
    }
}
