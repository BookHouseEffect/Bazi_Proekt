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
    }
}
