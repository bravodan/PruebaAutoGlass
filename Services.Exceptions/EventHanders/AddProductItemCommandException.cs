using System;

namespace Services.Exceptions.EventHanders
{
    public class AddProductItemCommandException : Exception
    {
        public AddProductItemCommandException(string message): base(message)
        {
            
        }
    }
}
