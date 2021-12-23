namespace EmreSavas.MarsRover.Core.Exception
{
    public abstract class BaseException : System.Exception
    {
        public BaseException()
        {

        }

        public BaseException(string message) : base(message)
        {

        }

        public BaseException(int errorCode) : base(errorCode.ToString())
        {

        }
    }
}
