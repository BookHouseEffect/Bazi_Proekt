using Bazi_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;
using System.Net;

namespace Bazi_Repository.Implementation
{
    public class PassengerManager : BaseManager, IPassengerManager
    {
        public PassengerManager(): base() { }
        public PassengerManager(Db201617zVaProektRnabDataContext e) : base(e) { }

        private Patnici GetById(int passengerId, int accountId)
        {
            return Context.Patnici.Where(x => x.PatnikId == passengerId && x.AkauntId == accountId).SingleOrDefault();
        }

        public RepoBaseResponse<Patnici> AddPassengerAccount(RepoAddPassengerAccountRequest request)
        {
            RoleManager roleManager = new RoleManager(this.Context);
            RepoBaseResponse<Ulogi> passengerRole = roleManager.GetRoleByName(new RepoGetRoleByNameRequest { RoleName = "Passenger" });
            if (passengerRole.HasError())
                throw passengerRole.Exception;

            RepoBaseResponse<Patnici> response = new RepoBaseResponse<Patnici>();

            PersonManager personManager = new PersonManager(this.Context);
            RepoBaseResponse<Lugje> personResponse = null;

            AddressManager addressManager = new AddressManager(this.Context);
            RepoBaseResponse<Adresi> addressResponse = null;

            AccountManager accountManager = new AccountManager(this.Context);
            RepoBaseResponse<Akaunti> accountResponse = null;

            try
            {
                personResponse = personManager.AddNewPerson(new RepoAddNewPersonRequest() { Person = request.Person });
                if (personResponse.HasError())
                    throw personResponse.Exception;

                addressResponse = addressManager.AddNewAddress(new RepoAddNewAddressRequest { Address = request.Address });
                if (accountResponse.HasError())
                    throw addressResponse.Exception;

                accountResponse = accountManager.RegisterAccount(new RepoRegisterAccountRequest
                {
                    Account = request.Account,
                    Role = passengerRole.ReturnedResult,
                    PasswordHash = request.PasswordHash,
                    SecurityStamp = request.SecurityStamp
                });
                if (accountResponse.HasError())
                    throw accountResponse.Exception;

                Patnici passenger = new Patnici
                {
                    AkauntId = accountResponse.ReturnedResult.AkauntId,
                    BrojNaPasosh = request.Passenger.BrojNaPasosh,
                    DatumNaIzdavanje = request.Passenger.DatumNaIzdavanje,
                    Izdadenod = request.Passenger.Izdadenod,
                    DatumNaIstekuvanje = request.Passenger.DatumNaIstekuvanje,
                    Status = request.Passenger.Status,
                    AdresaId = addressResponse.ReturnedResult.AdresaId,
                    CovekId = personResponse.ReturnedResult.CovekId
                };
                Context.Patnici.InsertOnSubmit(passenger);
                Context.SubmitChanges();
                response.ReturnedResult = passenger;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);

                if (personResponse != null)
                {
                    RepoBaseResponse<Lugje> removedPerson = personManager.RemoveUnlinkedPerson(new RepoRemoveUnlinkedPersonRequest { PersonId = personResponse.ReturnedResult.CovekId });
                    if (removedPerson.HasError()) response.Message += removedPerson.Message;
                }

                if (addressResponse != null)
                {
                    RepoBaseResponse<Adresi> removeAddress = addressManager.RemoveUnlikedAddress(new RepoRemoveUnlikedAddressRequest { AddressId = addressResponse.ReturnedResult.AdresaId });
                    if (removeAddress.HasError()) response.Message += removeAddress.Message;
                }

                if (accountResponse != null)
                {
                    RepoBaseResponse<Akaunti> removeAccount = accountManager.RemoveUnlinkedAccount(new RepoRemoveUnlinkedAccountRequest { Id = accountResponse.ReturnedResult.AkauntId });
                    if (removeAccount.HasError()) response.Message += removeAccount.Message;
                }
            }

            return response;
        }

        public RepoBaseResponse<Patnici> GetPassengerAccountById(RepoGetPassengerAccountByIdRequest request)
        {
            RepoBaseResponse<Patnici> response = new RepoBaseResponse<Patnici>();
            try
            {
                response.ReturnedResult = GetById(request.PassengerId, request.AccountId);
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Patnici> GetPassengerAccountByPassport(RepoGetPassengerAccountByPassportRequest request)
        {
            RepoBaseResponse<Patnici> response = new RepoBaseResponse<Patnici>();
            try
            {
                response.ReturnedResult = Context.Patnici.Where(x => x.BrojNaPasosh == request.PassportNumber && x.AkauntId == request.AccountId).Single();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<ICollection<Patnici>> GetPassengersByAccount(RepoGetPassengersByAccountRequest request)
        {
            RepoBaseResponse<ICollection<Patnici>> response = new RepoBaseResponse<ICollection<Patnici>>();
            try
            {
                response.ReturnedResult = Context.Patnici.Where(x => x.AkauntId == request.AccountId).ToList();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Patnici> UpdatePassengerAddressInfo(RepoUpdatePassengerAddressInfoRequest request)
        {
            RepoBaseResponse<Patnici> response = new RepoBaseResponse<Patnici>();

            try
            {
                Patnici currentPassenger = GetById(request.PassengerId, request.AccountId);
                if (currentPassenger == null)
                    throw new Exception("The passenger does not exist.");

                AddressManager addressManager = new AddressManager(this.Context);
                RepoBaseResponse<Adresi> updatedAddress = addressManager.UpdateAddressInfo(new RepoUpdateAddressInfoRequest
                {
                    AddressId = currentPassenger.AdresaId,
                    NewAddress = request.NewAddress
                });

                if (updatedAddress.HasError())
                    throw updatedAddress.Exception;

                currentPassenger.AdresaId = updatedAddress.ReturnedResult.AdresaId;
                Context.SubmitChanges();
                response.ReturnedResult = currentPassenger;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Patnici> UpdatePassengerPersonInfo(RepoUpdatePassengerPersonInfoRequest request)
        {
            RepoBaseResponse<Patnici> response = new RepoBaseResponse<Patnici>();

            try
            {
                Patnici currentPassenger = GetById(request.PassengerId, request.AccountId);
                if (currentPassenger == null)
                    throw new Exception("The passenger does not exist.");

                PersonManager personManager = new PersonManager(this.Context);
                RepoBaseResponse<Lugje> updatePerson = personManager.UpdatePersonInfo(new RepoUpdatePersonInfoRequest {
                    PersonId = currentPassenger.CovekId,
                    NewPerson = request.NewPerson
                });

                if (updatePerson.HasError())
                    throw updatePerson.Exception;

                currentPassenger.CovekId = updatePerson.ReturnedResult.CovekId;
                Context.SubmitChanges();
                response.ReturnedResult = currentPassenger;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Patnici> UpdatePassengerInfo(RepoUpdatePassengerInfoRequest request)
        {
            RepoBaseResponse<Patnici> response = new RepoBaseResponse<Patnici>();
            try
            {
                Patnici currentPassenger = GetById(request.PassengerId, request.AccountId);
                if (currentPassenger == null)
                    throw new Exception("The passenger does not exist.");

                currentPassenger.BrojNaPasosh = request.NewPassenger.BrojNaPasosh;
                currentPassenger.DatumNaIzdavanje = request.NewPassenger.DatumNaIzdavanje;
                currentPassenger.Izdadenod = request.NewPassenger.Izdadenod;
                currentPassenger.DatumNaIstekuvanje = request.NewPassenger.DatumNaIstekuvanje;
                currentPassenger.Status = request.NewPassenger.Status;
                Context.SubmitChanges();
                response.ReturnedResult = currentPassenger;
            }
            catch(Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }
    }
}
