using Bazi_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;

namespace Bazi_Repository.Implementation
{
    public class AirportManager : BaseManager, IAirportManager
    {

        private Aerodromi GetById(Int32 id)
        {
            return Context.Aerodromi.Where(x => x.AerodromId == id).SingleOrDefault();
        }

        public ICollection<Aerodromi> GetAirportsList()
        {
            return this.Context.Aerodromi.ToList();
        }

        public RepoBaseResponse<Aerodromi> AddNewAirport(RepoAddNewAirportRequest request)
        {
            RepoBaseResponse<Aerodromi> response = new RepoBaseResponse<Aerodromi>();
            AddressManager addressManager = new AddressManager(this.Context);
            RepoBaseResponse<Adresi> address = null;
            try
            {
                address = addressManager.AddNewAddress(new RepoAddNewAddressRequest { Address = request.Address });
                if (address.HasError())
                    throw address.Exception;

                Aerodromi airport = new Aerodromi { AdresaId = address.ReturnedResult.AdresaId, ImeNaAerodrom = request.Name, GeografskaDolzina = request.Longitude, GeografskaSirina = request.Latitude };

                Context.Aerodromi.InsertOnSubmit(airport);
                Context.SubmitChanges();
                response.ReturnedResult = airport;
            } catch(Exception ex)
            {
                if (address != null) {
                    RepoBaseResponse<Adresi> addressToRemove = addressManager.RemoveUnlikedAddress(new RepoRemoveUnlikedAddressRequest { AddressId = address.ReturnedResult.AdresaId });
                    if (addressToRemove.HasError())
                        response.SetResponseProcessingFailed(addressToRemove.Exception);
                    else
                        response.SetResponseProcessingFailed(ex);
                } else
                    response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Aerodromi> GetAirportById(RepoGetAirportByIdRequest request)
        {
            RepoBaseResponse<Aerodromi> response = new RepoBaseResponse<Aerodromi>();
            try
            {
                response.ReturnedResult = GetById(request.AirportId);
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<ICollection<Aerodromi>> GetAirportsByAddress(RepoGetAirportsByAddressRequest request)
        {
            RepoBaseResponse<ICollection<Aerodromi>> response = new RepoBaseResponse<ICollection<Aerodromi>>();
            try
            {
                AddressManager addressManager = new AddressManager(this.Context);
                RepoBaseResponse<Adresi> addressResponse = addressManager.CheckIfAddressExist(new RepoCheckIfAddressExistRequest { Address = request.Address });
                if (addressResponse.HasError())
                    throw new Exception("The address does not exists");

                response.ReturnedResult = Context.Aerodromi.Where(x => x.AdresaId == addressResponse.ReturnedResult.AdresaId).ToList();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<ICollection<Aerodromi>> GetAirportsByName(RepoGetAirportsByNameRequest request)
        {
            RepoBaseResponse<ICollection<Aerodromi>> response = new RepoBaseResponse<ICollection<Aerodromi>>();
            try
            {
                response.ReturnedResult = Context.Aerodromi.Where(x => x.ImeNaAerodrom == request.Name).ToList();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Aerodromi> UpdateAirportAddressInfo(RepoUpdateAirportAddressInfoRequest request)
        {
            RepoBaseResponse<Aerodromi> response = new RepoBaseResponse<Aerodromi>();
            AddressManager addressManager = new AddressManager(this.Context);
            RepoBaseResponse<Adresi> addressResponse = null;
            try
            {
                Aerodromi airport = GetById(request.AirportId);
                if (airport == null) throw new Exception("The airport does not exist.");

                addressResponse = addressManager.AddNewAddress(new RepoAddNewAddressRequest { Address = request.NewAddress });
                if (addressResponse.HasError()) throw addressResponse.Exception;

                airport.AdresaId = addressResponse.ReturnedResult.AdresaId;
                Context.SubmitChanges();
                response.ReturnedResult = airport;
            }
            catch (Exception ex)
            {
                if (addressResponse.ReturnedResult != null)
                {
                    RepoBaseResponse<Adresi> addressToRemove = addressManager.RemoveUnlikedAddress(new RepoRemoveUnlikedAddressRequest { AddressId = addressResponse.ReturnedResult.AdresaId });
                    if (addressToRemove.HasError())
                        response.SetResponseProcessingFailed(addressToRemove.Exception);
                    else
                        response.SetResponseProcessingFailed(ex);
                }
                else
                {
                    response.SetResponseProcessingFailed(ex);
                }
            }
            return response;
        }

        public RepoBaseResponse<Aerodromi> UpdateAirportLocationInfo(RepoUpdateAirportLocationInfoRequest request)
        {
            RepoBaseResponse<Aerodromi> response = new RepoBaseResponse<Aerodromi>();
            try
            {
                Aerodromi airport = GetById(request.AirportId);
                if (airport == null) throw new Exception("The airport does not exist.");

                airport.GeografskaDolzina = request.NewLongitute;
                airport.GeografskaSirina = request.NewLatitude;
                Context.SubmitChanges();
                response.ReturnedResult = airport;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Aerodromi> UpdateAirportNameInfo(RepoUpdateAirportNameInfoRequest request)
        {
            RepoBaseResponse<Aerodromi> response = new RepoBaseResponse<Aerodromi>();
            try
            {
                Aerodromi airport = GetById(request.AirportId);
                if (airport == null) throw new Exception("The airport does not exist.");

                airport.ImeNaAerodrom = request.NewName;
                Context.SubmitChanges();
                response.ReturnedResult = airport;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }
    }
}
