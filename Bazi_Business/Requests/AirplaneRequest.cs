using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazi_Business.Requests
{
    public class GetAirplanesListRequest : BaseRequest
    {
        public int CompanyId { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
