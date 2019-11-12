using System;

namespace Acme.SalesImporter.Utils.Exceptions
{
    public class DestinationException: Exception
    {
        public DestinationException(string message) : base(message)
        { }
    }
}
