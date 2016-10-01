using System;

namespace Contract.Responses
{
    public class BaseResponse
    {
        public SerializationStatus Status { get; set; }
        public bool IsValid { get; set; }
        public string Message { get; set; }
    }

    public enum SerializationStatus
    {
        Success,
        Error,
        Warning
    }
}
