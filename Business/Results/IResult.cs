using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Results
{
    public interface IResult
    {
        public bool IsError { get; }
        public string Message { get; }
    }
}
