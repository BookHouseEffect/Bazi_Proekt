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
    /// There are no comments for Db201617zVaProektRnabContext.KlasiSoMedianaRezervaciiPoKlasa in the schema.
    /// </summary>
    [Table(Name = @"public.klasi_so_mediana_rezervacii_po_klasa")]
    public partial class KlasiSoMedianaRezervaciiPoKlasa
    {
        #pragma warning disable 0649

        private int _KlasaId;

        private int _TipId;

        private string _ImeNaKlasa;

        private int _BrojNaSedistaVoKlasa;
        #pragma warning restore 0649
    
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
        /// There are no comments for OnKlasaIdChanging method in the schema.
        /// </summary>
        partial void OnKlasaIdChanging(int value);

        /// <summary>
        /// There are no comments for OnKlasaIdChanged method in the schema.
        /// </summary>
        partial void OnKlasaIdChanged();

        /// <summary>
        /// There are no comments for OnTipIdChanging method in the schema.
        /// </summary>
        partial void OnTipIdChanging(int value);

        /// <summary>
        /// There are no comments for OnTipIdChanged method in the schema.
        /// </summary>
        partial void OnTipIdChanged();

        /// <summary>
        /// There are no comments for OnImeNaKlasaChanging method in the schema.
        /// </summary>
        partial void OnImeNaKlasaChanging(string value);

        /// <summary>
        /// There are no comments for OnImeNaKlasaChanged method in the schema.
        /// </summary>
        partial void OnImeNaKlasaChanged();

        /// <summary>
        /// There are no comments for OnBrojNaSedistaVoKlasaChanging method in the schema.
        /// </summary>
        partial void OnBrojNaSedistaVoKlasaChanging(int value);

        /// <summary>
        /// There are no comments for OnBrojNaSedistaVoKlasaChanged method in the schema.
        /// </summary>
        partial void OnBrojNaSedistaVoKlasaChanged();
        #endregion

        /// <summary>
        /// There are no comments for KlasiSoMedianaRezervaciiPoKlasa constructor in the schema.
        /// </summary>
        public KlasiSoMedianaRezervaciiPoKlasa()
        {
            OnCreated();
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
                    this._KlasaId = value;
                }
            }
        }

    
        /// <summary>
        /// There are no comments for TipId in the schema.
        /// </summary>
        [Column(Name = @"tip_id", Storage = "_TipId", CanBeNull = false, DbType = "INT4 NOT NULL", UpdateCheck = UpdateCheck.Never)]
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
                    this._TipId = value;
                }
            }
        }

    
        /// <summary>
        /// There are no comments for ImeNaKlasa in the schema.
        /// </summary>
        [Column(Name = @"ime_na_klasa", Storage = "_ImeNaKlasa", CanBeNull = false, DbType = "VARCHAR(100) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.StringLength(100)]
        [System.ComponentModel.DataAnnotations.Required()]
        public string ImeNaKlasa
        {
            get
            {
                return this._ImeNaKlasa;
            }
            set
            {
                if (this._ImeNaKlasa != value)
                {
                    this._ImeNaKlasa = value;
                }
            }
        }

    
        /// <summary>
        /// There are no comments for BrojNaSedistaVoKlasa in the schema.
        /// </summary>
        [Column(Name = @"broj_na_sedista_vo_klasa", Storage = "_BrojNaSedistaVoKlasa", CanBeNull = false, DbType = "INT4 NOT NULL", UpdateCheck = UpdateCheck.Never)]
        [System.ComponentModel.DataAnnotations.Required()]
        public int BrojNaSedistaVoKlasa
        {
            get
            {
                return this._BrojNaSedistaVoKlasa;
            }
            set
            {
                if (this._BrojNaSedistaVoKlasa != value)
                {
                    this._BrojNaSedistaVoKlasa = value;
                }
            }
        }
    }

}
