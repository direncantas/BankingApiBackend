namespace Business.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(true, message)
        {

        }
        public ErrorResult() : base(true)
        {

        }
    }
}
