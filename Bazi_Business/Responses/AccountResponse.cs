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
        public Patnici RegisterdPassenger { get; set; }
    }

    public class RegisterEmployeeResponse : BaseResponse
    {
        public Vraboteni RegisteredEmployee { get; set; }
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
