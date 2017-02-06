using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db201617zVaProektRnabContext;

namespace Bazi_Business.Responses
{
    public class GetAirplaneListResponse : BaseResponse
    {
        public ICollection<Avioni> Airplanes;
    }
}
