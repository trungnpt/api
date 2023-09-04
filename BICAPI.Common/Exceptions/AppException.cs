namespace BICAPI.Common.Exceptions
{
    public class AppException : Exception
    {
        public string error_code { get; set; }
        public AppException(string _error_code, string _error_message) : base(_error_message)
        {
            error_code = _error_code;
        }
        public AppException(string _error_code) : base(AppMessage.GetMessage(_error_code))
        {
            error_code = _error_code;
        }
    }
}
