﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using LinqConnect template.
// Code is generated on: 13.1.2017 22:36:43
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using Devart.Data.Linq;
using Devart.Data.Linq.Mapping;
using System.Data;
using System.ComponentModel;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Linq.Expressions;

namespace Db201617zVaProektRnabContext
{

    /// <summary>
    /// There are no comments for Db201617zVaProektRnabDataContext class in the schema.
    /// </summary>
    [DatabaseAttribute(Name = "db_201617z_va_proekt_rnab")]
    [ProviderAttribute(typeof(Devart.Data.PostgreSql.Linq.Provider.PgSqlDataProvider))]
    public partial class Db201617zVaProektRnabDataContext : Devart.Data.Linq.DataContext
    {
    
        /// <summary>
        /// There are no comments for compiledQueryCache property in the schema.
        /// </summary>
        public static CompiledQueryCache compiledQueryCache = CompiledQueryCache.RegisterDataContext(typeof(Db201617zVaProektRnabDataContext));
        private static MappingSource mappingSource = new Devart.Data.Linq.Mapping.AttributeMappingSource();

        #region Extensibility Method Definitions
    
        /// <summary>
        /// There are no comments for OnCreated method in the schema.
        /// </summary>
        partial void OnCreated();

        /// <summary>
        /// There are no comments for OnSubmitError method in the schema.
        /// </summary>
        partial void OnSubmitError(Devart.Data.Linq.SubmitErrorEventArgs args);
        
        /// <summary>
        /// There are no comments for InsertTipNaAvioni method in the schema.
        /// </summary>
        partial void InsertTipNaAvioni(TipNaAvioni instance);

        /// <summary>
        /// There are no comments for UpdateTipNaAvioni method in the schema.
        /// </summary>
        partial void UpdateTipNaAvioni(TipNaAvioni instance);

        /// <summary>
        /// There are no comments for DeleteTipNaAvioni method in the schema.
        /// </summary>
        partial void DeleteTipNaAvioni(TipNaAvioni instance);
        
        /// <summary>
        /// There are no comments for InsertAviokompanii method in the schema.
        /// </summary>
        partial void InsertAviokompanii(Aviokompanii instance);

        /// <summary>
        /// There are no comments for UpdateAviokompanii method in the schema.
        /// </summary>
        partial void UpdateAviokompanii(Aviokompanii instance);

        /// <summary>
        /// There are no comments for DeleteAviokompanii method in the schema.
        /// </summary>
        partial void DeleteAviokompanii(Aviokompanii instance);
        
        /// <summary>
        /// There are no comments for InsertSedishta method in the schema.
        /// </summary>
        partial void InsertSedishta(Sedishta instance);

        /// <summary>
        /// There are no comments for UpdateSedishta method in the schema.
        /// </summary>
        partial void UpdateSedishta(Sedishta instance);

        /// <summary>
        /// There are no comments for DeleteSedishta method in the schema.
        /// </summary>
        partial void DeleteSedishta(Sedishta instance);
        
        /// <summary>
        /// There are no comments for InsertLetovi method in the schema.
        /// </summary>
        partial void InsertLetovi(Letovi instance);

        /// <summary>
        /// There are no comments for UpdateLetovi method in the schema.
        /// </summary>
        partial void UpdateLetovi(Letovi instance);

        /// <summary>
        /// There are no comments for DeleteLetovi method in the schema.
        /// </summary>
        partial void DeleteLetovi(Letovi instance);
        
        /// <summary>
        /// There are no comments for InsertKlasi method in the schema.
        /// </summary>
        partial void InsertKlasi(Klasi instance);

        /// <summary>
        /// There are no comments for UpdateKlasi method in the schema.
        /// </summary>
        partial void UpdateKlasi(Klasi instance);

        /// <summary>
        /// There are no comments for DeleteKlasi method in the schema.
        /// </summary>
        partial void DeleteKlasi(Klasi instance);
        
        /// <summary>
        /// There are no comments for InsertRezervacii method in the schema.
        /// </summary>
        partial void InsertRezervacii(Rezervacii instance);

        /// <summary>
        /// There are no comments for UpdateRezervacii method in the schema.
        /// </summary>
        partial void UpdateRezervacii(Rezervacii instance);

        /// <summary>
        /// There are no comments for DeleteRezervacii method in the schema.
        /// </summary>
        partial void DeleteRezervacii(Rezervacii instance);
        
        /// <summary>
        /// There are no comments for InsertAdresi method in the schema.
        /// </summary>
        partial void InsertAdresi(Adresi instance);

        /// <summary>
        /// There are no comments for UpdateAdresi method in the schema.
        /// </summary>
        partial void UpdateAdresi(Adresi instance);

        /// <summary>
        /// There are no comments for DeleteAdresi method in the schema.
        /// </summary>
        partial void DeleteAdresi(Adresi instance);
        
        /// <summary>
        /// There are no comments for InsertMegjuletovi method in the schema.
        /// </summary>
        partial void InsertMegjuletovi(Megjuletovi instance);

        /// <summary>
        /// There are no comments for UpdateMegjuletovi method in the schema.
        /// </summary>
        partial void UpdateMegjuletovi(Megjuletovi instance);

        /// <summary>
        /// There are no comments for DeleteMegjuletovi method in the schema.
        /// </summary>
        partial void DeleteMegjuletovi(Megjuletovi instance);
        
        /// <summary>
        /// There are no comments for InsertPatnici method in the schema.
        /// </summary>
        partial void InsertPatnici(Patnici instance);

        /// <summary>
        /// There are no comments for UpdatePatnici method in the schema.
        /// </summary>
        partial void UpdatePatnici(Patnici instance);

        /// <summary>
        /// There are no comments for DeletePatnici method in the schema.
        /// </summary>
        partial void DeletePatnici(Patnici instance);
        
        /// <summary>
        /// There are no comments for InsertCenovnici method in the schema.
        /// </summary>
        partial void InsertCenovnici(Cenovnici instance);

        /// <summary>
        /// There are no comments for UpdateCenovnici method in the schema.
        /// </summary>
        partial void UpdateCenovnici(Cenovnici instance);

        /// <summary>
        /// There are no comments for DeleteCenovnici method in the schema.
        /// </summary>
        partial void DeleteCenovnici(Cenovnici instance);
        
        /// <summary>
        /// There are no comments for InsertRasporedi method in the schema.
        /// </summary>
        partial void InsertRasporedi(Rasporedi instance);

        /// <summary>
        /// There are no comments for UpdateRasporedi method in the schema.
        /// </summary>
        partial void UpdateRasporedi(Rasporedi instance);

        /// <summary>
        /// There are no comments for DeleteRasporedi method in the schema.
        /// </summary>
        partial void DeleteRasporedi(Rasporedi instance);
        
        /// <summary>
        /// There are no comments for InsertAvioni method in the schema.
        /// </summary>
        partial void InsertAvioni(Avioni instance);

        /// <summary>
        /// There are no comments for UpdateAvioni method in the schema.
        /// </summary>
        partial void UpdateAvioni(Avioni instance);

        /// <summary>
        /// There are no comments for DeleteAvioni method in the schema.
        /// </summary>
        partial void DeleteAvioni(Avioni instance);
        
        /// <summary>
        /// There are no comments for InsertPlanoviNaLetanje method in the schema.
        /// </summary>
        partial void InsertPlanoviNaLetanje(PlanoviNaLetanje instance);

        /// <summary>
        /// There are no comments for UpdatePlanoviNaLetanje method in the schema.
        /// </summary>
        partial void UpdatePlanoviNaLetanje(PlanoviNaLetanje instance);

        /// <summary>
        /// There are no comments for DeletePlanoviNaLetanje method in the schema.
        /// </summary>
        partial void DeletePlanoviNaLetanje(PlanoviNaLetanje instance);
        
        /// <summary>
        /// There are no comments for InsertAerodromi method in the schema.
        /// </summary>
        partial void InsertAerodromi(Aerodromi instance);

        /// <summary>
        /// There are no comments for UpdateAerodromi method in the schema.
        /// </summary>
        partial void UpdateAerodromi(Aerodromi instance);

        /// <summary>
        /// There are no comments for DeleteAerodromi method in the schema.
        /// </summary>
        partial void DeleteAerodromi(Aerodromi instance);
        
        /// <summary>
        /// There are no comments for InsertDenovi method in the schema.
        /// </summary>
        partial void InsertDenovi(Denovi instance);

        /// <summary>
        /// There are no comments for UpdateDenovi method in the schema.
        /// </summary>
        partial void UpdateDenovi(Denovi instance);

        /// <summary>
        /// There are no comments for DeleteDenovi method in the schema.
        /// </summary>
        partial void DeleteDenovi(Denovi instance);
        
        /// <summary>
        /// There are no comments for InsertDenoviNaLetanje method in the schema.
        /// </summary>
        partial void InsertDenoviNaLetanje(DenoviNaLetanje instance);

        /// <summary>
        /// There are no comments for UpdateDenoviNaLetanje method in the schema.
        /// </summary>
        partial void UpdateDenoviNaLetanje(DenoviNaLetanje instance);

        /// <summary>
        /// There are no comments for DeleteDenoviNaLetanje method in the schema.
        /// </summary>
        partial void DeleteDenoviNaLetanje(DenoviNaLetanje instance);
        
        /// <summary>
        /// There are no comments for InsertUlogi method in the schema.
        /// </summary>
        partial void InsertUlogi(Ulogi instance);

        /// <summary>
        /// There are no comments for UpdateUlogi method in the schema.
        /// </summary>
        partial void UpdateUlogi(Ulogi instance);

        /// <summary>
        /// There are no comments for DeleteUlogi method in the schema.
        /// </summary>
        partial void DeleteUlogi(Ulogi instance);
        
        /// <summary>
        /// There are no comments for InsertAkaunti method in the schema.
        /// </summary>
        partial void InsertAkaunti(Akaunti instance);

        /// <summary>
        /// There are no comments for UpdateAkaunti method in the schema.
        /// </summary>
        partial void UpdateAkaunti(Akaunti instance);

        /// <summary>
        /// There are no comments for DeleteAkaunti method in the schema.
        /// </summary>
        partial void DeleteAkaunti(Akaunti instance);
        
        /// <summary>
        /// There are no comments for InsertLugje method in the schema.
        /// </summary>
        partial void InsertLugje(Lugje instance);

        /// <summary>
        /// There are no comments for UpdateLugje method in the schema.
        /// </summary>
        partial void UpdateLugje(Lugje instance);

        /// <summary>
        /// There are no comments for DeleteLugje method in the schema.
        /// </summary>
        partial void DeleteLugje(Lugje instance);
        
        /// <summary>
        /// There are no comments for InsertVraboteni method in the schema.
        /// </summary>
        partial void InsertVraboteni(Vraboteni instance);

        /// <summary>
        /// There are no comments for UpdateVraboteni method in the schema.
        /// </summary>
        partial void UpdateVraboteni(Vraboteni instance);

        /// <summary>
        /// There are no comments for DeleteVraboteni method in the schema.
        /// </summary>
        partial void DeleteVraboteni(Vraboteni instance);

        #endregion

        /// <summary>
        /// There are no comments for Db201617zVaProektRnabDataContext constructor in the schema.
        /// </summary>
        public Db201617zVaProektRnabDataContext() :
        base(GetConnectionString("Db201617zVaProektRnabDataContextConnectionString"), mappingSource)
        {
            OnCreated();
        }

        /// <summary>
        /// There are no comments for Db201617zVaProektRnabDataContext constructor in the schema.
        /// </summary>
        public Db201617zVaProektRnabDataContext(MappingSource mappingSource) :
        base(GetConnectionString("Db201617zVaProektRnabDataContextConnectionString"), mappingSource)
        {
            OnCreated();
        }

        private static string GetConnectionString(string connectionStringName)
        {
            System.Configuration.ConnectionStringSettings connectionStringSettings = System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName];
            if (connectionStringSettings == null)
                throw new InvalidOperationException("Connection string \"" + connectionStringName +"\" could not be found in the configuration file.");
            return connectionStringSettings.ConnectionString;
        }

        /// <summary>
        /// There are no comments for Db201617zVaProektRnabDataContext constructor in the schema.
        /// </summary>
        public Db201617zVaProektRnabDataContext(string connection) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        /// <summary>
        /// There are no comments for Db201617zVaProektRnabDataContext constructor in the schema.
        /// </summary>
        public Db201617zVaProektRnabDataContext(System.Data.IDbConnection connection) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        /// <summary>
        /// There are no comments for Db201617zVaProektRnabDataContext constructor in the schema.
        /// </summary>
        public Db201617zVaProektRnabDataContext(string connection, MappingSource mappingSource) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        /// <summary>
        /// There are no comments for Db201617zVaProektRnabDataContext constructor in the schema.
        /// </summary>
        public Db201617zVaProektRnabDataContext(System.Data.IDbConnection connection, MappingSource mappingSource) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        /// <summary>
        /// There are no comments for TipNaAvioni property in the schema.
        /// </summary>
        public Devart.Data.Linq.Table<TipNaAvioni> TipNaAvioni
        {
            get
            {
                return this.GetTable<TipNaAvioni>();
            }
        }

        /// <summary>
        /// There are no comments for Aviokompanii property in the schema.
        /// </summary>
        public Devart.Data.Linq.Table<Aviokompanii> Aviokompanii
        {
            get
            {
                return this.GetTable<Aviokompanii>();
            }
        }

        /// <summary>
        /// There are no comments for Sedishta property in the schema.
        /// </summary>
        public Devart.Data.Linq.Table<Sedishta> Sedishta
        {
            get
            {
                return this.GetTable<Sedishta>();
            }
        }

        /// <summary>
        /// There are no comments for Letovi property in the schema.
        /// </summary>
        public Devart.Data.Linq.Table<Letovi> Letovi
        {
            get
            {
                return this.GetTable<Letovi>();
            }
        }

        /// <summary>
        /// There are no comments for Klasi property in the schema.
        /// </summary>
        public Devart.Data.Linq.Table<Klasi> Klasi
        {
            get
            {
                return this.GetTable<Klasi>();
            }
        }

        /// <summary>
        /// There are no comments for Rezervacii property in the schema.
        /// </summary>
        public Devart.Data.Linq.Table<Rezervacii> Rezervacii
        {
            get
            {
                return this.GetTable<Rezervacii>();
            }
        }

        /// <summary>
        /// There are no comments for Adresi property in the schema.
        /// </summary>
        public Devart.Data.Linq.Table<Adresi> Adresi
        {
            get
            {
                return this.GetTable<Adresi>();
            }
        }

        /// <summary>
        /// There are no comments for Megjuletovi property in the schema.
        /// </summary>
        public Devart.Data.Linq.Table<Megjuletovi> Megjuletovi
        {
            get
            {
                return this.GetTable<Megjuletovi>();
            }
        }

        /// <summary>
        /// There are no comments for Patnici property in the schema.
        /// </summary>
        public Devart.Data.Linq.Table<Patnici> Patnici
        {
            get
            {
                return this.GetTable<Patnici>();
            }
        }

        /// <summary>
        /// There are no comments for Cenovnici property in the schema.
        /// </summary>
        public Devart.Data.Linq.Table<Cenovnici> Cenovnici
        {
            get
            {
                return this.GetTable<Cenovnici>();
            }
        }

        /// <summary>
        /// There are no comments for Rasporedi property in the schema.
        /// </summary>
        public Devart.Data.Linq.Table<Rasporedi> Rasporedi
        {
            get
            {
                return this.GetTable<Rasporedi>();
            }
        }

        /// <summary>
        /// There are no comments for Avioni property in the schema.
        /// </summary>
        public Devart.Data.Linq.Table<Avioni> Avioni
        {
            get
            {
                return this.GetTable<Avioni>();
            }
        }

        /// <summary>
        /// There are no comments for PlanoviNaLetanje property in the schema.
        /// </summary>
        public Devart.Data.Linq.Table<PlanoviNaLetanje> PlanoviNaLetanje
        {
            get
            {
                return this.GetTable<PlanoviNaLetanje>();
            }
        }

        /// <summary>
        /// There are no comments for Aerodromi property in the schema.
        /// </summary>
        public Devart.Data.Linq.Table<Aerodromi> Aerodromi
        {
            get
            {
                return this.GetTable<Aerodromi>();
            }
        }

        /// <summary>
        /// There are no comments for Denovi property in the schema.
        /// </summary>
        public Devart.Data.Linq.Table<Denovi> Denovi
        {
            get
            {
                return this.GetTable<Denovi>();
            }
        }

        /// <summary>
        /// There are no comments for DenoviNaLetanje property in the schema.
        /// </summary>
        public Devart.Data.Linq.Table<DenoviNaLetanje> DenoviNaLetanje
        {
            get
            {
                return this.GetTable<DenoviNaLetanje>();
            }
        }

        /// <summary>
        /// There are no comments for Ulogi property in the schema.
        /// </summary>
        public Devart.Data.Linq.Table<Ulogi> Ulogi
        {
            get
            {
                return this.GetTable<Ulogi>();
            }
        }

        /// <summary>
        /// There are no comments for Akaunti property in the schema.
        /// </summary>
        public Devart.Data.Linq.Table<Akaunti> Akaunti
        {
            get
            {
                return this.GetTable<Akaunti>();
            }
        }

        /// <summary>
        /// There are no comments for Lugje property in the schema.
        /// </summary>
        public Devart.Data.Linq.Table<Lugje> Lugje
        {
            get
            {
                return this.GetTable<Lugje>();
            }
        }

        /// <summary>
        /// There are no comments for Vraboteni property in the schema.
        /// </summary>
        public Devart.Data.Linq.Table<Vraboteni> Vraboteni
        {
            get
            {
                return this.GetTable<Vraboteni>();
            }
        }

        /// <summary>
        /// There are no comments for KlasiSoMedianaRezervaciiPoKlasa property in the schema.
        /// </summary>
        public Devart.Data.Linq.Table<KlasiSoMedianaRezervaciiPoKlasa> KlasiSoMedianaRezervaciiPoKlasa
        {
            get
            {
                return this.GetTable<KlasiSoMedianaRezervaciiPoKlasa>();
            }
        }

        /// <summary>
        /// There are no comments for Brojac property in the schema.
        /// </summary>
        public Devart.Data.Linq.Table<Brojac> Brojac
        {
            get
            {
                return this.GetTable<Brojac>();
            }
        }

        /// <summary>
        /// There are no comments for AviokompanijaSoNajgolemProfit property in the schema.
        /// </summary>
        public Devart.Data.Linq.Table<AviokompanijaSoNajgolemProfit> AviokompanijaSoNajgolemProfit
        {
            get
            {
                return this.GetTable<AviokompanijaSoNajgolemProfit>();
            }
        }

        /// <summary>
        /// There are no comments for DrzhaviSoNajvekePatuvanja property in the schema.
        /// </summary>
        public Devart.Data.Linq.Table<DrzhaviSoNajvekePatuvanja> DrzhaviSoNajvekePatuvanja
        {
            get
            {
                return this.GetTable<DrzhaviSoNajvekePatuvanja>();
            }
        }
    }
}
