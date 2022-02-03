namespace DBCommunication.Utilities.SimpleObjects
{
    public class NotFoundErrorDataInfo : ErrorDataInfo
    {
        public NotFoundDataInfo DataInfo { get; set; }

        public NotFoundErrorDataInfo(string message, NotFoundDataInfo dataInfo)
            : base(message)
        {
            DataInfo = dataInfo;
        }
    }
}
