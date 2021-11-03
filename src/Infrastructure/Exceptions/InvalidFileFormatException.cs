using System;

namespace Infrastructure.Exceptions
{
    public class InvalidFileFormatException : Exception
    {
        public InvalidFileFormatException()
        {
        }

        public InvalidFileFormatException(string message) : base(message)
        {
        }
    }
}
