namespace EmreSavas.MarsRover.Core.Exception
{
    public class BusinessException : BaseException
    {
        public BusinessException()
        {

        }

        public BusinessException(int errorCode) : base(errorCode)
        {

        }

        public BusinessException(string message) : base(message)
        {

        }

        public BusinessException(int errorCode, string message) : base(string.Join(" ", errorCode, message))
        {

        }
    }
}
