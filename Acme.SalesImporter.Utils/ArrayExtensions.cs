using System.Collections.Generic;
using System.Linq;

namespace Acme.SalesImporter.Utils
{
    public static class ArrayExtensions
    {
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
            => self.Select((item, index) => (item, index));
    }
}
