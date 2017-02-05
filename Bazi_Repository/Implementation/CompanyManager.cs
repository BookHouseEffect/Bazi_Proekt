using Bazi_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;
using System.Net;

namespace Bazi_Repository.Implementation
{
    public class CompanyManager : BaseManager, ICompanyManager
    {

        public CompanyManager(): base() { }
        public CompanyManager(Db201617zVaProektRnabDataContext e) : base(e) { }

        private Aviokompanii GetById(int id)
        {
            return Context.Aviokompanii.Where(x => x.KompanijaId == id).Single();
        }

        public RepoBaseResponse<Aviokompanii> GetCompanyById(RepoGetCompanyByIdRequest request)
        {
            RepoBaseResponse<Aviokompanii> response = new RepoBaseResponse<Aviokompanii>();
            try
            {
                response.ReturnedResult = GetById(request.Id);
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<ICollection<Aviokompanii>> GetCompaniesByName(RepoGetCompaniesByNameRequest request)
        {
            RepoBaseResponse<ICollection<Aviokompanii>> response = new RepoBaseResponse<ICollection<Aviokompanii>>();
            try
            {
                response.ReturnedResult = Context.Aviokompanii.Where(x => x.ImeNaKompanija.Contains(request.CompanyName)).ToList();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<ICollection<Aviokompanii>> GetCompanyList(RepoGetCompanyListRequest request)
        {
            RepoBaseResponse<ICollection<Aviokompanii>> response = new RepoBaseResponse<ICollection<Aviokompanii>>();
            try
            {
                response.ReturnedResult = Context.Aviokompanii
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize).ToList();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Aviokompanii> RegisterCompany(RepoRegisterCompanyRequest request)
        {
            RoleManager roleManager = new RoleManager(this.Context);
            RepoBaseResponse<Ulogi> companyRole = roleManager.GetRoleByName(new RepoGetRoleByNameRequest { RoleName = "Company" });
            if (companyRole.Status != HttpStatusCode.OK || companyRole.ReturnedResult == null)
                throw companyRole.Exception;

            RepoBaseResponse<Aviokompanii> response = new RepoBaseResponse<Aviokompanii>();
            bool accountCreated = false, addressAdded = false, companyCreated = false;
            try
            {
                AccountManager accountManager = new AccountManager(this.Context);
                RepoBaseResponse<Akaunti> accountResponse =
                    accountManager.RegisterAccount(new RepoRegisterAccountRequest
                    {
                        Account = request.Account,
                        Role = companyRole.ReturnedResult,
                        PasswordHash = request.PasswordHash,
                        SecurityStamp = request.SecurityStamp
                    });
                if (accountResponse.Status != HttpStatusCode.OK ||
                     accountResponse.ReturnedResult == null)
                    throw accountResponse.Exception;
                accountCreated = true;

                AddressManager addressManager = new AddressManager(this.Context);
                RepoBaseResponse<Adresi> addressResponse =
                    addressManager.AddNewAddress(new RepoAddNewAddressRequest
                    { Address = request.Address });
                if (accountResponse.Status != HttpStatusCode.OK ||
                     accountResponse.ReturnedResult == null)
                    throw accountResponse.Exception;
                addressAdded = true;

                Aviokompanii company = new Aviokompanii
                {
                    ImeNaKompanija = request.CompanyName,
                    AkauntId = accountResponse.ReturnedResult.AkauntId,
                    AdresaId = addressResponse.ReturnedResult.AdresaId
                };
                Context.Aviokompanii.InsertOnSubmit(company);
                Context.SubmitChanges();
                response.ReturnedResult = company;
                companyCreated = true;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
                if (!accountCreated)
                    response.Message += "\nThe account couldn't be created.";
                else
                    response.Message += "\nThe account is created.";

                if (accountCreated && !addressAdded)
                    response.Message += "\nThe address information was not saved. Log in to insert data again.";

                if (accountCreated && !companyCreated)
                    response.Message += "\nThe company information was not saved. Log in to insert data again";
            }

            return response;
        }

        public RepoBaseResponse<Aviokompanii> UpdateCompanyAddressInfo(RepoUpdateCompanyAddressInfoRequest request)
        {
            RepoBaseResponse<Aviokompanii> response = new RepoBaseResponse<Aviokompanii>();

            try
            {
                Aviokompanii currentCompany = Context.Aviokompanii.Where(x => x.AkauntId == request.AccountId
                    && x.KompanijaId == request.CompanyId).SingleOrDefault();
                if (currentCompany == null)
                    throw new Exception("The company does not exist.");

                AddressManager addressManager = new AddressManager(this.Context);
                RepoBaseResponse<Adresi> updatedAddress = addressManager.UpdateAddressInfo(new RepoUpdateAddressInfoRequest
                {
                    AddressId = currentCompany.AdresaId,
                    NewAddress = request.NewAddress
                });

                if (updatedAddress.Status != System.Net.HttpStatusCode.OK || updatedAddress.ReturnedResult == null)
                    throw updatedAddress.Exception;

                currentCompany.AdresaId = updatedAddress.ReturnedResult.AdresaId;
                Context.SubmitChanges();
                response.ReturnedResult = currentCompany;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Aviokompanii> UpdateCompanyInfo(RepoUpdateCompanyInfoRequest request)
        {
            RepoBaseResponse<Aviokompanii> response = new RepoBaseResponse<Aviokompanii>();

            try
            {
                Aviokompanii currentCompany = Context.Aviokompanii.Where(x => x.AkauntId == request.AccountId
                    && x.KompanijaId == request.CompanyId).SingleOrDefault();
                if (currentCompany == null)
                    throw new Exception("The company does not exist.");

                currentCompany.ImeNaKompanija = request.NewCompanyName;
                Context.SubmitChanges();
                response.ReturnedResult = currentCompany;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Aviokompanii> GetCompanyByAccountId(RepoGetCompanyByAccountIdRequest request)
        {
            RepoBaseResponse<Aviokompanii> response = new RepoBaseResponse<Aviokompanii>();
            try
            {
                response.ReturnedResult = Context.Aviokompanii.Where(x => x.AkauntId == request.AccountId).Single();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }
    }
}
