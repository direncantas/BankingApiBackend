using System;

namespace Business.Results
{
    public class Result : IResult
    {
        public Result(bool isError, string message) : this(isError)
        {
            Random rnd = new Random();
            this.ReferenceNumber = rnd.Next(9999999);
            Message = message;
        }
        public Result(bool isError)
        {
            IsError = isError;
        }
        public bool IsError { get; }

        public string Message { get; }
        public int ReferenceNumber { get; set; }
    }
}
