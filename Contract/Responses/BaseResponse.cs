using System;

namespace Contract.Responses
{
    public class BaseResponse
    {
        public SerializationStatus Status { get; set; }
        public bool IsValid { get; set; }
        public string Message { get; set; }

        public static T Do<T>(Func<T> action) where T : BaseResponse, new()
        {
            try
            {
                var result = action();
                result.Status = SerializationStatus.Success;
                return result;
            }
            catch (Exception ex)
            {
                return new T
                {
                    Message = ex.Message,
                    Status = SerializationStatus.Error
                };
            }
        }

        public static BaseResponse DoSuccess(Action action)
        {
            try
            {
                action();
                return new BaseResponse
                {
                    Status = SerializationStatus.Success
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    Message = ex.Message,
                    Status = SerializationStatus.Error
                };
            }
        }
    }

    public enum SerializationStatus
    {
        Success,
        Error,
        Warning
    }
}
