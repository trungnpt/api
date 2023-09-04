using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BICAPI.Common
{
    public static class AppMessage
    {
        public const string BadRequest = "400";
        public const string UnAuthor = "401";
        public const string NotFound = "404";
        public const string ConnectionFailed = "300";

        private static IDictionary<string, string> lstError = new Dictionary<string, string>()
        {
            { AppMessage.BadRequest, "Request không hợp lệ" },
            { AppMessage.UnAuthor, "Không có quyền truy cập" },
            { AppMessage.NotFound, "Tham số không được rỗng" },
            { AppMessage.ConnectionFailed, "Kết nối Database không thành công" }
        };

        public static string GetMessage(string statusCode)
        {
            if (lstError.ContainsKey(statusCode))
                return lstError[statusCode];
            return "Nội dung chưa được cấu hình (AppMessage)";
        }
    }
}
