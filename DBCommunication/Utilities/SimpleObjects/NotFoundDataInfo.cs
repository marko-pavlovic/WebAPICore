namespace DBCommunication.Utilities.SimpleObjects
{
    public class NotFoundDataInfo
    {
        public string Item { get; set; }
        public object Key { get; set; }

        public NotFoundDataInfo(string item, object key)
        {
            Item = item;
            Key = key;
        }
    }
}
