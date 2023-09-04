using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICAPI.Common
{
    public class BaseResponse<T>
    {
        public BaseResponseHeader header { get; set; }
        public T body { get; set; }
        public BaseResponse()
        {
            header = new BaseResponseHeader();
            header.errorInfo.errorCode = "00";
        }
        public BaseResponse(string errorCode, string errorDesc)
        {
            header = new BaseResponseHeader();
            header.errorInfo = new BaseResponseErrorInfo();
            header.errorInfo.errorCode = errorCode;
            header.errorInfo.errorDesc = errorDesc;
        }
    }
    public class BaseResponseHeader
    {
        public string requestId { get; set; }
        public int status { get; set; }
        public BaseResponseErrorInfo errorInfo { get; set; }
        public BaseResponseHeader()
        {
            requestId = Guid.NewGuid().ToString("N");
            status = 1;
            errorInfo = new BaseResponseErrorInfo();
        }
    }
    public class BaseResponseErrorInfo
    {
        public string errorSource { get; set; }
        public string errorCode { get; set; }
        public string errorDesc { get; set; }
        public BaseResponseErrorInfo()
        {
            errorSource = "BICST";
        }
    }
}
