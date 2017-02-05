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
    /// There are no comments for Db201617zVaProektRnabContext.DenoviNaLetanje in the schema.
    /// </summary>
    [Table(Name = @"public.denovi_na_letanje")]
    public partial class DenoviNaLetanje : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);
        #pragma warning disable 0649

        private int _AktivenDenId;

        private int _LetId;

        private int _DenId;
        #pragma warning restore 0649

        private EntityRef<Letovi> _Letovi_LetId;

        private EntityRef<Denovi> _Denovi_DenId;
    
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
        /// There are no comments for OnAktivenDenIdChanging method in the schema.
        /// </summary>
        partial void OnAktivenDenIdChanging(int value);

        /// <summary>
        /// There are no comments for OnAktivenDenIdChanged method in the schema.
        /// </summary>
        partial void OnAktivenDenIdChanged();

        /// <summary>
        /// There are no comments for OnLetIdChanging method in the schema.
        /// </summary>
        partial void OnLetIdChanging(int value);

        /// <summary>
        /// There are no comments for OnLetIdChanged method in the schema.
        /// </summary>
        partial void OnLetIdChanged();

        /// <summary>
        /// There are no comments for OnDenIdChanging method in the schema.
        /// </summary>
        partial void OnDenIdChanging(int value);

        /// <summary>
        /// There are no comments for OnDenIdChanged method in the schema.
        /// </summary>
        partial void OnDenIdChanged();
        #endregion

        /// <summary>
        /// There are no comments for DenoviNaLetanje constructor in the schema.
        /// </summary>
        public DenoviNaLetanje()
        {
            this._Letovi_LetId  = default(EntityRef<Letovi>);
            this._Denovi_DenId  = default(EntityRef<Denovi>);
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for AktivenDenId in the schema.
        /// </summary>
        [Column(Name = @"aktiven_den_id", Storage = "_AktivenDenId", AutoSync = AutoSync.OnInsert, CanBeNull = false, DbType = "SERIAL NOT NULL", IsDbGenerated = true, IsPrimaryKey = true)]
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required()]
        public int AktivenDenId
        {
            get
            {
                return this._AktivenDenId;
            }
            set
            {
                if (this._AktivenDenId != value)
                {
                    this.OnAktivenDenIdChanging(value);
                    this.SendPropertyChanging();
                    this._AktivenDenId = value;
                    this.SendPropertyChanged("AktivenDenId");
                    this.OnAktivenDenIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for LetId in the schema.
        /// </summary>
        [Column(Name = @"let_id", Storage = "_LetId", CanBeNull = false, DbType = "INT4 NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.Required()]
        public int LetId
        {
            get
            {
                return this._LetId;
            }
            set
            {
                if (this._LetId != value)
                {
                    if (this._Letovi_LetId.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }

                    this.OnLetIdChanging(value);
                    this.SendPropertyChanging();
                    this._LetId = value;
                    this.SendPropertyChanged("LetId");
                    this.OnLetIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for DenId in the schema.
        /// </summary>
        [Column(Name = @"den_id", Storage = "_DenId", CanBeNull = false, DbType = "INT4 NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.Required()]
        public int DenId
        {
            get
            {
                return this._DenId;
            }
            set
            {
                if (this._DenId != value)
                {
                    if (this._Denovi_DenId.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }

                    this.OnDenIdChanging(value);
                    this.SendPropertyChanging();
                    this._DenId = value;
                    this.SendPropertyChanged("DenId");
                    this.OnDenIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Letovi_LetId in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="Letovi_DenoviNaLetanje", Storage="_Letovi_LetId", ThisKey="LetId", OtherKey="LetId", IsForeignKey=true, DeleteOnNull=true)]
        public Letovi Letovi_LetId
        {
            get
            {
                return this._Letovi_LetId.Entity;
            }
            set
            {
                Letovi previousValue = this._Letovi_LetId.Entity;
                if ((previousValue != value) || (this._Letovi_LetId.HasLoadedOrAssignedValue == false))
                {
                    this.SendPropertyChanging();
                    if (previousValue != null)
                    {
                        this._Letovi_LetId.Entity = null;
                        previousValue.DenoviNaLetanjes_LetId.Remove(this);
                    }
                    this._Letovi_LetId.Entity = value;
                    if (value != null)
                    {
                        this._LetId = value.LetId;
                        value.DenoviNaLetanjes_LetId.Add(this);
                    }
                    else
                    {
                        this._LetId = default(int);
                    }
                    this.SendPropertyChanged("Letovi_LetId");
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Denovi_DenId in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="Denovi_DenoviNaLetanje", Storage="_Denovi_DenId", ThisKey="DenId", OtherKey="DenId", IsForeignKey=true, DeleteOnNull=true)]
        public Denovi Denovi_DenId
        {
            get
            {
                return this._Denovi_DenId.Entity;
            }
            set
            {
                Denovi previousValue = this._Denovi_DenId.Entity;
                if ((previousValue != value) || (this._Denovi_DenId.HasLoadedOrAssignedValue == false))
                {
                    this.SendPropertyChanging();
                    if (previousValue != null)
                    {
                        this._Denovi_DenId.Entity = null;
                        previousValue.DenoviNaLetanjes_DenId.Remove(this);
                    }
                    this._Denovi_DenId.Entity = value;
                    if (value != null)
                    {
                        this._DenId = value.DenId;
                        value.DenoviNaLetanjes_DenId.Add(this);
                    }
                    else
                    {
                        this._DenId = default(int);
                    }
                    this.SendPropertyChanged("Denovi_DenId");
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
    }

}
