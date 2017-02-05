using Bazi_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;
using System.Reflection;

namespace Bazi_Repository.Implementation
{
    class AddressManager : BaseManager, IAddressManager
    {

        public AddressManager(): base() { }
        public AddressManager(Db201617zVaProektRnabDataContext e) : base(e) { }

        private Adresi GetById(int id)
        {
            return Context.Adresi.Where(x => x.AdresaId == id).SingleOrDefault();
        }

        private Adresi IsExisting(Adresi address)
        {
            return Context.Adresi.Where(
                x => x.ImeNaUlica == address.ImeNaUlica
                && x.Broj == address.Broj
                && x.Grad == address.Grad
                && x.Oblast == address.Oblast
                && x.Drzhava == address.Drzhava
                && x.PoshtenskiBroj == address.PoshtenskiBroj)
                .SingleOrDefault();
        }

        public RepoBaseResponse<Adresi> AddNewAddress(RepoAddNewAddressRequest request)
        {
            RepoBaseResponse<Adresi> response = new RepoBaseResponse<Adresi>();
            try
            {
                Adresi checkedAddress = IsExisting(request.Address);
                if (checkedAddress != null)
                    response.ReturnedResult = checkedAddress;
                else
                {
                    Adresi address = new Adresi
                    {
                        Broj = request.Address.Broj,
                        Drzhava = request.Address.Drzhava,
                        Grad = request.Address.Grad,
                        ImeNaUlica = request.Address.ImeNaUlica,
                        Oblast = request.Address.Oblast,
                        PoshtenskiBroj = request.Address.PoshtenskiBroj
                    };
                    Context.Adresi.InsertOnSubmit(address);
                    Context.SubmitChanges();
                    response.ReturnedResult = request.Address;
                }
            } catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Adresi> CheckIfAddressExist(RepoCheckIfAddressExistRequest request)
        {
            RepoBaseResponse<Adresi> response = new RepoBaseResponse<Adresi>();
            try
            {
                response.ReturnedResult = IsExisting(request.Address);
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<ICollection<string>> GetAllCities(RepoGetAllCitiesRequest request)
        {
            RepoBaseResponse<ICollection<string>> response = new RepoBaseResponse<ICollection<string>>();
            try
            {
                response.ReturnedResult = Context.Adresi
                    .Where(x => x.Drzhava.Contains(request.StateName)
                    && x.Oblast.Contains(request.RegionName))
                    .Select(x => x.Grad).Distinct().ToList();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<ICollection<string>> GetAllRegions(RepoGetAllRegionsRequest request)
        {
            RepoBaseResponse<ICollection<string>> response = new RepoBaseResponse<ICollection<string>>();
            try
            {
                response.ReturnedResult = Context.Adresi
                    .Where(x => x.Drzhava.Contains(request.StateName))
                    .Select(x => x.Oblast).Distinct().ToList();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<ICollection<string>> GetAllStates()
        {
            RepoBaseResponse<ICollection<string>> response = new RepoBaseResponse<ICollection<string>>();
            try
            {
                response.ReturnedResult = Context.Adresi
                    .Select(x => x.Drzhava).Distinct().ToList();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<ICollection<string>> GetAllStreets(RepoGetAllStreetsRequest request)
        {
            //TODO check for zip codes
            RepoBaseResponse<ICollection<string>> response = new RepoBaseResponse<ICollection<string>>();
            try
            {
                response.ReturnedResult = Context.Adresi
                    .Where(x => x.Drzhava.Contains(request.StateName)
                    && x.Oblast.Contains(request.RegionName)
                    && x.Grad.Contains(request.CityName))
                    .Select(x => x.ImeNaUlica).Distinct().ToList();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Adresi> UpdateAddressInfo(RepoUpdateAddressInfoRequest request)
        {
            RepoBaseResponse<Adresi> response = new RepoBaseResponse<Adresi>();
            try
            {
                Adresi address = GetById(request.AddressId);
                if (address == null)
                    return AddNewAddress(
                        new RepoAddNewAddressRequest { Address = request.NewAddress });
                else
                {
                    Adresi newAddressExistance = IsExisting(request.NewAddress);
                    if (newAddressExistance != null)
                        response.ReturnedResult = newAddressExistance;
                    else
                    {
                        int usageCount = address.Aerodromis_AdresaId.Count() + address.Aviokompaniis_AdresaId.Count() + address.Patnicis_AdresaId.Count();
                        if (usageCount > 1)
                            return AddNewAddress(
                                new RepoAddNewAddressRequest { Address = request.NewAddress });
                        else
                        {
                            address.Broj = request.NewAddress.Broj;
                            address.Drzhava = request.NewAddress.Drzhava;
                            address.Grad = request.NewAddress.Grad;
                            address.ImeNaUlica = request.NewAddress.ImeNaUlica;
                            address.Oblast = request.NewAddress.Oblast;
                            address.PoshtenskiBroj = request.NewAddress.PoshtenskiBroj;

                            Context.SubmitChanges();
                            response.ReturnedResult = address;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }
    }
}
