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
    /// There are no comments for Db201617zVaProektRnabContext.Patnici in the schema.
    /// </summary>
    [Table(Name = @"public.patnici")]
    public partial class Patnici : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);
        #pragma warning disable 0649

        private int _PatnikId;

        private int _AkauntId;

        private string _BrojNaPasosh;

        private System.DateTime _DatumNaIzdavanje;

        private string _Izdadenod;

        private System.DateTime _DatumNaIstekuvanje;

        private bool _Status = true;

        private int _AdresaId;

        private int _CovekId;
        #pragma warning restore 0649

        private EntitySet<Rezervacii> _Rezervaciis_PatnikId;

        private EntityRef<Adresi> _Adresi_AdresaId;

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
        /// There are no comments for OnPatnikIdChanging method in the schema.
        /// </summary>
        partial void OnPatnikIdChanging(int value);

        /// <summary>
        /// There are no comments for OnPatnikIdChanged method in the schema.
        /// </summary>
        partial void OnPatnikIdChanged();

        /// <summary>
        /// There are no comments for OnAkauntIdChanging method in the schema.
        /// </summary>
        partial void OnAkauntIdChanging(int value);

        /// <summary>
        /// There are no comments for OnAkauntIdChanged method in the schema.
        /// </summary>
        partial void OnAkauntIdChanged();

        /// <summary>
        /// There are no comments for OnBrojNaPasoshChanging method in the schema.
        /// </summary>
        partial void OnBrojNaPasoshChanging(string value);

        /// <summary>
        /// There are no comments for OnBrojNaPasoshChanged method in the schema.
        /// </summary>
        partial void OnBrojNaPasoshChanged();

        /// <summary>
        /// There are no comments for OnDatumNaIzdavanjeChanging method in the schema.
        /// </summary>
        partial void OnDatumNaIzdavanjeChanging(System.DateTime value);

        /// <summary>
        /// There are no comments for OnDatumNaIzdavanjeChanged method in the schema.
        /// </summary>
        partial void OnDatumNaIzdavanjeChanged();

        /// <summary>
        /// There are no comments for OnIzdadenodChanging method in the schema.
        /// </summary>
        partial void OnIzdadenodChanging(string value);

        /// <summary>
        /// There are no comments for OnIzdadenodChanged method in the schema.
        /// </summary>
        partial void OnIzdadenodChanged();

        /// <summary>
        /// There are no comments for OnDatumNaIstekuvanjeChanging method in the schema.
        /// </summary>
        partial void OnDatumNaIstekuvanjeChanging(System.DateTime value);

        /// <summary>
        /// There are no comments for OnDatumNaIstekuvanjeChanged method in the schema.
        /// </summary>
        partial void OnDatumNaIstekuvanjeChanged();

        /// <summary>
        /// There are no comments for OnStatusChanging method in the schema.
        /// </summary>
        partial void OnStatusChanging(bool value);

        /// <summary>
        /// There are no comments for OnStatusChanged method in the schema.
        /// </summary>
        partial void OnStatusChanged();

        /// <summary>
        /// There are no comments for OnAdresaIdChanging method in the schema.
        /// </summary>
        partial void OnAdresaIdChanging(int value);

        /// <summary>
        /// There are no comments for OnAdresaIdChanged method in the schema.
        /// </summary>
        partial void OnAdresaIdChanged();

        /// <summary>
        /// There are no comments for OnCovekIdChanging method in the schema.
        /// </summary>
        partial void OnCovekIdChanging(int value);

        /// <summary>
        /// There are no comments for OnCovekIdChanged method in the schema.
        /// </summary>
        partial void OnCovekIdChanged();
        #endregion

        /// <summary>
        /// There are no comments for Patnici constructor in the schema.
        /// </summary>
        public Patnici()
        {
            this._Rezervaciis_PatnikId = new EntitySet<Rezervacii>(new Action<Rezervacii>(this.attach_Rezervaciis_PatnikId), new Action<Rezervacii>(this.detach_Rezervaciis_PatnikId));
            this._Adresi_AdresaId  = default(EntityRef<Adresi>);
            this._Lugje_CovekId  = default(EntityRef<Lugje>);
            this._Akaunti_AkauntId  = default(EntityRef<Akaunti>);
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for PatnikId in the schema.
        /// </summary>
        [Column(Name = @"patnik_id", Storage = "_PatnikId", AutoSync = AutoSync.OnInsert, CanBeNull = false, DbType = "SERIAL NOT NULL", IsDbGenerated = true, IsPrimaryKey = true)]
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required()]
        public int PatnikId
        {
            get
            {
                return this._PatnikId;
            }
            set
            {
                if (this._PatnikId != value)
                {
                    this.OnPatnikIdChanging(value);
                    this.SendPropertyChanging();
                    this._PatnikId = value;
                    this.SendPropertyChanged("PatnikId");
                    this.OnPatnikIdChanged();
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
        /// There are no comments for BrojNaPasosh in the schema.
        /// </summary>
        [Column(Name = @"broj_na_pasosh", Storage = "_BrojNaPasosh", CanBeNull = false, DbType = "VARCHAR(255) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        [System.ComponentModel.DataAnnotations.Required()]
        public string BrojNaPasosh
        {
            get
            {
                return this._BrojNaPasosh;
            }
            set
            {
                if (this._BrojNaPasosh != value)
                {
                    this.OnBrojNaPasoshChanging(value);
                    this.SendPropertyChanging();
                    this._BrojNaPasosh = value;
                    this.SendPropertyChanged("BrojNaPasosh");
                    this.OnBrojNaPasoshChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for DatumNaIzdavanje in the schema.
        /// </summary>
        [Column(Name = @"datum_na_izdavanje", Storage = "_DatumNaIzdavanje", CanBeNull = false, DbType = "DATE NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.Required()]
        public System.DateTime DatumNaIzdavanje
        {
            get
            {
                return this._DatumNaIzdavanje;
            }
            set
            {
                if (this._DatumNaIzdavanje != value)
                {
                    this.OnDatumNaIzdavanjeChanging(value);
                    this.SendPropertyChanging();
                    this._DatumNaIzdavanje = value;
                    this.SendPropertyChanged("DatumNaIzdavanje");
                    this.OnDatumNaIzdavanjeChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Izdadenod in the schema.
        /// </summary>
        [Column(Name = @"izdadenod", Storage = "_Izdadenod", CanBeNull = false, DbType = "VARCHAR(255) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.StringLength(255)]
        [System.ComponentModel.DataAnnotations.Required()]
        public string Izdadenod
        {
            get
            {
                return this._Izdadenod;
            }
            set
            {
                if (this._Izdadenod != value)
                {
                    this.OnIzdadenodChanging(value);
                    this.SendPropertyChanging();
                    this._Izdadenod = value;
                    this.SendPropertyChanged("Izdadenod");
                    this.OnIzdadenodChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for DatumNaIstekuvanje in the schema.
        /// </summary>
        [Column(Name = @"datum_na_istekuvanje", Storage = "_DatumNaIstekuvanje", CanBeNull = false, DbType = "DATE NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.Required()]
        public System.DateTime DatumNaIstekuvanje
        {
            get
            {
                return this._DatumNaIstekuvanje;
            }
            set
            {
                if (this._DatumNaIstekuvanje != value)
                {
                    this.OnDatumNaIstekuvanjeChanging(value);
                    this.SendPropertyChanging();
                    this._DatumNaIstekuvanje = value;
                    this.SendPropertyChanged("DatumNaIstekuvanje");
                    this.OnDatumNaIstekuvanjeChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Status in the schema.
        /// </summary>
        [Column(Name = @"status", Storage = "_Status", CanBeNull = false, DbType = "BOOL NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.Required()]
        public bool Status
        {
            get
            {
                return this._Status;
            }
            set
            {
                if (this._Status != value)
                {
                    this.OnStatusChanging(value);
                    this.SendPropertyChanging();
                    this._Status = value;
                    this.SendPropertyChanged("Status");
                    this.OnStatusChanged();
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
        /// There are no comments for Rezervaciis_PatnikId in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="Patnici_Rezervacii", Storage="_Rezervaciis_PatnikId", ThisKey="PatnikId", OtherKey="PatnikId", DeleteRule="NO ACTION")]
        public EntitySet<Rezervacii> Rezervaciis_PatnikId
        {
            get
            {
                return this._Rezervaciis_PatnikId;
            }
            set
            {
                this._Rezervaciis_PatnikId.Assign(value);
            }
        }

    
        /// <summary>
        /// There are no comments for Adresi_AdresaId in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="Adresi_Patnici", Storage="_Adresi_AdresaId", ThisKey="AdresaId", OtherKey="AdresaId", IsForeignKey=true, DeleteOnNull=true)]
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
                        previousValue.Patnicis_AdresaId.Remove(this);
                    }
                    this._Adresi_AdresaId.Entity = value;
                    if (value != null)
                    {
                        this._AdresaId = value.AdresaId;
                        value.Patnicis_AdresaId.Add(this);
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
        /// There are no comments for Lugje_CovekId in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="Lugje_Patnici", Storage="_Lugje_CovekId", ThisKey="CovekId", OtherKey="CovekId", IsForeignKey=true, DeleteOnNull=true)]
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
                        previousValue.Patnicis_CovekId.Remove(this);
                    }
                    this._Lugje_CovekId.Entity = value;
                    if (value != null)
                    {
                        this._CovekId = value.CovekId;
                        value.Patnicis_CovekId.Add(this);
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
        [Devart.Data.Linq.Mapping.Association(Name="Akaunti_Patnici", Storage="_Akaunti_AkauntId", ThisKey="AkauntId", OtherKey="AkauntId", IsForeignKey=true, DeleteOnNull=true)]
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
                        previousValue.Patnicis_AkauntId.Remove(this);
                    }
                    this._Akaunti_AkauntId.Entity = value;
                    if (value != null)
                    {
                        this._AkauntId = value.AkauntId;
                        value.Patnicis_AkauntId.Add(this);
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

        private void attach_Rezervaciis_PatnikId(Rezervacii entity)
        {
            this.SendPropertyChanging("Rezervaciis_PatnikId");
            entity.Patnici_PatnikId = this;
        }
    
        private void detach_Rezervaciis_PatnikId(Rezervacii entity)
        {
            this.SendPropertyChanging("Rezervaciis_PatnikId");
            entity.Patnici_PatnikId = null;
        }
    }

}
