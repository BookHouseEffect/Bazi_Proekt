using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazi_Repository.Interfaces;
using Db201617zVaProektRnabContext;

namespace Bazi_Repository.Implementation
{
    public class ViewManagement : BaseManager, IViewsManager
    {
        public RepoBaseResponse<ICollection<KlasiSoMedianaRezervaciiPoKlasa>> GetClassesWithMedianaTicketsByClass()
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<ICollection<AviokompanijaSoNajgolemProfit>> GetCompaniesWithMaxProfit()
        {
            throw new NotImplementedException();
        }

        public RepoBaseResponse<ICollection<Brojac>> GetCounter()
        {
            return new RepoBaseResponse<ICollection<Brojac>> { ReturnedResult = this.Context.Brojac.ToList() };
        }

        public RepoBaseResponse<ICollection<DrzhaviSoNajvekePatuvanja>> GetStatesWithMostFlights()
        {
            throw new NotImplementedException();
        }
    }
}
