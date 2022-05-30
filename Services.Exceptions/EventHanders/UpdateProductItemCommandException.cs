using System;

namespace Services.Exceptions.EventHanders
{
    public class UpdateProductItemCommandException : Exception
    {
        public UpdateProductItemCommandException(string message) : base(message)
        {

        }
    }
}
