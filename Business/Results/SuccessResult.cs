namespace Business.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(false, message)
        {

        }
        public SuccessResult() : base(false)
        {

        }
    }
}
