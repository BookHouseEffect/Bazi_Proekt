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
        private Patnici GetById(int passengerId, int accountId)
        {
            return Context.Patnici.Where(x => x.PatnikId == passengerId && x.AkauntId == accountId).SingleOrDefault();
        }

        public RepoBaseResponse<Patnici> AddPassengerAccount(RepoAddPassengerAccountRequest request)
        {
            RoleManager roleManager = new RoleManager(this.Context);
            RepoBaseResponse<Ulogi> passengerRole = roleManager.GetRoleByName(new RepoGetRoleByNameRequest { RoleName = "Passenger" });
            if (passengerRole.Status != HttpStatusCode.OK || passengerRole.ReturnedResult == null)
                throw passengerRole.Exception;

            RepoBaseResponse<Patnici> response = new RepoBaseResponse<Patnici>();
            bool accountCreated = false, addressAdded = false, personAdded = false, passengerCreated = false;
            try
            {
                AccountManager accountManager = new AccountManager(this.Context);
                RepoBaseResponse<Akaunti> accountResponse =
                    accountManager.RegisterAccount(new RepoRegisterAccountRequest
                    {
                        Account = request.Account,
                        Role = passengerRole.ReturnedResult,
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

                PersonManager personManager = new PersonManager(this.Context);
                RepoBaseResponse<Lugje> personResponse = personManager.AddNewPerson(new RepoAddNewPersonRequest() { Person = request.Person });
                if (personResponse.Status != HttpStatusCode.OK || personResponse.ReturnedResult == null)
                    throw personResponse.Exception;
                personAdded = true;

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
                passengerCreated = true;
                response.ReturnedResult = passenger;
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

                if (accountCreated && !personAdded)
                    response.Message += "\nThe person information was not saved. Log in to insert data again";

                if (accountCreated && !passengerCreated)
                    response.Message += "\nThe passport information was not saved. Log in to insert data again";
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

                if (updatedAddress.Status != System.Net.HttpStatusCode.OK || updatedAddress.ReturnedResult == null)
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

                if (updatePerson.Status != System.Net.HttpStatusCode.OK || updatePerson.ReturnedResult == null)
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
