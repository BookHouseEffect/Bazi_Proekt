using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db201617zVaProektRnabContext;
using Bazi_Repository.RepositoryRequests;

namespace Bazi_Repository.Interfaces
{
    interface IFlightDaysManager
    {
        RepoBaseResponse<ICollection<DenoviNaLetanje>> AssignFlightDays(RepoAssignFlightDaysRequest request);
    }
}
