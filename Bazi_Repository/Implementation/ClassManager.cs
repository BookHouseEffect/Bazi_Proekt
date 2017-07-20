using Bazi_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Bazi_Repository.RepositoryRequests;
using Db201617zVaProektRnabContext;

namespace Bazi_Repository.Implementation
{
    class ClassManager : BaseManager, IClassManager
    {

        private Klasi GetById(int typeId, int classId)
        {
            return Context.Klasi.Where(x => x.TipId == typeId && x.KlasaId == classId).SingleOrDefault();
        }
        public RepoBaseResponse<ICollection<Klasi>> AddTypeClass(RepoAddTypeClassRequest request)
        {
            RepoBaseResponse<ICollection<Klasi>> response = new RepoBaseResponse<ICollection<Klasi>>();
            try
            {
                AirplaneTypeManager airplaneManager = new AirplaneTypeManager(this.Context);
                RepoBaseResponse<TipNaAvioni> airplaneType = airplaneManager.GetTypeById(new RepoGetTypeByIdRequest { TypeId = request.TypeId });
                if (airplaneType.HasError()) throw airplaneType.Exception;

                List<Klasi> classes = new List<Klasi>();
                foreach (var item in request.ClassNamesAndSeatsNumber)
                {
                    Klasi typeClass = new Klasi
                    {
                        BrojNaSedistaVoKlasa = item.Value,
                        ImeNaKlasa = item.Key,
                        TipId = airplaneType.ReturnedResult.TipId
                    };
                    classes.Add(typeClass);
                }

                Context.Klasi.InsertAllOnSubmit(classes);
                Context.SubmitChanges();
                response.ReturnedResult = classes;
            } catch(Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Klasi> GetTypeClassById(RepoGetTypeClassByIdRequest request)
        {
            RepoBaseResponse<Klasi> response = new RepoBaseResponse<Klasi>();
            try
            {
                response.ReturnedResult = GetById(request.TypeId, request.ClassId);
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<ICollection<Klasi>> GetTypeClasses(RepoGetTypeClassesRequest request)
        {
            RepoBaseResponse<ICollection<Klasi>> response = new RepoBaseResponse<ICollection<Klasi>>();
            try
            {
                response.ReturnedResult = Context.Klasi.Where(x => x.TipId == request.TypeId).Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<KeyValuePair<Klasi, Klasi>> TransferTypeSeatsIfNotAssigned(RepoTransferTypeSeatsIfNotAssignedRequest request)
        {
            RepoBaseResponse<KeyValuePair<Klasi, Klasi>> response = new RepoBaseResponse<KeyValuePair<Klasi, Klasi>>();
            try
            {
                Klasi oldClass = GetById(request.TypeId, request.OldClassId);
                if (oldClass == null) throw new Exception("The class to transfer from does not exist");
                
                Klasi newClass = GetById(request.TypeId, request.NewClassId);
                if (newClass == null) throw new Exception("The new to transer in does not exist");

                oldClass.BrojNaSedistaVoKlasa -= request.NumberOfSeatsToTransfer;
                newClass.BrojNaSedistaVoKlasa += request.NumberOfSeatsToTransfer;
                Context.SubmitChanges();
                response.ReturnedResult = new KeyValuePair<Klasi, Klasi>(oldClass, newClass);
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Klasi> UpdateTypeClassName(RepoUpdateTypeClassNameRequest request)
        {
            RepoBaseResponse<Klasi> response = new RepoBaseResponse<Klasi>();
            try
            {
                Klasi typeClass = GetById(request.TypeId, request.ClassId);
                if (typeClass == null) throw new Exception("The class does not exist");

                typeClass.ImeNaKlasa = request.NewName;
                Context.SubmitChanges();
                response.ReturnedResult = typeClass;
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }
    }
}
