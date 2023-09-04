namespace BICAPI.Common.Exceptions
{
    public class SqlDbException : Exception
    {
        public string error_code { get; set; }
        public SqlDbException(Exception ex) : base(GetMessage(ex))
        {
            error_code = GetCode(ex);
        }
        private static string GetMessage(Exception ex)
        {
            string errorCode = ex.Message;
            int firstIndex = errorCode.ToLower().IndexOf("loi:");
            int lastIndex = errorCode.ToLower().LastIndexOf(":loi");
            if (firstIndex == -1 || lastIndex == -1)
            {
                return errorCode;
            }
            string code = errorCode.Substring(firstIndex + 4, lastIndex - firstIndex - 4);
            if (code.StartsWith("["))
            {
                int indexErrorCode = code.IndexOf("]");
                if (indexErrorCode < 0)
                    indexErrorCode = code.Length;
                code = code.Substring(indexErrorCode+1, code.Length - indexErrorCode - 1);
            }
            return code;
        }
        private string GetCode(Exception ex)
        {
            error_code = "500";
            string errorCode = ex.Message;
            int firstIndex = errorCode.ToLower().IndexOf("loi:");
            int lastIndex = errorCode.ToLower().LastIndexOf(":loi");
            if (firstIndex == -1 || lastIndex == -1)
            {
                return "500";
            }
            string code = errorCode.Substring(firstIndex + 4, lastIndex - firstIndex - 4);
            if (code.StartsWith("["))
            {
                int indexErrorCode = code.IndexOf("]");
                if (indexErrorCode < 0)
                    indexErrorCode = code.Length;
                error_code = code.Substring(1, indexErrorCode - 1);
            }
            return error_code;
        }
    }
}
