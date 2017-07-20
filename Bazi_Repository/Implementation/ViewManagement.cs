using System;
using System.Collections.Generic;
using System.Linq;
using Bazi_Repository.Interfaces;
using Db201617zVaProektRnabContext;

namespace Bazi_Repository.Implementation
{
    public class ViewManagement : BaseManager, IViewsManager
    {
        public RepoBaseResponse<ICollection<KlasiSoMedianaRezervaciiPoKlasa>> GetClassesWithMedianaTicketsByClass()
        {
            RepoBaseResponse<ICollection<KlasiSoMedianaRezervaciiPoKlasa>> response = new RepoBaseResponse<ICollection<KlasiSoMedianaRezervaciiPoKlasa>>();
            try
            {
                response.ReturnedResult = this.Context.KlasiSoMedianaRezervaciiPoKlasa.ToList();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<ICollection<AviokompanijaSoNajgolemProfit>> GetCompaniesWithMaxProfit()
        {
            RepoBaseResponse<ICollection<AviokompanijaSoNajgolemProfit>> response = new RepoBaseResponse<ICollection<AviokompanijaSoNajgolemProfit>>();
            try {
                response.ReturnedResult = this.Context.AviokompanijaSoNajgolemProfit.ToList();
            } catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<ICollection<Brojac>> GetCounter()
        {
            RepoBaseResponse<ICollection<Brojac>> response = new RepoBaseResponse<ICollection<Brojac>>();
            try
            {
                response.ReturnedResult = this.Context.Brojac.ToList();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<ICollection<PatniciStoLetaleSoSiteAviokompanii>> GetPassengersThatFlightWithAllCompaniess()
        {
            RepoBaseResponse<ICollection<PatniciStoLetaleSoSiteAviokompanii>> response = new RepoBaseResponse<ICollection<PatniciStoLetaleSoSiteAviokompanii>>();
            try
            {
                response.ReturnedResult = this.Context.PatniciStoLetaleSoSiteAviokompanii.ToList();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<ICollection<DrzhaviSoNajvekePatuvanja>> GetStatesWithMostFlights()
        {
            RepoBaseResponse<ICollection<DrzhaviSoNajvekePatuvanja>> response = new RepoBaseResponse<ICollection<DrzhaviSoNajvekePatuvanja>>();
            try
            {
                response.ReturnedResult = this.Context.DrzhaviSoNajvekePatuvanja.ToList();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }

        public RepoBaseResponse<ICollection<PatnikKojNajmnoguPotrpsil>> PassengerThatSpentTheMost()
        {
            RepoBaseResponse<ICollection<PatnikKojNajmnoguPotrpsil>> response = new RepoBaseResponse<ICollection<PatnikKojNajmnoguPotrpsil>>();
            try
            {
                response.ReturnedResult = this.Context.PatnikKojNajmnoguPotrpsil.ToList();
            }
            catch (Exception ex)
            {
                response.SetResponseProcessingFailed(ex);
            }
            return response;
        }
    }
}
