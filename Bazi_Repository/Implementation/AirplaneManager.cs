using Bazi_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;

namespace Bazi_Repository.Implementation
{
    public class AirplaneManager : BaseManager, IAirplaneManager
    {
        private Avioni IsExisting(String registry)
        {
            return Context.Avioni.Where(x => x.Registracija == registry).SingleOrDefault();
        }

        private Avioni IsExisting(Int32 airplaneId, Int32 companyId)
        {
            return Context.Avioni.Where(x => x.AvionId == airplaneId && x.KompanijaId == companyId).SingleOrDefault();
        }

        public RepoBaseResponse<Avioni> AddCompanyAirplane(RepoAddCompanyAirplaneRequest request)
        {
            RepoBaseResponse<Avioni> response = new RepoBaseResponse<Avioni>();
            try
            {
                if (IsExisting(request.Registry) != null)
                    throw new Exception("The airplane with this registry already exist. Check your data.");

                CompanyManager companyManager = new CompanyManager(this.Context);
                RepoBaseResponse<Aviokompanii> companyResponse = companyManager.GetCompanyById(new RepoGetCompanyByIdRequest { CompanyId = request.CompanyId });

                if (companyResponse.HasError())
                    throw companyResponse.Exception;

                AirplaneTypeManager airplaneTypeManager = new AirplaneTypeManager(this.Context);
                RepoBaseResponse<TipNaAvioni> typeResponse = airplaneTypeManager.AddNewType(new RepoAddNewTypeRequest { Type = request.Type });

                if (typeResponse.HasError())
                    throw typeResponse.Exception;

                Avioni newAirPlane = new Avioni { ImeNaAvion = request.Name, Registracija = request.Registry, KompanijaId = request.CompanyId, TipId = typeResponse.ReturnedResult.TipId };
                Context.Avioni.InsertOnSubmit(newAirPlane);
                Context.SubmitChanges();

            } catch(Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Avioni> GetCompanyAirplaneById(RepoGetCompanyAirplaneByIdRequest request)
        {
            RepoBaseResponse<Avioni> response = new RepoBaseResponse<Avioni>();
            try
            {
                response.ReturnedResult = IsExisting(request.AirplaneId, request.CompanyId);
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Avioni> GetCompanyAirplaneByRegistry(RepoGetCompanyAirplaneByRegistryRequest request)
        {
            RepoBaseResponse<Avioni> response = new RepoBaseResponse<Avioni>();
            try
            {
                response.ReturnedResult = Context.Avioni.Where(x => x.KompanijaId == request.CompanyId && x.Registracija == request.Registry).SingleOrDefault();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<ICollection<Avioni>> GetCompanyAirplanes(RepoGetCompanyAirplanesRequest request)
        {
            RepoBaseResponse<ICollection<Avioni>> response = new RepoBaseResponse<ICollection<Avioni>>();
            try
            {
                response.ReturnedResult = Context.Avioni.Where(x => x.KompanijaId == request.CompanyId).Skip((request.PageNumber-1)*request.PageSize).Take(request.PageSize).ToList();
            } catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<ICollection<Avioni>> GetCompanyAirplanesByType(RepoGetCompanyAirplanesByTypeRequest request)
        {
            RepoBaseResponse<ICollection<Avioni>> response = new RepoBaseResponse<ICollection<Avioni>>();
            try
            {
                AirplaneTypeManager airplaneTypeManage = new AirplaneTypeManager(this.Context);
                RepoBaseResponse<TipNaAvioni> typeResponse = airplaneTypeManage.CheckIfTypeExist(new RepoCheckIfTypeExistRequest { Type = request.Type });
                if (typeResponse.HasError())
                    throw typeResponse.Exception;

                response.ReturnedResult = Context.Avioni.Where(x => x.KompanijaId == request.CompanyId && x.TipId == request.Type.TipId).Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Avioni> TransferAirplaneToNewCompany(RepoTransferAirplaneToNewCompanyRequest request)
        {
            RepoBaseResponse<Avioni> response = new RepoBaseResponse<Avioni>();
            try
            {
                Avioni airplane = IsExisting(request.AirplaneToTransfer.AvionId, request.OldCompanyId);
                if (airplane == null)
                    throw new Exception("Transfer can not be made, because this company does not possess the airplane.");

                CompanyManager companyManager = new CompanyManager(this.Context);
                RepoBaseResponse<Aviokompanii> companyResponse = companyManager.GetCompanyById(new RepoGetCompanyByIdRequest { CompanyId = request.NewCompanyId });
                if (companyResponse.HasError())
                    throw companyResponse.Exception;

                airplane.KompanijaId = companyResponse.ReturnedResult.KompanijaId;
                Context.SubmitChanges();
                response.ReturnedResult = airplane;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Avioni> UpdateCompanyAirplaneName(RepoUpdateCompanyAirplaneNameRequest request)
        {
            RepoBaseResponse<Avioni> response = new RepoBaseResponse<Avioni>();
            try
            {
                Avioni airplane = IsExisting(request.AirplaneId, request.CompanId);
                if (airplane == null)
                    throw new Exception("The airplane does not exists.");

                airplane.ImeNaAvion = request.NewName;
                Context.SubmitChanges();
                response.ReturnedResult = airplane;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Avioni> UpdateCompanyAirplaneRegistry(RepoUpdateCompanyAirplaneRegistryRequest request)
        {
            RepoBaseResponse<Avioni> response = new RepoBaseResponse<Avioni>();
            try
            {
                Avioni airplane = IsExisting(request.AirplaneId, request.CompanId);
                if (airplane == null)
                    throw new Exception("The airplane does not exists.");

                if (IsExisting(request.NewRegistry) != null)
                    throw new Exception("The registry already exists.");

                airplane.Registracija = request.NewRegistry;
                Context.SubmitChanges();
                response.ReturnedResult = airplane;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }
    }
}
