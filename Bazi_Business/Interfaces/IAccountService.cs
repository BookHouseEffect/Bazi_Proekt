using Bazi_Business.Requests;
using Bazi_Business.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazi_Business.Interfaces
{
    interface IAccountService
    {
        LogInResponse LogIn(LogInRequest request);
        RegisterCompanyResponse RegisterCompany(RegisterCompanyRequest request);
        RegisterPassengerResponse RegisterPassenger(RegisterPassengerRequest request);
        RegisterEmployeeResponse RegisterEmployee(RegisterEmployeeRequest request);
        ChangePasswordResponse ChangePassword(ChangePasswordRequest request);
        GetCompanyInfoResponse GetComapnyInfo(GetCompanyInfoRequest request);
        GetPassengerInfoResponse GetPassengerInfo(GetPassengerInfoRequest request);
        UpdateCompanyResponse UpdateCompany(UpdateCompanyRequest request);
        UpdatePassengerResponse UpdatePassenger(UpdatePassengerRequest request);
    }
}
