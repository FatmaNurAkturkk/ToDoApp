using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Common.ResponseObjects
{
    public class Response:IResponse
    {
        public Response(ResponseType responseType)
        {
            responseType = responseType;
        }
        public Response(ResponseType responseType, string message)
        {
            ResponseType = responseType;
            Message = message;
        }
        public string Message { get; set; }
        //public bool IsSuccess { get; set; } burada birçok hatayla karşılaşma durumuna göre enum oluşturduk
        public ResponseType ResponseType { get; set; }
    }
    public enum ResponseType
    {
        Success,
        ValidationError,
        NotFound
    }
}
