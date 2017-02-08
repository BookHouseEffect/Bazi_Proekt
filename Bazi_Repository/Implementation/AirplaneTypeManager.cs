using Bazi_Repository.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;

namespace Bazi_Repository.Implementation
{
    public class AirplaneTypeManager : BaseManager, IAirplaneTypeManager
    {
        public AirplaneTypeManager() : base() { }
        public AirplaneTypeManager(Db201617zVaProektRnabDataContext e) : base(e) { }

        private TipNaAvioni IsExisting(TipNaAvioni tip)
        {
            return Context.TipNaAvioni.Where(
                x => x.BrojNaPatnici == tip.BrojNaPatnici
                && x.MaxDimenziiDolzhina == tip.MaxDimenziiDolzhina
                && x.MaxDimenziiShirina == tip.MaxDimenziiShirina
                && x.MaxDimenziiVisina == tip.MaxDimenziiVisina
                && x.MaxMasaBadazh == tip.MaxMasaBadazh).SingleOrDefault();
        }

        private TipNaAvioni GetById(Int32 id)
        {
            return Context.TipNaAvioni.Where(x => x.TipId == id).SingleOrDefault();
        }

        public RepoBaseResponse<TipNaAvioni> AddNewType(RepoAddNewTypeRequest request)
        {
            RepoBaseResponse<TipNaAvioni> response = new RepoBaseResponse<TipNaAvioni>();
            try
            {
                TipNaAvioni type = IsExisting(request.Type);
                if (type != null)
                    response.ReturnedResult = type;
                else
                {
                    TipNaAvioni newType = new TipNaAvioni
                    {
                        BrojNaPatnici = request.Type.BrojNaPatnici,
                        MaxDimenziiDolzhina = request.Type.MaxDimenziiDolzhina,
                        MaxDimenziiShirina = request.Type.MaxDimenziiShirina,
                        MaxDimenziiVisina = request.Type.MaxDimenziiVisina,
                        MaxMasaBadazh = request.Type.MaxMasaBadazh
                    };
                    Context.TipNaAvioni.InsertOnSubmit(newType);
                    Context.SubmitChanges();
                    response.ReturnedResult = newType;
                }
            } catch(Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<TipNaAvioni> CheckIfTypeExist(RepoCheckIfTypeExistRequest request)
        {
            RepoBaseResponse<TipNaAvioni> response = new RepoBaseResponse<TipNaAvioni>();
            try
            {
                response.ReturnedResult = IsExisting(request.Type);
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<ICollection<TipNaAvioni>> GetAllTypes(RepoGetAllTypesRequest request)
        {
            RepoBaseResponse<ICollection<TipNaAvioni>> response = new RepoBaseResponse<ICollection<TipNaAvioni>>();
            try
            {
                response.ReturnedResult = Context.TipNaAvioni.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<TipNaAvioni> GetTypeById(RepoGetTypeByIdRequest request)
        {
            RepoBaseResponse<TipNaAvioni> response = new RepoBaseResponse<TipNaAvioni>();
            try
            {
                response.ReturnedResult = GetById(request.TypeId);
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<TipNaAvioni> RemoveTypeIfNotAssigned(RepoRemoveTypeIfNotAssignedRequest request)
        {
            RepoBaseResponse<TipNaAvioni> response = new RepoBaseResponse<TipNaAvioni>();
            try
            {
                TipNaAvioni type = GetById(request.TypeId);
                if (type == null)
                    throw new Exception("The type does not exist.");

                if (type.Avionis_TipId.Count != 0 || type.Klasis_TipId.Count != 0)
                    throw new Exception("The type is not removable");

                Context.TipNaAvioni.DeleteOnSubmit(type);
                Context.SubmitChanges();
                response.ReturnedResult = type;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<TipNaAvioni> UpdateTypeInfoIfNotAssigned(RepoUpdateTypeInfoIfNotAssignedRequest request)
        {
            RepoBaseResponse<TipNaAvioni> response = new RepoBaseResponse<TipNaAvioni>();
            try
            {
                TipNaAvioni type = GetById(request.TypeId);
                if (type == null)
                    return AddNewType(new RepoAddNewTypeRequest { Type = request.NewType });
                else
                {
                    if (type.Avionis_TipId.Count() != 0
                        || type.Klasis_TipId.Count() != 0)
                        return AddNewType(new RepoAddNewTypeRequest { Type = request.NewType });
                    else
                    {
                        type.BrojNaPatnici = request.NewType.BrojNaPatnici;
                        type.MaxDimenziiDolzhina = request.NewType.MaxDimenziiDolzhina;
                        type.MaxDimenziiShirina = request.NewType.MaxDimenziiShirina;
                        type.MaxDimenziiVisina = request.NewType.MaxDimenziiVisina;
                        type.MaxMasaBadazh = request.NewType.MaxMasaBadazh;

                        Context.SubmitChanges();
                        response.ReturnedResult = type;
                    }
                }

                Context.TipNaAvioni.DeleteOnSubmit(type);
                Context.SubmitChanges();
                response.ReturnedResult = type;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }
    }
}
