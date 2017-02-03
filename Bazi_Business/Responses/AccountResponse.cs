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

    public class RegisterCompanyResponse : BaseResponse
    {
        public Aviokompanii RegisteredCompany { get; set; }
    }

    public class RegisterPassengerResponse : BaseResponse
    {
        //TODO Add body context
    }

    public class RegisterEmployeeResponse : BaseResponse
    {
        //TODO Add body context
    }

    public class GetRegisterableRolesResponse : BaseResponse
    {
        public ICollection<Ulogi> RegistrableRoleList { get; set; }

        public GetRegisterableRolesResponse() : base()
        {
            RegistrableRoleList = new List<Ulogi>();
        }
    }
}
