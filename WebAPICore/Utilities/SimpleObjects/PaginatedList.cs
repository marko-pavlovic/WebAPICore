using System.Collections.Generic;

namespace Utilities.SimpleObjects
{
    public class PaginatedList<T>
    {
        public List<T> Records { get; set; }
        public int Count { get; set; }
    }
}
