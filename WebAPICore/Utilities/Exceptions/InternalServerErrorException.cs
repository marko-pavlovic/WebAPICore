using System;

namespace Utilities.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        private Exception e;

        public InternalServerErrorException()
        {

        }

        public InternalServerErrorException(Exception e)
        {
            this.e = e;
        }

        public InternalServerErrorException(string message) : base(message)
        {
        }
    }
}
