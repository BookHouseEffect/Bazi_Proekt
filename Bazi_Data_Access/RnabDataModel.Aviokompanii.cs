﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using LinqConnect template.
// Code is generated on: 2/5/2017 12:35:36 PM
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
    /// There are no comments for Db201617zVaProektRnabContext.Aviokompanii in the schema.
    /// </summary>
    [Table(Name = @"public.aviokompanii")]
    public partial class Aviokompanii : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);
        #pragma warning disable 0649

        private int _KompanijaId;

        private string _ImeNaKompanija;

        private int _AdresaId;

        private int _AkauntId;
        #pragma warning restore 0649

        private EntityRef<Adresi> _Adresi_AdresaId;

        private EntitySet<Avioni> _Avionis_KompanijaId;

        private EntitySet<Vraboteni> _Vrabotenis_KompanijaId;

        private EntityRef<Akaunti> _Akaunti_AkauntId;
    
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
        /// There are no comments for OnKompanijaIdChanging method in the schema.
        /// </summary>
        partial void OnKompanijaIdChanging(int value);

        /// <summary>
        /// There are no comments for OnKompanijaIdChanged method in the schema.
        /// </summary>
        partial void OnKompanijaIdChanged();

        /// <summary>
        /// There are no comments for OnImeNaKompanijaChanging method in the schema.
        /// </summary>
        partial void OnImeNaKompanijaChanging(string value);

        /// <summary>
        /// There are no comments for OnImeNaKompanijaChanged method in the schema.
        /// </summary>
        partial void OnImeNaKompanijaChanged();

        /// <summary>
        /// There are no comments for OnAdresaIdChanging method in the schema.
        /// </summary>
        partial void OnAdresaIdChanging(int value);

        /// <summary>
        /// There are no comments for OnAdresaIdChanged method in the schema.
        /// </summary>
        partial void OnAdresaIdChanged();

        /// <summary>
        /// There are no comments for OnAkauntIdChanging method in the schema.
        /// </summary>
        partial void OnAkauntIdChanging(int value);

        /// <summary>
        /// There are no comments for OnAkauntIdChanged method in the schema.
        /// </summary>
        partial void OnAkauntIdChanged();
        #endregion

        /// <summary>
        /// There are no comments for Aviokompanii constructor in the schema.
        /// </summary>
        public Aviokompanii()
        {
            this._Adresi_AdresaId  = default(EntityRef<Adresi>);
            this._Avionis_KompanijaId = new EntitySet<Avioni>(new Action<Avioni>(this.attach_Avionis_KompanijaId), new Action<Avioni>(this.detach_Avionis_KompanijaId));
            this._Vrabotenis_KompanijaId = new EntitySet<Vraboteni>(new Action<Vraboteni>(this.attach_Vrabotenis_KompanijaId), new Action<Vraboteni>(this.detach_Vrabotenis_KompanijaId));
            this._Akaunti_AkauntId  = default(EntityRef<Akaunti>);
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for KompanijaId in the schema.
        /// </summary>
        [Column(Name = @"kompanija_id", Storage = "_KompanijaId", AutoSync = AutoSync.OnInsert, CanBeNull = false, DbType = "SERIAL NOT NULL", IsDbGenerated = true, IsPrimaryKey = true)]
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required()]
        public int KompanijaId
        {
            get
            {
                return this._KompanijaId;
            }
            set
            {
                if (this._KompanijaId != value)
                {
                    this.OnKompanijaIdChanging(value);
                    this.SendPropertyChanging();
                    this._KompanijaId = value;
                    this.SendPropertyChanged("KompanijaId");
                    this.OnKompanijaIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for ImeNaKompanija in the schema.
        /// </summary>
        [Column(Name = @"ime_na_kompanija", Storage = "_ImeNaKompanija", CanBeNull = false, DbType = "VARCHAR(100) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        [System.ComponentModel.DataAnnotations.Required()]
        public string ImeNaKompanija
        {
            get
            {
                return this._ImeNaKompanija;
            }
            set
            {
                if (this._ImeNaKompanija != value)
                {
                    this.OnImeNaKompanijaChanging(value);
                    this.SendPropertyChanging();
                    this._ImeNaKompanija = value;
                    this.SendPropertyChanged("ImeNaKompanija");
                    this.OnImeNaKompanijaChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for AdresaId in the schema.
        /// </summary>
        [Column(Name = @"adresa_id", Storage = "_AdresaId", CanBeNull = false, DbType = "INT4 NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.Required()]
        public int AdresaId
        {
            get
            {
                return this._AdresaId;
            }
            set
            {
                if (this._AdresaId != value)
                {
                    if (this._Adresi_AdresaId.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }

                    this.OnAdresaIdChanging(value);
                    this.SendPropertyChanging();
                    this._AdresaId = value;
                    this.SendPropertyChanged("AdresaId");
                    this.OnAdresaIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for AkauntId in the schema.
        /// </summary>
        [Column(Name = @"akaunt_id", Storage = "_AkauntId", CanBeNull = false, DbType = "INT4 NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.Required()]
        public int AkauntId
        {
            get
            {
                return this._AkauntId;
            }
            set
            {
                if (this._AkauntId != value)
                {
                    if (this._Akaunti_AkauntId.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }

                    this.OnAkauntIdChanging(value);
                    this.SendPropertyChanging();
                    this._AkauntId = value;
                    this.SendPropertyChanged("AkauntId");
                    this.OnAkauntIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Adresi_AdresaId in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="Adresi_Aviokompanii", Storage="_Adresi_AdresaId", ThisKey="AdresaId", OtherKey="AdresaId", IsForeignKey=true, DeleteOnNull=true)]
        public Adresi Adresi_AdresaId
        {
            get
            {
                return this._Adresi_AdresaId.Entity;
            }
            set
            {
                Adresi previousValue = this._Adresi_AdresaId.Entity;
                if ((previousValue != value) || (this._Adresi_AdresaId.HasLoadedOrAssignedValue == false))
                {
                    this.SendPropertyChanging();
                    if (previousValue != null)
                    {
                        this._Adresi_AdresaId.Entity = null;
                        previousValue.Aviokompaniis_AdresaId.Remove(this);
                    }
                    this._Adresi_AdresaId.Entity = value;
                    if (value != null)
                    {
                        this._AdresaId = value.AdresaId;
                        value.Aviokompaniis_AdresaId.Add(this);
                    }
                    else
                    {
                        this._AdresaId = default(int);
                    }
                    this.SendPropertyChanged("Adresi_AdresaId");
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Avionis_KompanijaId in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="Aviokompanii_Avioni", Storage="_Avionis_KompanijaId", ThisKey="KompanijaId", OtherKey="KompanijaId", DeleteRule="NO ACTION")]
        public EntitySet<Avioni> Avionis_KompanijaId
        {
            get
            {
                return this._Avionis_KompanijaId;
            }
            set
            {
                this._Avionis_KompanijaId.Assign(value);
            }
        }

    
        /// <summary>
        /// There are no comments for Vrabotenis_KompanijaId in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="Aviokompanii_Vraboteni", Storage="_Vrabotenis_KompanijaId", ThisKey="KompanijaId", OtherKey="KompanijaId", DeleteRule="NO ACTION")]
        public EntitySet<Vraboteni> Vrabotenis_KompanijaId
        {
            get
            {
                return this._Vrabotenis_KompanijaId;
            }
            set
            {
                this._Vrabotenis_KompanijaId.Assign(value);
            }
        }

    
        /// <summary>
        /// There are no comments for Akaunti_AkauntId in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="Akaunti_Aviokompanii", Storage="_Akaunti_AkauntId", ThisKey="AkauntId", OtherKey="AkauntId", IsForeignKey=true, DeleteOnNull=true)]
        public Akaunti Akaunti_AkauntId
        {
            get
            {
                return this._Akaunti_AkauntId.Entity;
            }
            set
            {
                Akaunti previousValue = this._Akaunti_AkauntId.Entity;
                if ((previousValue != value) || (this._Akaunti_AkauntId.HasLoadedOrAssignedValue == false))
                {
                    this.SendPropertyChanging();
                    if (previousValue != null)
                    {
                        this._Akaunti_AkauntId.Entity = null;
                        previousValue.Aviokompaniis_AkauntId.Remove(this);
                    }
                    this._Akaunti_AkauntId.Entity = value;
                    if (value != null)
                    {
                        this._AkauntId = value.AkauntId;
                        value.Aviokompaniis_AkauntId.Add(this);
                    }
                    else
                    {
                        this._AkauntId = default(int);
                    }
                    this.SendPropertyChanged("Akaunti_AkauntId");
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

        private void attach_Avionis_KompanijaId(Avioni entity)
        {
            this.SendPropertyChanging("Avionis_KompanijaId");
            entity.Aviokompanii_KompanijaId = this;
        }
    
        private void detach_Avionis_KompanijaId(Avioni entity)
        {
            this.SendPropertyChanging("Avionis_KompanijaId");
            entity.Aviokompanii_KompanijaId = null;
        }

        private void attach_Vrabotenis_KompanijaId(Vraboteni entity)
        {
            this.SendPropertyChanging("Vrabotenis_KompanijaId");
            entity.Aviokompanii_KompanijaId = this;
        }
    
        private void detach_Vrabotenis_KompanijaId(Vraboteni entity)
        {
            this.SendPropertyChanging("Vrabotenis_KompanijaId");
            entity.Aviokompanii_KompanijaId = null;
        }
    }

}
