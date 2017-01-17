using Db201617zVaProektRnabContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazi_Business.Responses
{
    public class LogInResponse : BaseResponse
    {
        public Akaunti Account { get; set; }
    }

    public class RegisterResponse : BaseResponse
    {

    }
}
