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
    /// There are no comments for Db201617zVaProektRnabContext.TipNaAvioni in the schema.
    /// </summary>
    [Table(Name = @"public.tip_na_avioni")]
    public partial class TipNaAvioni : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);
        #pragma warning disable 0649

        private int _TipId;

        private int _BrojNaPatnici;

        private float _MaxMasaBadazh;

        private float _MaxDimenziiVisina;

        private float _MaxDimenziiShirina;

        private float _MaxDimenziiDolzhina;
        #pragma warning restore 0649

        private EntitySet<Klasi> _Klasis_TipId;

        private EntitySet<Avioni> _Avionis_TipId;
    
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
        /// There are no comments for OnTipIdChanging method in the schema.
        /// </summary>
        partial void OnTipIdChanging(int value);

        /// <summary>
        /// There are no comments for OnTipIdChanged method in the schema.
        /// </summary>
        partial void OnTipIdChanged();

        /// <summary>
        /// There are no comments for OnBrojNaPatniciChanging method in the schema.
        /// </summary>
        partial void OnBrojNaPatniciChanging(int value);

        /// <summary>
        /// There are no comments for OnBrojNaPatniciChanged method in the schema.
        /// </summary>
        partial void OnBrojNaPatniciChanged();

        /// <summary>
        /// There are no comments for OnMaxMasaBadazhChanging method in the schema.
        /// </summary>
        partial void OnMaxMasaBadazhChanging(float value);

        /// <summary>
        /// There are no comments for OnMaxMasaBadazhChanged method in the schema.
        /// </summary>
        partial void OnMaxMasaBadazhChanged();

        /// <summary>
        /// There are no comments for OnMaxDimenziiVisinaChanging method in the schema.
        /// </summary>
        partial void OnMaxDimenziiVisinaChanging(float value);

        /// <summary>
        /// There are no comments for OnMaxDimenziiVisinaChanged method in the schema.
        /// </summary>
        partial void OnMaxDimenziiVisinaChanged();

        /// <summary>
        /// There are no comments for OnMaxDimenziiShirinaChanging method in the schema.
        /// </summary>
        partial void OnMaxDimenziiShirinaChanging(float value);

        /// <summary>
        /// There are no comments for OnMaxDimenziiShirinaChanged method in the schema.
        /// </summary>
        partial void OnMaxDimenziiShirinaChanged();

        /// <summary>
        /// There are no comments for OnMaxDimenziiDolzhinaChanging method in the schema.
        /// </summary>
        partial void OnMaxDimenziiDolzhinaChanging(float value);

        /// <summary>
        /// There are no comments for OnMaxDimenziiDolzhinaChanged method in the schema.
        /// </summary>
        partial void OnMaxDimenziiDolzhinaChanged();
        #endregion

        /// <summary>
        /// There are no comments for TipNaAvioni constructor in the schema.
        /// </summary>
        public TipNaAvioni()
        {
            this._Klasis_TipId = new EntitySet<Klasi>(new Action<Klasi>(this.attach_Klasis_TipId), new Action<Klasi>(this.detach_Klasis_TipId));
            this._Avionis_TipId = new EntitySet<Avioni>(new Action<Avioni>(this.attach_Avionis_TipId), new Action<Avioni>(this.detach_Avionis_TipId));
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for TipId in the schema.
        /// </summary>
        [Column(Name = @"tip_id", Storage = "_TipId", AutoSync = AutoSync.OnInsert, CanBeNull = false, DbType = "SERIAL NOT NULL", IsDbGenerated = true, IsPrimaryKey = true)]
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required()]
        public int TipId
        {
            get
            {
                return this._TipId;
            }
            set
            {
                if (this._TipId != value)
                {
                    this.OnTipIdChanging(value);
                    this.SendPropertyChanging();
                    this._TipId = value;
                    this.SendPropertyChanged("TipId");
                    this.OnTipIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for BrojNaPatnici in the schema.
        /// </summary>
        [Column(Name = @"broj_na_patnici", Storage = "_BrojNaPatnici", CanBeNull = false, DbType = "INT4 NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.Required()]
        public int BrojNaPatnici
        {
            get
            {
                return this._BrojNaPatnici;
            }
            set
            {
                if (this._BrojNaPatnici != value)
                {
                    this.OnBrojNaPatniciChanging(value);
                    this.SendPropertyChanging();
                    this._BrojNaPatnici = value;
                    this.SendPropertyChanged("BrojNaPatnici");
                    this.OnBrojNaPatniciChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for MaxMasaBadazh in the schema.
        /// </summary>
        [Column(Name = @"max_masa_badazh", Storage = "_MaxMasaBadazh", CanBeNull = false, DbType = "FLOAT4 NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.Required()]
        public float MaxMasaBadazh
        {
            get
            {
                return this._MaxMasaBadazh;
            }
            set
            {
                if (this._MaxMasaBadazh != value)
                {
                    this.OnMaxMasaBadazhChanging(value);
                    this.SendPropertyChanging();
                    this._MaxMasaBadazh = value;
                    this.SendPropertyChanged("MaxMasaBadazh");
                    this.OnMaxMasaBadazhChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for MaxDimenziiVisina in the schema.
        /// </summary>
        [Column(Name = @"max_dimenzii_visina", Storage = "_MaxDimenziiVisina", CanBeNull = false, DbType = "FLOAT4 NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.Required()]
        public float MaxDimenziiVisina
        {
            get
            {
                return this._MaxDimenziiVisina;
            }
            set
            {
                if (this._MaxDimenziiVisina != value)
                {
                    this.OnMaxDimenziiVisinaChanging(value);
                    this.SendPropertyChanging();
                    this._MaxDimenziiVisina = value;
                    this.SendPropertyChanged("MaxDimenziiVisina");
                    this.OnMaxDimenziiVisinaChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for MaxDimenziiShirina in the schema.
        /// </summary>
        [Column(Name = @"max_dimenzii_shirina", Storage = "_MaxDimenziiShirina", CanBeNull = false, DbType = "FLOAT4 NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.Required()]
        public float MaxDimenziiShirina
        {
            get
            {
                return this._MaxDimenziiShirina;
            }
            set
            {
                if (this._MaxDimenziiShirina != value)
                {
                    this.OnMaxDimenziiShirinaChanging(value);
                    this.SendPropertyChanging();
                    this._MaxDimenziiShirina = value;
                    this.SendPropertyChanged("MaxDimenziiShirina");
                    this.OnMaxDimenziiShirinaChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for MaxDimenziiDolzhina in the schema.
        /// </summary>
        [Column(Name = @"max_dimenzii_dolzhina", Storage = "_MaxDimenziiDolzhina", CanBeNull = false, DbType = "FLOAT4 NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.Required()]
        public float MaxDimenziiDolzhina
        {
            get
            {
                return this._MaxDimenziiDolzhina;
            }
            set
            {
                if (this._MaxDimenziiDolzhina != value)
                {
                    this.OnMaxDimenziiDolzhinaChanging(value);
                    this.SendPropertyChanging();
                    this._MaxDimenziiDolzhina = value;
                    this.SendPropertyChanged("MaxDimenziiDolzhina");
                    this.OnMaxDimenziiDolzhinaChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Klasis_TipId in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="TipNaAvioni_Klasi", Storage="_Klasis_TipId", ThisKey="TipId", OtherKey="TipId", DeleteRule="NO ACTION")]
        public EntitySet<Klasi> Klasis_TipId
        {
            get
            {
                return this._Klasis_TipId;
            }
            set
            {
                this._Klasis_TipId.Assign(value);
            }
        }

    
        /// <summary>
        /// There are no comments for Avionis_TipId in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="TipNaAvioni_Avioni", Storage="_Avionis_TipId", ThisKey="TipId", OtherKey="TipId", DeleteRule="NO ACTION")]
        public EntitySet<Avioni> Avionis_TipId
        {
            get
            {
                return this._Avionis_TipId;
            }
            set
            {
                this._Avionis_TipId.Assign(value);
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

        private void attach_Klasis_TipId(Klasi entity)
        {
            this.SendPropertyChanging("Klasis_TipId");
            entity.TipNaAvioni_TipId = this;
        }
    
        private void detach_Klasis_TipId(Klasi entity)
        {
            this.SendPropertyChanging("Klasis_TipId");
            entity.TipNaAvioni_TipId = null;
        }

        private void attach_Avionis_TipId(Avioni entity)
        {
            this.SendPropertyChanging("Avionis_TipId");
            entity.TipNaAvioni_TipId = this;
        }
    
        private void detach_Avionis_TipId(Avioni entity)
        {
            this.SendPropertyChanging("Avionis_TipId");
            entity.TipNaAvioni_TipId = null;
        }
    }

}
