using System;

namespace Northwind.CommonComponents.Exceptions
{
    public class CustomDataException : Exception
    {
        public CustomDataException(string message) : base(message) { }
    }
}
