using Bazi_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;

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
                response.ReturnedResult = GetById(request.CompanyId);
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
                response.ReturnedResult = Context.Aviokompanii.Where(x => x.ImeNaKompanija.Contains(request.CompanyName))
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize).ToList();
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
            RepoBaseResponse<Aviokompanii> response = new RepoBaseResponse<Aviokompanii>();

            AccountManager accountManager = new AccountManager(this.Context);
            RepoBaseResponse<Akaunti> accountResponse = null;

            AddressManager addressManager = new AddressManager(this.Context);
            RepoBaseResponse<Adresi> addressResponse = null;
            try
            {
                RoleManager roleManager = new RoleManager(this.Context);
                RepoBaseResponse<Ulogi> companyRole = roleManager.GetRoleByName(new RepoGetRoleByNameRequest { RoleName = "Company" });
                if (companyRole.HasError())
                    throw companyRole.Exception;

                accountResponse = accountManager.RegisterAccount(new RepoRegisterAccountRequest {
                        Account = request.Account,
                        Role = companyRole.ReturnedResult,
                        PasswordHash = request.PasswordHash,
                        SecurityStamp = request.SecurityStamp
                    });
                if (accountResponse.HasError())
                    throw accountResponse.Exception;

                addressResponse = addressManager.AddNewAddress(new RepoAddNewAddressRequest { Address = request.Address });
                if (accountResponse.HasError())
                    throw accountResponse.Exception;

                Aviokompanii company = new Aviokompanii
                {
                    ImeNaKompanija = request.CompanyName,
                    AkauntId = accountResponse.ReturnedResult.AkauntId,
                    AdresaId = addressResponse.ReturnedResult.AdresaId
                };
                Context.Aviokompanii.InsertOnSubmit(company);
                Context.SubmitChanges();
                response.ReturnedResult = company;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);

                if (accountResponse != null)
                {
                    RepoBaseResponse<Akaunti> removeAccount = accountManager.RemoveUnlinkedAccount(new RepoRemoveUnlinkedAccountRequest { Id = accountResponse.ReturnedResult.AkauntId });
                    if (removeAccount.HasError()) response.Message += removeAccount.Message;
                }

                if (addressResponse != null)
                {
                    RepoBaseResponse<Adresi> removeAddress = addressManager.RemoveUnlikedAddress(new RepoRemoveUnlikedAddressRequest { AddressId = addressResponse.ReturnedResult.AdresaId });
                    if (removeAddress.HasError()) response.Message += removeAddress.Message;
                }
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

                if (updatedAddress.HasError())
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
