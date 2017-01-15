using Db201617zVaProektRnabContext;
using System.Collections.Generic;

namespace Bazi_Repository.Interfaces
{
    interface IViewsManager
    {
        RepoBaseResponse<ICollection<Brojac>> GetCounter();
        RepoBaseResponse<ICollection<AviokompanijaSoNajgolemProfit>> GetCompaniesWithMaxProfit();
        RepoBaseResponse<ICollection<DrzhaviSoNajvekePatuvanja>> GetStatesWithMostFlights();
        RepoBaseResponse<ICollection<KlasiSoMedianaRezervaciiPoKlasa>> GetClassesWithMedianaTicketsByClass();
    }
}
