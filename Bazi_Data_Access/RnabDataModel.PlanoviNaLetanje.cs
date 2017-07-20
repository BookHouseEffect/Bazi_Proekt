﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using LinqConnect template.
// Code is generated on: 2/6/2017 2:43:40 AM
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
    /// There are no comments for Db201617zVaProektRnabContext.PlanoviNaLetanje in the schema.
    /// </summary>
    [Table(Name = @"public.planovi_na_letanje")]
    public partial class PlanoviNaLetanje : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);
        #pragma warning disable 0649

        private int _PlanId;

        private int _AvionId;

        private int _MegjuletId;

        private System.DateTime _DatumVremeNaPoletuvanje;

        private System.DateTime _DatumVremeNaSletuvanje;

        private string _StatusNaLetot;

        private System.TimeSpan _Vremetraenje;
        #pragma warning restore 0649

        private EntitySet<Rezervacii> _Rezervaciis_PlanId;

        private EntityRef<Megjuletovi> _Megjuletovi_MegjuletId;

        private EntitySet<Cenovnici> _Cenovnicis_PlanId;

        private EntityRef<Avioni> _Avioni_AvionId;
    
        #region Extensibility Method Definitions

        /// <summary>
        /// There are no comments for OnLoaded method in the schema.
        /// </summary>
        partial void OnLoaded();

        /// <summary>
        /// There are no comments for OnValidate method in the schema.
        /// </summary>
        partial void OnValidate(ChangeAction action);

        /// <summary>
        /// There are no comments for OnCreated method in the schema.
        /// </summary>
        partial void OnCreated();

        /// <summary>
        /// There are no comments for OnPlanIdChanging method in the schema.
        /// </summary>
        partial void OnPlanIdChanging(int value);

        /// <summary>
        /// There are no comments for OnPlanIdChanged method in the schema.
        /// </summary>
        partial void OnPlanIdChanged();

        /// <summary>
        /// There are no comments for OnAvionIdChanging method in the schema.
        /// </summary>
        partial void OnAvionIdChanging(int value);

        /// <summary>
        /// There are no comments for OnAvionIdChanged method in the schema.
        /// </summary>
        partial void OnAvionIdChanged();

        /// <summary>
        /// There are no comments for OnMegjuletIdChanging method in the schema.
        /// </summary>
        partial void OnMegjuletIdChanging(int value);

        /// <summary>
        /// There are no comments for OnMegjuletIdChanged method in the schema.
        /// </summary>
        partial void OnMegjuletIdChanged();

        /// <summary>
        /// There are no comments for OnDatumVremeNaPoletuvanjeChanging method in the schema.
        /// </summary>
        partial void OnDatumVremeNaPoletuvanjeChanging(System.DateTime value);

        /// <summary>
        /// There are no comments for OnDatumVremeNaPoletuvanjeChanged method in the schema.
        /// </summary>
        partial void OnDatumVremeNaPoletuvanjeChanged();

        /// <summary>
        /// There are no comments for OnDatumVremeNaSletuvanjeChanging method in the schema.
        /// </summary>
        partial void OnDatumVremeNaSletuvanjeChanging(System.DateTime value);

        /// <summary>
        /// There are no comments for OnDatumVremeNaSletuvanjeChanged method in the schema.
        /// </summary>
        partial void OnDatumVremeNaSletuvanjeChanged();

        /// <summary>
        /// There are no comments for OnStatusNaLetotChanging method in the schema.
        /// </summary>
        partial void OnStatusNaLetotChanging(string value);

        /// <summary>
        /// There are no comments for OnStatusNaLetotChanged method in the schema.
        /// </summary>
        partial void OnStatusNaLetotChanged();

        /// <summary>
        /// There are no comments for OnVremetraenjeChanging method in the schema.
        /// </summary>
        partial void OnVremetraenjeChanging(System.TimeSpan value);

        /// <summary>
        /// There are no comments for OnVremetraenjeChanged method in the schema.
        /// </summary>
        partial void OnVremetraenjeChanged();
        #endregion

        /// <summary>
        /// There are no comments for PlanoviNaLetanje constructor in the schema.
        /// </summary>
        public PlanoviNaLetanje()
        {
            this._Rezervaciis_PlanId = new EntitySet<Rezervacii>(new Action<Rezervacii>(this.attach_Rezervaciis_PlanId), new Action<Rezervacii>(this.detach_Rezervaciis_PlanId));
            this._Megjuletovi_MegjuletId  = default(EntityRef<Megjuletovi>);
            this._Cenovnicis_PlanId = new EntitySet<Cenovnici>(new Action<Cenovnici>(this.attach_Cenovnicis_PlanId), new Action<Cenovnici>(this.detach_Cenovnicis_PlanId));
            this._Avioni_AvionId  = default(EntityRef<Avioni>);
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for PlanId in the schema.
        /// </summary>
        [Column(Name = @"plan_id", Storage = "_PlanId", AutoSync = AutoSync.OnInsert, CanBeNull = false, DbType = "SERIAL NOT NULL", IsDbGenerated = true, IsPrimaryKey = true)]
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required()]
        public int PlanId
        {
            get
            {
                return this._PlanId;
            }
            set
            {
                if (this._PlanId != value)
                {
                    this.OnPlanIdChanging(value);
                    this.SendPropertyChanging();
                    this._PlanId = value;
                    this.SendPropertyChanged("PlanId");
                    this.OnPlanIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for AvionId in the schema.
        /// </summary>
        [Column(Name = @"avion_id", Storage = "_AvionId", CanBeNull = false, DbType = "INT4 NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.Required()]
        public int AvionId
        {
            get
            {
                return this._AvionId;
            }
            set
            {
                if (this._AvionId != value)
                {
                    if (this._Avioni_AvionId.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }

                    this.OnAvionIdChanging(value);
                    this.SendPropertyChanging();
                    this._AvionId = value;
                    this.SendPropertyChanged("AvionId");
                    this.OnAvionIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for MegjuletId in the schema.
        /// </summary>
        [Column(Name = @"megjulet_id", Storage = "_MegjuletId", CanBeNull = false, DbType = "INT4 NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.Required()]
        public int MegjuletId
        {
            get
            {
                return this._MegjuletId;
            }
            set
            {
                if (this._MegjuletId != value)
                {
                    if (this._Megjuletovi_MegjuletId.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }

                    this.OnMegjuletIdChanging(value);
                    this.SendPropertyChanging();
                    this._MegjuletId = value;
                    this.SendPropertyChanged("MegjuletId");
                    this.OnMegjuletIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for DatumVremeNaPoletuvanje in the schema.
        /// </summary>
        [Column(Name = @"datum_vreme_na_poletuvanje", Storage = "_DatumVremeNaPoletuvanje", CanBeNull = false, DbType = "TIMESTAMP NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.Required()]
        public System.DateTime DatumVremeNaPoletuvanje
        {
            get
            {
                return this._DatumVremeNaPoletuvanje;
            }
            set
            {
                if (this._DatumVremeNaPoletuvanje != value)
                {
                    this.OnDatumVremeNaPoletuvanjeChanging(value);
                    this.SendPropertyChanging();
                    this._DatumVremeNaPoletuvanje = value;
                    this.SendPropertyChanged("DatumVremeNaPoletuvanje");
                    this.OnDatumVremeNaPoletuvanjeChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for DatumVremeNaSletuvanje in the schema.
        /// </summary>
        [Column(Name = @"datum_vreme_na_sletuvanje", Storage = "_DatumVremeNaSletuvanje", CanBeNull = false, DbType = "TIMESTAMP NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.Required()]
        public System.DateTime DatumVremeNaSletuvanje
        {
            get
            {
                return this._DatumVremeNaSletuvanje;
            }
            set
            {
                if (this._DatumVremeNaSletuvanje != value)
                {
                    this.OnDatumVremeNaSletuvanjeChanging(value);
                    this.SendPropertyChanging();
                    this._DatumVremeNaSletuvanje = value;
                    this.SendPropertyChanged("DatumVremeNaSletuvanje");
                    this.OnDatumVremeNaSletuvanjeChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for StatusNaLetot in the schema.
        /// </summary>
        [Column(Name = @"status_na_letot", Storage = "_StatusNaLetot", CanBeNull = false, DbType = "VARCHAR(100) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        [System.ComponentModel.DataAnnotations.Required()]
        public string StatusNaLetot
        {
            get
            {
                return this._StatusNaLetot;
            }
            set
            {
                if (this._StatusNaLetot != value)
                {
                    this.OnStatusNaLetotChanging(value);
                    this.SendPropertyChanging();
                    this._StatusNaLetot = value;
                    this.SendPropertyChanged("StatusNaLetot");
                    this.OnStatusNaLetotChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Vremetraenje in the schema.
        /// </summary>
        [Column(Name = @"vremetraenje", Storage = "_Vremetraenje", CanBeNull = false, DbType = "TIME NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.Required()]
        public System.TimeSpan Vremetraenje
        {
            get
            {
                return this._Vremetraenje;
            }
            set
            {
                if (this._Vremetraenje != value)
                {
                    this.OnVremetraenjeChanging(value);
                    this.SendPropertyChanging();
                    this._Vremetraenje = value;
                    this.SendPropertyChanged("Vremetraenje");
                    this.OnVremetraenjeChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Rezervaciis_PlanId in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="PlanoviNaLetanje_Rezervacii", Storage="_Rezervaciis_PlanId", ThisKey="PlanId", OtherKey="PlanId", DeleteRule="NO ACTION")]
        public EntitySet<Rezervacii> Rezervaciis_PlanId
        {
            get
            {
                return this._Rezervaciis_PlanId;
            }
            set
            {
                this._Rezervaciis_PlanId.Assign(value);
            }
        }

    
        /// <summary>
        /// There are no comments for Megjuletovi_MegjuletId in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="Megjuletovi_PlanoviNaLetanje", Storage="_Megjuletovi_MegjuletId", ThisKey="MegjuletId", OtherKey="MegjuletId", IsForeignKey=true, DeleteOnNull=true)]
        public Megjuletovi Megjuletovi_MegjuletId
        {
            get
            {
                return this._Megjuletovi_MegjuletId.Entity;
            }
            set
            {
                Megjuletovi previousValue = this._Megjuletovi_MegjuletId.Entity;
                if ((previousValue != value) || (this._Megjuletovi_MegjuletId.HasLoadedOrAssignedValue == false))
                {
                    this.SendPropertyChanging();
                    if (previousValue != null)
                    {
                        this._Megjuletovi_MegjuletId.Entity = null;
                        previousValue.PlanoviNaLetanjes_MegjuletId.Remove(this);
                    }
                    this._Megjuletovi_MegjuletId.Entity = value;
                    if (value != null)
                    {
                        this._MegjuletId = value.MegjuletId;
                        value.PlanoviNaLetanjes_MegjuletId.Add(this);
                    }
                    else
                    {
                        this._MegjuletId = default(int);
                    }
                    this.SendPropertyChanged("Megjuletovi_MegjuletId");
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Cenovnicis_PlanId in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="PlanoviNaLetanje_Cenovnici", Storage="_Cenovnicis_PlanId", ThisKey="PlanId", OtherKey="PlanId", DeleteRule="NO ACTION")]
        public EntitySet<Cenovnici> Cenovnicis_PlanId
        {
            get
            {
                return this._Cenovnicis_PlanId;
            }
            set
            {
                this._Cenovnicis_PlanId.Assign(value);
            }
        }

    
        /// <summary>
        /// There are no comments for Avioni_AvionId in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="Avioni_PlanoviNaLetanje", Storage="_Avioni_AvionId", ThisKey="AvionId", OtherKey="AvionId", IsForeignKey=true, DeleteOnNull=true)]
        public Avioni Avioni_AvionId
        {
            get
            {
                return this._Avioni_AvionId.Entity;
            }
            set
            {
                Avioni previousValue = this._Avioni_AvionId.Entity;
                if ((previousValue != value) || (this._Avioni_AvionId.HasLoadedOrAssignedValue == false))
                {
                    this.SendPropertyChanging();
                    if (previousValue != null)
                    {
                        this._Avioni_AvionId.Entity = null;
                        previousValue.PlanoviNaLetanjes_AvionId.Remove(this);
                    }
                    this._Avioni_AvionId.Entity = value;
                    if (value != null)
                    {
                        this._AvionId = value.AvionId;
                        value.PlanoviNaLetanjes_AvionId.Add(this);
                    }
                    else
                    {
                        this._AvionId = default(int);
                    }
                    this.SendPropertyChanged("Avioni_AvionId");
                }
            }
        }
   
        /// <summary>
        /// There are no comments for PropertyChanging event in the schema.
        /// </summary>
        public event PropertyChangingEventHandler PropertyChanging;

        /// <summary>
        /// There are no comments for PropertyChanged event in the schema.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// There are no comments for SendPropertyChanging method in the schema.
        /// </summary>
        protected virtual void SendPropertyChanging()
        {
		        var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, emptyChangingEventArgs);
        }

        /// <summary>
        /// There are no comments for SendPropertyChanging method in the schema.
        /// </summary>
        protected virtual void SendPropertyChanging(System.String propertyName) 
        {    
		        var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, new PropertyChangingEventArgs(propertyName));
        }

        /// <summary>
        /// There are no comments for SendPropertyChanged method in the schema.
        /// </summary>
        protected virtual void SendPropertyChanged(System.String propertyName)
        {    
		        var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void attach_Rezervaciis_PlanId(Rezervacii entity)
        {
            this.SendPropertyChanging("Rezervaciis_PlanId");
            entity.PlanoviNaLetanje_PlanId = this;
        }
    
        private void detach_Rezervaciis_PlanId(Rezervacii entity)
        {
            this.SendPropertyChanging("Rezervaciis_PlanId");
            entity.PlanoviNaLetanje_PlanId = null;
        }

        private void attach_Cenovnicis_PlanId(Cenovnici entity)
        {
            this.SendPropertyChanging("Cenovnicis_PlanId");
            entity.PlanoviNaLetanje_PlanId = this;
        }
    
        private void detach_Cenovnicis_PlanId(Cenovnici entity)
        {
            this.SendPropertyChanging("Cenovnicis_PlanId");
            entity.PlanoviNaLetanje_PlanId = null;
        }
    }

}
