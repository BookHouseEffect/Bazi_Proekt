using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Db201617zVaProektRnabContext;

namespace Bazi_Web.Models
{
    public class CompanyIndexViewModel
    {
        public ICollection<KlasiSoMedianaRezervaciiPoKlasa> A { get; set; }
        public ICollection<AviokompanijaSoNajgolemProfit> B { get; set; }
        public ICollection<PatniciStoLetaleSoSiteAviokompanii> C { get; set; }
        public ICollection<DrzhaviSoNajvekePatuvanja> D { get; set; }
        public ICollection<PatnikKojNajmnoguPotrpsil> E { get; set; }

    }
}