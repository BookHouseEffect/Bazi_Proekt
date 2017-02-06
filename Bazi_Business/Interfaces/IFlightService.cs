using Bazi_Business.Requests;
using Bazi_Business.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazi_Business.Interfaces
{
    interface IFlightService
    {
        GetFlightListResponse GetFlightList(GetFlightListRequest request);
    }
}
