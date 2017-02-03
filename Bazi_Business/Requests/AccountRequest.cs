using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db201617zVaProektRnabContext;

namespace Bazi_Business.Requests
{
    public abstract class PasswordRequest : BaseRequest
    {
        public string Password { get; set; }
    }

    public class LogInRequest : PasswordRequest
    {
        public string Username { get; set; }
    }

    public class RegisterCompanyRequest : PasswordRequest
    {
        public Adresi CompanyAddress { get; set; }
        public Akaunti CompanyAccount { get; set; }
        public Aviokompanii Company { get; set; }
    }

    public class RegisterPassengerRequest : PasswordRequest
    {
        public Akaunti PassengerAccount { get; set; }
        public Lugje Person { get; set; }
        public Adresi PassengerAddress{get;set;}
        public Patnici Passenger { get; set; }
    }

    public class RegisterEmployeeRequest : PasswordRequest
    {
        public Akaunti EmployeeAccount { get; set; }
        public Lugje Person { get; set; }
        public Vraboteni Employee { get; set; }
        public Int32 CompanyAccountId { get; set; }
    }
}
