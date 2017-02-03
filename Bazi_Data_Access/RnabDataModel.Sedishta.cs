﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using LinqConnect template.
// Code is generated on: 02.2.2017 23:21:55
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
    /// There are no comments for Db201617zVaProektRnabContext.Sedishta in the schema.
    /// </summary>
    [Table(Name = @"public.sedishta")]
    public partial class Sedishta : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);
        #pragma warning disable 0649

        private int _SedishteId;

        private int _BrojNaSediste;

        private int _KlasaId;
        #pragma warning restore 0649

        private EntityRef<Klasi> _Klasi_KlasaId;

        private EntitySet<Rezervacii> _Rezervaciis_SedishteId;
    
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
        /// There are no comments for OnSedishteIdChanging method in the schema.
        /// </summary>
        partial void OnSedishteIdChanging(int value);

        /// <summary>
        /// There are no comments for OnSedishteIdChanged method in the schema.
        /// </summary>
        partial void OnSedishteIdChanged();

        /// <summary>
        /// There are no comments for OnBrojNaSedisteChanging method in the schema.
        /// </summary>
        partial void OnBrojNaSedisteChanging(int value);

        /// <summary>
        /// There are no comments for OnBrojNaSedisteChanged method in the schema.
        /// </summary>
        partial void OnBrojNaSedisteChanged();

        /// <summary>
        /// There are no comments for OnKlasaIdChanging method in the schema.
        /// </summary>
        partial void OnKlasaIdChanging(int value);

        /// <summary>
        /// There are no comments for OnKlasaIdChanged method in the schema.
        /// </summary>
        partial void OnKlasaIdChanged();
        #endregion

        /// <summary>
        /// There are no comments for Sedishta constructor in the schema.
        /// </summary>
        public Sedishta()
        {
            this._Klasi_KlasaId  = default(EntityRef<Klasi>);
            this._Rezervaciis_SedishteId = new EntitySet<Rezervacii>(new Action<Rezervacii>(this.attach_Rezervaciis_SedishteId), new Action<Rezervacii>(this.detach_Rezervaciis_SedishteId));
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for SedishteId in the schema.
        /// </summary>
        [Column(Name = @"sedishte_id", Storage = "_SedishteId", AutoSync = AutoSync.OnInsert, CanBeNull = false, DbType = "SERIAL NOT NULL", IsDbGenerated = true, IsPrimaryKey = true)]
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required()]
        public int SedishteId
        {
            get
            {
                return this._SedishteId;
            }
            set
            {
                if (this._SedishteId != value)
                {
                    this.OnSedishteIdChanging(value);
                    this.SendPropertyChanging();
                    this._SedishteId = value;
                    this.SendPropertyChanged("SedishteId");
                    this.OnSedishteIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for BrojNaSediste in the schema.
        /// </summary>
        [Column(Name = @"broj_na_sediste", Storage = "_BrojNaSediste", CanBeNull = false, DbType = "INT4 NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.Required()]
        public int BrojNaSediste
        {
            get
            {
                return this._BrojNaSediste;
            }
            set
            {
                if (this._BrojNaSediste != value)
                {
                    this.OnBrojNaSedisteChanging(value);
                    this.SendPropertyChanging();
                    this._BrojNaSediste = value;
                    this.SendPropertyChanged("BrojNaSediste");
                    this.OnBrojNaSedisteChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for KlasaId in the schema.
        /// </summary>
        [Column(Name = @"klasa_id", Storage = "_KlasaId", CanBeNull = false, DbType = "INT4 NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.Required()]
        public int KlasaId
        {
            get
            {
                return this._KlasaId;
            }
            set
            {
                if (this._KlasaId != value)
                {
                    if (this._Klasi_KlasaId.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }

                    this.OnKlasaIdChanging(value);
                    this.SendPropertyChanging();
                    this._KlasaId = value;
                    this.SendPropertyChanged("KlasaId");
                    this.OnKlasaIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Klasi_KlasaId in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="Klasi_Sedishta", Storage="_Klasi_KlasaId", ThisKey="KlasaId", OtherKey="KlasaId", IsForeignKey=true, DeleteOnNull=true)]
        public Klasi Klasi_KlasaId
        {
            get
            {
                return this._Klasi_KlasaId.Entity;
            }
            set
            {
                Klasi previousValue = this._Klasi_KlasaId.Entity;
                if ((previousValue != value) || (this._Klasi_KlasaId.HasLoadedOrAssignedValue == false))
                {
                    this.SendPropertyChanging();
                    if (previousValue != null)
                    {
                        this._Klasi_KlasaId.Entity = null;
                        previousValue.Sedishtas_KlasaId.Remove(this);
                    }
                    this._Klasi_KlasaId.Entity = value;
                    if (value != null)
                    {
                        this._KlasaId = value.KlasaId;
                        value.Sedishtas_KlasaId.Add(this);
                    }
                    else
                    {
                        this._KlasaId = default(int);
                    }
                    this.SendPropertyChanged("Klasi_KlasaId");
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Rezervaciis_SedishteId in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="Sedishta_Rezervacii", Storage="_Rezervaciis_SedishteId", ThisKey="SedishteId", OtherKey="SedishteId", DeleteRule="NO ACTION")]
        public EntitySet<Rezervacii> Rezervaciis_SedishteId
        {
            get
            {
                return this._Rezervaciis_SedishteId;
            }
            set
            {
                this._Rezervaciis_SedishteId.Assign(value);
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

        private void attach_Rezervaciis_SedishteId(Rezervacii entity)
        {
            this.SendPropertyChanging("Rezervaciis_SedishteId");
            entity.Sedishta_SedishteId = this;
        }
    
        private void detach_Rezervaciis_SedishteId(Rezervacii entity)
        {
            this.SendPropertyChanging("Rezervaciis_SedishteId");
            entity.Sedishta_SedishteId = null;
        }
    }

}
