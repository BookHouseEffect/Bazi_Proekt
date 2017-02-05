using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bazi_Repository
{
    public class RepoBaseResponse<T>
    {
        public HttpStatusCode Status { get; set; }
        public Exception Exception { get; set; }
        public String Message { get; set; }
        public T ReturnedResult { get; set; }

        public RepoBaseResponse()
        {
            Status = HttpStatusCode.OK;
        }

        public void SetResponseProcessingFailed(Exception ex)
        {
            this.Exception = ex;
            this.Message = ex.Message;
            this.Status = System.Net.HttpStatusCode.InternalServerError;
        }
    }
}
