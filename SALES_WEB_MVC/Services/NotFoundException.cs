





namespace SALES_WEB_MVC.Services
{
    [Serializable]
    internal class NotFoundException : System.Exception
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string? message) : base(message)
        {
        }

        public NotFoundException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }
    }
}