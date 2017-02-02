using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bazi_Business.Responses
{
    public class BaseResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public Exception Exception { get; set; }
        public String Message { get; set; }

        public BaseResponse()
        {
            this.StatusCode = HttpStatusCode.OK;
        }

        public void SetInternalServerErrorMessage(Exception ex)
        {
            this.StatusCode = HttpStatusCode.InternalServerError;
            this.Exception = ex;
            this.Message = "A problem occured in our servers. We are working on it. Please, try again later.";
        }
    }
}
