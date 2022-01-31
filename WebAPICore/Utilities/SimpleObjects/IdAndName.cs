namespace Utilities.SimpleObjects
{
    public class IdAndName
    {
        public object Id { get; set; }
        public string Name { get; set; }

        public IdAndName()
        {

        }

        public IdAndName(object id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
