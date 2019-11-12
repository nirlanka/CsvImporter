using System;

namespace Acme.SalesImporter.Utils.Exceptions
{
    public class SourceException: Exception
    {
        public SourceException(string message) : base(message)
        { }
    }
}
