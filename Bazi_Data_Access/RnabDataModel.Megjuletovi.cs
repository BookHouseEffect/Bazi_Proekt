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
    /// There are no comments for Db201617zVaProektRnabContext.Megjuletovi in the schema.
    /// </summary>
    [Table(Name = @"public.megjuletovi")]
    public partial class Megjuletovi : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);
        #pragma warning disable 0649

        private int _MegjuletId;

        private int _LetId;

        private int _AerodromOdId;

        private int _AerodromDoId;

        private System.TimeSpan _VremeNaLetanje;

        private float _Rastojanie;
        #pragma warning restore 0649

        private EntityRef<Letovi> _Letovi_LetId;

        private EntityRef<Aerodromi> _Aerodromi_AerodromOdId;

        private EntityRef<Aerodromi> _Aerodromi_AerodromDoId;

        private EntitySet<Rasporedi> _Rasporedis_MegjuletoviId;

        private EntitySet<PlanoviNaLetanje> _PlanoviNaLetanjes_MegjuletId;
    
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
        /// There are no comments for OnMegjuletIdChanging method in the schema.
        /// </summary>
        partial void OnMegjuletIdChanging(int value);

        /// <summary>
        /// There are no comments for OnMegjuletIdChanged method in the schema.
        /// </summary>
        partial void OnMegjuletIdChanged();

        /// <summary>
        /// There are no comments for OnLetIdChanging method in the schema.
        /// </summary>
        partial void OnLetIdChanging(int value);

        /// <summary>
        /// There are no comments for OnLetIdChanged method in the schema.
        /// </summary>
        partial void OnLetIdChanged();

        /// <summary>
        /// There are no comments for OnAerodromOdIdChanging method in the schema.
        /// </summary>
        partial void OnAerodromOdIdChanging(int value);

        /// <summary>
        /// There are no comments for OnAerodromOdIdChanged method in the schema.
        /// </summary>
        partial void OnAerodromOdIdChanged();

        /// <summary>
        /// There are no comments for OnAerodromDoIdChanging method in the schema.
        /// </summary>
        partial void OnAerodromDoIdChanging(int value);

        /// <summary>
        /// There are no comments for OnAerodromDoIdChanged method in the schema.
        /// </summary>
        partial void OnAerodromDoIdChanged();

        /// <summary>
        /// There are no comments for OnVremeNaLetanjeChanging method in the schema.
        /// </summary>
        partial void OnVremeNaLetanjeChanging(System.TimeSpan value);

        /// <summary>
        /// There are no comments for OnVremeNaLetanjeChanged method in the schema.
        /// </summary>
        partial void OnVremeNaLetanjeChanged();

        /// <summary>
        /// There are no comments for OnRastojanieChanging method in the schema.
        /// </summary>
        partial void OnRastojanieChanging(float value);

        /// <summary>
        /// There are no comments for OnRastojanieChanged method in the schema.
        /// </summary>
        partial void OnRastojanieChanged();
        #endregion

        /// <summary>
        /// There are no comments for Megjuletovi constructor in the schema.
        /// </summary>
        public Megjuletovi()
        {
            this._Letovi_LetId  = default(EntityRef<Letovi>);
            this._Aerodromi_AerodromOdId  = default(EntityRef<Aerodromi>);
            this._Aerodromi_AerodromDoId  = default(EntityRef<Aerodromi>);
            this._Rasporedis_MegjuletoviId = new EntitySet<Rasporedi>(new Action<Rasporedi>(this.attach_Rasporedis_MegjuletoviId), new Action<Rasporedi>(this.detach_Rasporedis_MegjuletoviId));
            this._PlanoviNaLetanjes_MegjuletId = new EntitySet<PlanoviNaLetanje>(new Action<PlanoviNaLetanje>(this.attach_PlanoviNaLetanjes_MegjuletId), new Action<PlanoviNaLetanje>(this.detach_PlanoviNaLetanjes_MegjuletId));
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for MegjuletId in the schema.
        /// </summary>
        [Column(Name = @"megjulet_id", Storage = "_MegjuletId", AutoSync = AutoSync.OnInsert, CanBeNull = false, DbType = "SERIAL NOT NULL", IsDbGenerated = true, IsPrimaryKey = true)]
        [System.ComponentModel.DataAnnotations.Key]
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
                    this.OnMegjuletIdChanging(value);
                    this.SendPropertyChanging();
                    this._MegjuletId = value;
                    this.SendPropertyChanged("MegjuletId");
                    this.OnMegjuletIdChanged();
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
        /// There are no comments for AerodromOdId in the schema.
        /// </summary>
        [Column(Name = @"aerodrom_od_id", Storage = "_AerodromOdId", CanBeNull = false, DbType = "INT4 NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.Required()]
        public int AerodromOdId
        {
            get
            {
                return this._AerodromOdId;
            }
            set
            {
                if (this._AerodromOdId != value)
                {
                    if (this._Aerodromi_AerodromOdId.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }

                    this.OnAerodromOdIdChanging(value);
                    this.SendPropertyChanging();
                    this._AerodromOdId = value;
                    this.SendPropertyChanged("AerodromOdId");
                    this.OnAerodromOdIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for AerodromDoId in the schema.
        /// </summary>
        [Column(Name = @"aerodrom_do_id", Storage = "_AerodromDoId", CanBeNull = false, DbType = "INT4 NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.Required()]
        public int AerodromDoId
        {
            get
            {
                return this._AerodromDoId;
            }
            set
            {
                if (this._AerodromDoId != value)
                {
                    if (this._Aerodromi_AerodromDoId.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }

                    this.OnAerodromDoIdChanging(value);
                    this.SendPropertyChanging();
                    this._AerodromDoId = value;
                    this.SendPropertyChanged("AerodromDoId");
                    this.OnAerodromDoIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for VremeNaLetanje in the schema.
        /// </summary>
        [Column(Name = @"vreme_na_letanje", Storage = "_VremeNaLetanje", CanBeNull = false, DbType = "TIME NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.Required()]
        public System.TimeSpan VremeNaLetanje
        {
            get
            {
                return this._VremeNaLetanje;
            }
            set
            {
                if (this._VremeNaLetanje != value)
                {
                    this.OnVremeNaLetanjeChanging(value);
                    this.SendPropertyChanging();
                    this._VremeNaLetanje = value;
                    this.SendPropertyChanged("VremeNaLetanje");
                    this.OnVremeNaLetanjeChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Rastojanie in the schema.
        /// </summary>
        [Column(Name = @"rastojanie", Storage = "_Rastojanie", CanBeNull = false, DbType = "FLOAT4 NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.Required()]
        public float Rastojanie
        {
            get
            {
                return this._Rastojanie;
            }
            set
            {
                if (this._Rastojanie != value)
                {
                    this.OnRastojanieChanging(value);
                    this.SendPropertyChanging();
                    this._Rastojanie = value;
                    this.SendPropertyChanged("Rastojanie");
                    this.OnRastojanieChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Letovi_LetId in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="Letovi_Megjuletovi", Storage="_Letovi_LetId", ThisKey="LetId", OtherKey="LetId", IsForeignKey=true, DeleteOnNull=true)]
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
                        previousValue.Megjuletovis_LetId.Remove(this);
                    }
                    this._Letovi_LetId.Entity = value;
                    if (value != null)
                    {
                        this._LetId = value.LetId;
                        value.Megjuletovis_LetId.Add(this);
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
        /// There are no comments for Aerodromi_AerodromOdId in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="Aerodromi_Megjuletovi", Storage="_Aerodromi_AerodromOdId", ThisKey="AerodromOdId", OtherKey="AerodromId", IsForeignKey=true, DeleteOnNull=true)]
        public Aerodromi Aerodromi_AerodromOdId
        {
            get
            {
                return this._Aerodromi_AerodromOdId.Entity;
            }
            set
            {
                Aerodromi previousValue = this._Aerodromi_AerodromOdId.Entity;
                if ((previousValue != value) || (this._Aerodromi_AerodromOdId.HasLoadedOrAssignedValue == false))
                {
                    this.SendPropertyChanging();
                    if (previousValue != null)
                    {
                        this._Aerodromi_AerodromOdId.Entity = null;
                        previousValue.Megjuletovis_AerodromOdId.Remove(this);
                    }
                    this._Aerodromi_AerodromOdId.Entity = value;
                    if (value != null)
                    {
                        this._AerodromOdId = value.AerodromId;
                        value.Megjuletovis_AerodromOdId.Add(this);
                    }
                    else
                    {
                        this._AerodromOdId = default(int);
                    }
                    this.SendPropertyChanged("Aerodromi_AerodromOdId");
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Aerodromi_AerodromDoId in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="Aerodromi_Megjuletovi1", Storage="_Aerodromi_AerodromDoId", ThisKey="AerodromDoId", OtherKey="AerodromId", IsForeignKey=true, DeleteOnNull=true)]
        public Aerodromi Aerodromi_AerodromDoId
        {
            get
            {
                return this._Aerodromi_AerodromDoId.Entity;
            }
            set
            {
                Aerodromi previousValue = this._Aerodromi_AerodromDoId.Entity;
                if ((previousValue != value) || (this._Aerodromi_AerodromDoId.HasLoadedOrAssignedValue == false))
                {
                    this.SendPropertyChanging();
                    if (previousValue != null)
                    {
                        this._Aerodromi_AerodromDoId.Entity = null;
                        previousValue.Megjuletovis_AerodromDoId.Remove(this);
                    }
                    this._Aerodromi_AerodromDoId.Entity = value;
                    if (value != null)
                    {
                        this._AerodromDoId = value.AerodromId;
                        value.Megjuletovis_AerodromDoId.Add(this);
                    }
                    else
                    {
                        this._AerodromDoId = default(int);
                    }
                    this.SendPropertyChanged("Aerodromi_AerodromDoId");
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Rasporedis_MegjuletoviId in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="Megjuletovi_Rasporedi", Storage="_Rasporedis_MegjuletoviId", ThisKey="MegjuletId", OtherKey="MegjuletoviId", DeleteRule="NO ACTION")]
        public EntitySet<Rasporedi> Rasporedis_MegjuletoviId
        {
            get
            {
                return this._Rasporedis_MegjuletoviId;
            }
            set
            {
                this._Rasporedis_MegjuletoviId.Assign(value);
            }
        }

    
        /// <summary>
        /// There are no comments for PlanoviNaLetanjes_MegjuletId in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="Megjuletovi_PlanoviNaLetanje", Storage="_PlanoviNaLetanjes_MegjuletId", ThisKey="MegjuletId", OtherKey="MegjuletId", DeleteRule="NO ACTION")]
        public EntitySet<PlanoviNaLetanje> PlanoviNaLetanjes_MegjuletId
        {
            get
            {
                return this._PlanoviNaLetanjes_MegjuletId;
            }
            set
            {
                this._PlanoviNaLetanjes_MegjuletId.Assign(value);
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

        private void attach_Rasporedis_MegjuletoviId(Rasporedi entity)
        {
            this.SendPropertyChanging("Rasporedis_MegjuletoviId");
            entity.Megjuletovi_MegjuletoviId = this;
        }
    
        private void detach_Rasporedis_MegjuletoviId(Rasporedi entity)
        {
            this.SendPropertyChanging("Rasporedis_MegjuletoviId");
            entity.Megjuletovi_MegjuletoviId = null;
        }

        private void attach_PlanoviNaLetanjes_MegjuletId(PlanoviNaLetanje entity)
        {
            this.SendPropertyChanging("PlanoviNaLetanjes_MegjuletId");
            entity.Megjuletovi_MegjuletId = this;
        }
    
        private void detach_PlanoviNaLetanjes_MegjuletId(PlanoviNaLetanje entity)
        {
            this.SendPropertyChanging("PlanoviNaLetanjes_MegjuletId");
            entity.Megjuletovi_MegjuletId = null;
        }
    }

}
