using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazi_Business.Requests;
using Bazi_Business.Responses;

namespace Bazi_Business.Interfaces
{
    interface IAirplaneService
    {
        GetAirplaneListResponse GetAirplaneList(GetAirplanesListRequest request);
    }
}
