using System;

namespace Business.Results
{
    public class Result : IResult
    {
        public Result(bool isError, string message) : this(isError)
        {
            Message = message;
        }
        public Result(bool isError)
        {
            IsError = isError;
        }
        public bool IsError { get; }

        public string Message { get; }
    }
}
