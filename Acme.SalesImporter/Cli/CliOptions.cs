using CommandLine;

namespace Acme.SalesImporter.Cli
{
    public class CliOptions
    {
        [Option('f', "file", Required = false, HelpText = "Select CSV file to read from.")]
        public string FileName { get; set; }
    }
}
