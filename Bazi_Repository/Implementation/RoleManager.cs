using System;
using System.Collections.Generic;
using System.Linq;
using Bazi_Repository.Interfaces;
using Db201617zVaProektRnabContext;
using Bazi_Repository.RepositoryRequests;

namespace Bazi_Repository.Implementation
{
    sealed public class RoleManager : BaseManager, IRoleManager
    {
        public RoleManager(): base() { }
        public RoleManager(Db201617zVaProektRnabDataContext e) : base(e) { }

        public RepoBaseResponse<Ulogi> GetRoleById(RepoGetRoleByIdRequest request)
        {
            RepoBaseResponse<Ulogi> response = new RepoBaseResponse<Ulogi>();
            try
            {
                response.ReturnedResult = Context.Ulogi.Where(x => x.UlogaId == request.RoleId).First();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<Ulogi> GetRoleByName(RepoGetRoleByNameRequest request)
        {
            RepoBaseResponse<Ulogi> response = new RepoBaseResponse<Ulogi>();
            try
            {
                response.ReturnedResult = Context.Ulogi.Where(x => x.UlogaIme == request.RoleName).First();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<ICollection<Ulogi>> GetRoleList()
        {
            RepoBaseResponse<ICollection<Ulogi>> response = new RepoBaseResponse<ICollection<Ulogi>>();
            try
            {
                response.ReturnedResult = Context.Ulogi.ToList();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }
    }
}
