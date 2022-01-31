namespace Utilities.SimpleObjects
{
    public class PaginatedListWithSum<T> : PaginatedList<T>
    {
        public T Sum { get; set; }
    }
}
