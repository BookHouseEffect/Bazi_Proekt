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
    /// There are no comments for Db201617zVaProektRnabContext.Adresi in the schema.
    /// </summary>
    [Table(Name = @"public.adresi")]
    public partial class Adresi : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);
        #pragma warning disable 0649

        private int _AdresaId;

        private string _ImeNaUlica;

        private string _Broj;

        private string _Grad;

        private string _Oblast;

        private string _Drzhava;

        private int _PoshtenskiBroj;
        #pragma warning restore 0649

        private EntitySet<Aviokompanii> _Aviokompaniis_AdresaId;

        private EntitySet<Patnici> _Patnicis_AdresaId;

        private EntitySet<Aerodromi> _Aerodromis_AdresaId;
    
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
        /// There are no comments for OnAdresaIdChanging method in the schema.
        /// </summary>
        partial void OnAdresaIdChanging(int value);

        /// <summary>
        /// There are no comments for OnAdresaIdChanged method in the schema.
        /// </summary>
        partial void OnAdresaIdChanged();

        /// <summary>
        /// There are no comments for OnImeNaUlicaChanging method in the schema.
        /// </summary>
        partial void OnImeNaUlicaChanging(string value);

        /// <summary>
        /// There are no comments for OnImeNaUlicaChanged method in the schema.
        /// </summary>
        partial void OnImeNaUlicaChanged();

        /// <summary>
        /// There are no comments for OnBrojChanging method in the schema.
        /// </summary>
        partial void OnBrojChanging(string value);

        /// <summary>
        /// There are no comments for OnBrojChanged method in the schema.
        /// </summary>
        partial void OnBrojChanged();

        /// <summary>
        /// There are no comments for OnGradChanging method in the schema.
        /// </summary>
        partial void OnGradChanging(string value);

        /// <summary>
        /// There are no comments for OnGradChanged method in the schema.
        /// </summary>
        partial void OnGradChanged();

        /// <summary>
        /// There are no comments for OnOblastChanging method in the schema.
        /// </summary>
        partial void OnOblastChanging(string value);

        /// <summary>
        /// There are no comments for OnOblastChanged method in the schema.
        /// </summary>
        partial void OnOblastChanged();

        /// <summary>
        /// There are no comments for OnDrzhavaChanging method in the schema.
        /// </summary>
        partial void OnDrzhavaChanging(string value);

        /// <summary>
        /// There are no comments for OnDrzhavaChanged method in the schema.
        /// </summary>
        partial void OnDrzhavaChanged();

        /// <summary>
        /// There are no comments for OnPoshtenskiBrojChanging method in the schema.
        /// </summary>
        partial void OnPoshtenskiBrojChanging(int value);

        /// <summary>
        /// There are no comments for OnPoshtenskiBrojChanged method in the schema.
        /// </summary>
        partial void OnPoshtenskiBrojChanged();
        #endregion

        /// <summary>
        /// There are no comments for Adresi constructor in the schema.
        /// </summary>
        public Adresi()
        {
            this._Aviokompaniis_AdresaId = new EntitySet<Aviokompanii>(new Action<Aviokompanii>(this.attach_Aviokompaniis_AdresaId), new Action<Aviokompanii>(this.detach_Aviokompaniis_AdresaId));
            this._Patnicis_AdresaId = new EntitySet<Patnici>(new Action<Patnici>(this.attach_Patnicis_AdresaId), new Action<Patnici>(this.detach_Patnicis_AdresaId));
            this._Aerodromis_AdresaId = new EntitySet<Aerodromi>(new Action<Aerodromi>(this.attach_Aerodromis_AdresaId), new Action<Aerodromi>(this.detach_Aerodromis_AdresaId));
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for AdresaId in the schema.
        /// </summary>
        [Column(Name = @"adresa_id", Storage = "_AdresaId", AutoSync = AutoSync.OnInsert, CanBeNull = false, DbType = "SERIAL NOT NULL", IsDbGenerated = true, IsPrimaryKey = true)]
        [System.ComponentModel.DataAnnotations.Key]
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
                    this.OnAdresaIdChanging(value);
                    this.SendPropertyChanging();
                    this._AdresaId = value;
                    this.SendPropertyChanged("AdresaId");
                    this.OnAdresaIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for ImeNaUlica in the schema.
        /// </summary>
        [Column(Name = @"ime_na_ulica", Storage = "_ImeNaUlica", CanBeNull = false, DbType = "VARCHAR(255) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        [System.ComponentModel.DataAnnotations.Required()]
        public string ImeNaUlica
        {
            get
            {
                return this._ImeNaUlica;
            }
            set
            {
                if (this._ImeNaUlica != value)
                {
                    this.OnImeNaUlicaChanging(value);
                    this.SendPropertyChanging();
                    this._ImeNaUlica = value;
                    this.SendPropertyChanged("ImeNaUlica");
                    this.OnImeNaUlicaChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Broj in the schema.
        /// </summary>
        [Column(Name = @"broj", Storage = "_Broj", CanBeNull = false, DbType = "VARCHAR(10) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.StringLength(10)]
        [System.ComponentModel.DataAnnotations.Required()]
        public string Broj
        {
            get
            {
                return this._Broj;
            }
            set
            {
                if (this._Broj != value)
                {
                    this.OnBrojChanging(value);
                    this.SendPropertyChanging();
                    this._Broj = value;
                    this.SendPropertyChanged("Broj");
                    this.OnBrojChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Grad in the schema.
        /// </summary>
        [Column(Name = @"grad", Storage = "_Grad", CanBeNull = false, DbType = "VARCHAR(255) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        [System.ComponentModel.DataAnnotations.Required()]
        public string Grad
        {
            get
            {
                return this._Grad;
            }
            set
            {
                if (this._Grad != value)
                {
                    this.OnGradChanging(value);
                    this.SendPropertyChanging();
                    this._Grad = value;
                    this.SendPropertyChanged("Grad");
                    this.OnGradChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Oblast in the schema.
        /// </summary>
        [Column(Name = @"oblast", Storage = "_Oblast", DbType = "VARCHAR(255)", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public string Oblast
        {
            get
            {
                return this._Oblast;
            }
            set
            {
                if (this._Oblast != value)
                {
                    this.OnOblastChanging(value);
                    this.SendPropertyChanging();
                    this._Oblast = value;
                    this.SendPropertyChanged("Oblast");
                    this.OnOblastChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Drzhava in the schema.
        /// </summary>
        [Column(Name = @"drzhava", Storage = "_Drzhava", CanBeNull = false, DbType = "VARCHAR(255) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        [System.ComponentModel.DataAnnotations.Required()]
        public string Drzhava
        {
            get
            {
                return this._Drzhava;
            }
            set
            {
                if (this._Drzhava != value)
                {
                    this.OnDrzhavaChanging(value);
                    this.SendPropertyChanging();
                    this._Drzhava = value;
                    this.SendPropertyChanged("Drzhava");
                    this.OnDrzhavaChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for PoshtenskiBroj in the schema.
        /// </summary>
        [Column(Name = @"poshtenski_broj", Storage = "_PoshtenskiBroj", CanBeNull = false, DbType = "INT4 NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.Required()]
        public int PoshtenskiBroj
        {
            get
            {
                return this._PoshtenskiBroj;
            }
            set
            {
                if (this._PoshtenskiBroj != value)
                {
                    this.OnPoshtenskiBrojChanging(value);
                    this.SendPropertyChanging();
                    this._PoshtenskiBroj = value;
                    this.SendPropertyChanged("PoshtenskiBroj");
                    this.OnPoshtenskiBrojChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Aviokompaniis_AdresaId in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="Adresi_Aviokompanii", Storage="_Aviokompaniis_AdresaId", ThisKey="AdresaId", OtherKey="AdresaId", DeleteRule="NO ACTION")]
        public EntitySet<Aviokompanii> Aviokompaniis_AdresaId
        {
            get
            {
                return this._Aviokompaniis_AdresaId;
            }
            set
            {
                this._Aviokompaniis_AdresaId.Assign(value);
            }
        }

    
        /// <summary>
        /// There are no comments for Patnicis_AdresaId in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="Adresi_Patnici", Storage="_Patnicis_AdresaId", ThisKey="AdresaId", OtherKey="AdresaId", DeleteRule="NO ACTION")]
        public EntitySet<Patnici> Patnicis_AdresaId
        {
            get
            {
                return this._Patnicis_AdresaId;
            }
            set
            {
                this._Patnicis_AdresaId.Assign(value);
            }
        }

    
        /// <summary>
        /// There are no comments for Aerodromis_AdresaId in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="Adresi_Aerodromi", Storage="_Aerodromis_AdresaId", ThisKey="AdresaId", OtherKey="AdresaId", DeleteRule="NO ACTION")]
        public EntitySet<Aerodromi> Aerodromis_AdresaId
        {
            get
            {
                return this._Aerodromis_AdresaId;
            }
            set
            {
                this._Aerodromis_AdresaId.Assign(value);
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

        private void attach_Aviokompaniis_AdresaId(Aviokompanii entity)
        {
            this.SendPropertyChanging("Aviokompaniis_AdresaId");
            entity.Adresi_AdresaId = this;
        }
    
        private void detach_Aviokompaniis_AdresaId(Aviokompanii entity)
        {
            this.SendPropertyChanging("Aviokompaniis_AdresaId");
            entity.Adresi_AdresaId = null;
        }

        private void attach_Patnicis_AdresaId(Patnici entity)
        {
            this.SendPropertyChanging("Patnicis_AdresaId");
            entity.Adresi_AdresaId = this;
        }
    
        private void detach_Patnicis_AdresaId(Patnici entity)
        {
            this.SendPropertyChanging("Patnicis_AdresaId");
            entity.Adresi_AdresaId = null;
        }

        private void attach_Aerodromis_AdresaId(Aerodromi entity)
        {
            this.SendPropertyChanging("Aerodromis_AdresaId");
            entity.Adresi_AdresaId = this;
        }
    
        private void detach_Aerodromis_AdresaId(Aerodromi entity)
        {
            this.SendPropertyChanging("Aerodromis_AdresaId");
            entity.Adresi_AdresaId = null;
        }
    }

}
