using System;
using DBCommunication.Utilities.SimpleObjects;

namespace DBCommunication.Utilities.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundDataInfo DataInfo { get; set; }

        public NotFoundException(string message) 
            : base(message)
        {
        }

        public NotFoundException(string item, object key)
            : base(item + " with key: " + key + " is not found!")
        {
            DataInfo = new NotFoundDataInfo(item, key);
        }
    }
}
