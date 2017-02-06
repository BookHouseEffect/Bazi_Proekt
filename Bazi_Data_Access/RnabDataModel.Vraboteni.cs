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
    /// There are no comments for Db201617zVaProektRnabContext.Vraboteni in the schema.
    /// </summary>
    [Table(Name = @"public.vraboteni")]
    public partial class Vraboteni : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);
        #pragma warning disable 0649

        private int _VrabotenId;

        private int _CovekId;

        private int _AkauntId;

        private int _KompanijaId;
        #pragma warning restore 0649

        private EntityRef<Aviokompanii> _Aviokompanii_KompanijaId;

        private EntityRef<Lugje> _Lugje_CovekId;

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
        /// There are no comments for OnVrabotenIdChanging method in the schema.
        /// </summary>
        partial void OnVrabotenIdChanging(int value);

        /// <summary>
        /// There are no comments for OnVrabotenIdChanged method in the schema.
        /// </summary>
        partial void OnVrabotenIdChanged();

        /// <summary>
        /// There are no comments for OnCovekIdChanging method in the schema.
        /// </summary>
        partial void OnCovekIdChanging(int value);

        /// <summary>
        /// There are no comments for OnCovekIdChanged method in the schema.
        /// </summary>
        partial void OnCovekIdChanged();

        /// <summary>
        /// There are no comments for OnAkauntIdChanging method in the schema.
        /// </summary>
        partial void OnAkauntIdChanging(int value);

        /// <summary>
        /// There are no comments for OnAkauntIdChanged method in the schema.
        /// </summary>
        partial void OnAkauntIdChanged();

        /// <summary>
        /// There are no comments for OnKompanijaIdChanging method in the schema.
        /// </summary>
        partial void OnKompanijaIdChanging(int value);

        /// <summary>
        /// There are no comments for OnKompanijaIdChanged method in the schema.
        /// </summary>
        partial void OnKompanijaIdChanged();
        #endregion

        /// <summary>
        /// There are no comments for Vraboteni constructor in the schema.
        /// </summary>
        public Vraboteni()
        {
            this._Aviokompanii_KompanijaId  = default(EntityRef<Aviokompanii>);
            this._Lugje_CovekId  = default(EntityRef<Lugje>);
            this._Akaunti_AkauntId  = default(EntityRef<Akaunti>);
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for VrabotenId in the schema.
        /// </summary>
        [Column(Name = @"vraboten_id", Storage = "_VrabotenId", AutoSync = AutoSync.OnInsert, CanBeNull = false, DbType = "SERIAL NOT NULL", IsDbGenerated = true, IsPrimaryKey = true)]
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required()]
        public int VrabotenId
        {
            get
            {
                return this._VrabotenId;
            }
            set
            {
                if (this._VrabotenId != value)
                {
                    this.OnVrabotenIdChanging(value);
                    this.SendPropertyChanging();
                    this._VrabotenId = value;
                    this.SendPropertyChanged("VrabotenId");
                    this.OnVrabotenIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for CovekId in the schema.
        /// </summary>
        [Column(Name = @"covek_id", Storage = "_CovekId", CanBeNull = false, DbType = "INT4 NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.Required()]
        public int CovekId
        {
            get
            {
                return this._CovekId;
            }
            set
            {
                if (this._CovekId != value)
                {
                    if (this._Lugje_CovekId.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }

                    this.OnCovekIdChanging(value);
                    this.SendPropertyChanging();
                    this._CovekId = value;
                    this.SendPropertyChanged("CovekId");
                    this.OnCovekIdChanged();
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
        /// There are no comments for KompanijaId in the schema.
        /// </summary>
        [Column(Name = @"kompanija_id", Storage = "_KompanijaId", CanBeNull = false, DbType = "INT4 NOT NULL", UpdateCheck = UpdateCheck.Never)]
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
                    if (this._Aviokompanii_KompanijaId.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }

                    this.OnKompanijaIdChanging(value);
                    this.SendPropertyChanging();
                    this._KompanijaId = value;
                    this.SendPropertyChanged("KompanijaId");
                    this.OnKompanijaIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Aviokompanii_KompanijaId in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="Aviokompanii_Vraboteni", Storage="_Aviokompanii_KompanijaId", ThisKey="KompanijaId", OtherKey="KompanijaId", IsForeignKey=true, DeleteOnNull=true)]
        public Aviokompanii Aviokompanii_KompanijaId
        {
            get
            {
                return this._Aviokompanii_KompanijaId.Entity;
            }
            set
            {
                Aviokompanii previousValue = this._Aviokompanii_KompanijaId.Entity;
                if ((previousValue != value) || (this._Aviokompanii_KompanijaId.HasLoadedOrAssignedValue == false))
                {
                    this.SendPropertyChanging();
                    if (previousValue != null)
                    {
                        this._Aviokompanii_KompanijaId.Entity = null;
                        previousValue.Vrabotenis_KompanijaId.Remove(this);
                    }
                    this._Aviokompanii_KompanijaId.Entity = value;
                    if (value != null)
                    {
                        this._KompanijaId = value.KompanijaId;
                        value.Vrabotenis_KompanijaId.Add(this);
                    }
                    else
                    {
                        this._KompanijaId = default(int);
                    }
                    this.SendPropertyChanged("Aviokompanii_KompanijaId");
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Lugje_CovekId in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="Lugje_Vraboteni", Storage="_Lugje_CovekId", ThisKey="CovekId", OtherKey="CovekId", IsForeignKey=true, DeleteOnNull=true)]
        public Lugje Lugje_CovekId
        {
            get
            {
                return this._Lugje_CovekId.Entity;
            }
            set
            {
                Lugje previousValue = this._Lugje_CovekId.Entity;
                if ((previousValue != value) || (this._Lugje_CovekId.HasLoadedOrAssignedValue == false))
                {
                    this.SendPropertyChanging();
                    if (previousValue != null)
                    {
                        this._Lugje_CovekId.Entity = null;
                        previousValue.Vrabotenis_CovekId.Remove(this);
                    }
                    this._Lugje_CovekId.Entity = value;
                    if (value != null)
                    {
                        this._CovekId = value.CovekId;
                        value.Vrabotenis_CovekId.Add(this);
                    }
                    else
                    {
                        this._CovekId = default(int);
                    }
                    this.SendPropertyChanged("Lugje_CovekId");
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Akaunti_AkauntId in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="Akaunti_Vraboteni", Storage="_Akaunti_AkauntId", ThisKey="AkauntId", OtherKey="AkauntId", IsForeignKey=true, DeleteOnNull=true)]
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
                        previousValue.Vrabotenis_AkauntId.Remove(this);
                    }
                    this._Akaunti_AkauntId.Entity = value;
                    if (value != null)
                    {
                        this._AkauntId = value.AkauntId;
                        value.Vrabotenis_AkauntId.Add(this);
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
    }

}
