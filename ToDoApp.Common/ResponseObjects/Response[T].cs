using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Common.ResponseObjects
{
    public class Response<T> :Response, IResponse<T>
    {
        public T Data { get; set; }
        public Response(ResponseType responseType, T data):base(responseType)
        {
            Data = data;
        }
        public Response(ResponseType responseType, T data, List<CustomValidationError> errors) : base(responseType)
        {
            ValidationErrors = errors;
            Data = data;
        }
        public Response(ResponseType responseType,string message) : base(responseType, message)
        {

        }
        public List<CustomValidationError> ValidationErrors { get; set; }
    }
}
