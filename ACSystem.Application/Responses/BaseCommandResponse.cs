using ACSystem.Infrastructure.Const;
using Microsoft.AspNetCore.Http;

namespace ACSystem.Application.Responses
{
    public class BaseCommandResponse
    {
        public object Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public int StatusCode { get; set; }

        public List<string> Errors { get; set; }
     

        public void Success(object data = null, string message = null, List<string> errors = null)
        {
            IsSuccess = true;
            Message = message ?? DefaultConst.Success;
            Errors = errors;
            StatusCode = DefaultConst.SuccessCode;
            Data = data;
           
        }


        public void Failure(object data = null, string message = null, List<string> errors = null)
        {
            IsSuccess = false;
            Message = message ?? DefaultConst.Failure;
            Errors = errors;
            StatusCode = DefaultConst.FailureCode;
            Data = data;
            
        }

    }
}
