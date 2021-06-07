using System;

namespace ERP_API.CustomExceptions
{
    [Serializable]
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message) { }
    }
}
