using Db201617zVaProektRnabContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazi_Business.Responses
{
    public class GetFlightListResponse : BaseResponse
    {
        public ICollection<Letovi> Flights { get; set; }
    }
}
