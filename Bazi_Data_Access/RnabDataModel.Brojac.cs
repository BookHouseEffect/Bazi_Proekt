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
    /// There are no comments for Db201617zVaProektRnabContext.Brojac in the schema.
    /// </summary>
    [Table(Name = @"public.brojac")]
    public partial class Brojac
    {
        #pragma warning disable 0649

        private System.Nullable<int> _RowId;

        private System.Nullable<long> _BrojRazlicniPatnici;

        private System.Nullable<long> _BrojIzdadeniBileti;

        private System.Nullable<long> _BrojRazlicniLetovi;
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
        /// There are no comments for OnRowIdChanging method in the schema.
        /// </summary>
        partial void OnRowIdChanging(System.Nullable<int> value);

        /// <summary>
        /// There are no comments for OnRowIdChanged method in the schema.
        /// </summary>
        partial void OnRowIdChanged();

        /// <summary>
        /// There are no comments for OnBrojRazlicniPatniciChanging method in the schema.
        /// </summary>
        partial void OnBrojRazlicniPatniciChanging(System.Nullable<long> value);

        /// <summary>
        /// There are no comments for OnBrojRazlicniPatniciChanged method in the schema.
        /// </summary>
        partial void OnBrojRazlicniPatniciChanged();

        /// <summary>
        /// There are no comments for OnBrojIzdadeniBiletiChanging method in the schema.
        /// </summary>
        partial void OnBrojIzdadeniBiletiChanging(System.Nullable<long> value);

        /// <summary>
        /// There are no comments for OnBrojIzdadeniBiletiChanged method in the schema.
        /// </summary>
        partial void OnBrojIzdadeniBiletiChanged();

        /// <summary>
        /// There are no comments for OnBrojRazlicniLetoviChanging method in the schema.
        /// </summary>
        partial void OnBrojRazlicniLetoviChanging(System.Nullable<long> value);

        /// <summary>
        /// There are no comments for OnBrojRazlicniLetoviChanged method in the schema.
        /// </summary>
        partial void OnBrojRazlicniLetoviChanged();
        #endregion

        /// <summary>
        /// There are no comments for Brojac constructor in the schema.
        /// </summary>
        public Brojac()
        {
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for RowId in the schema.
        /// </summary>
        [Column(Name = @"row_id", Storage = "_RowId", DbType = "INT4", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<int> RowId
        {
            get
            {
                return this._RowId;
            }
            set
            {
                if (this._RowId != value)
                {
                    this._RowId = value;
                }
            }
        }

    
        /// <summary>
        /// There are no comments for BrojRazlicniPatnici in the schema.
        /// </summary>
        [Column(Name = @"broj_razlicni_patnici", Storage = "_BrojRazlicniPatnici", DbType = "INT8", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<long> BrojRazlicniPatnici
        {
            get
            {
                return this._BrojRazlicniPatnici;
            }
            set
            {
                if (this._BrojRazlicniPatnici != value)
                {
                    this._BrojRazlicniPatnici = value;
                }
            }
        }

    
        /// <summary>
        /// There are no comments for BrojIzdadeniBileti in the schema.
        /// </summary>
        [Column(Name = @"broj_izdadeni_bileti", Storage = "_BrojIzdadeniBileti", DbType = "INT8", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<long> BrojIzdadeniBileti
        {
            get
            {
                return this._BrojIzdadeniBileti;
            }
            set
            {
                if (this._BrojIzdadeniBileti != value)
                {
                    this._BrojIzdadeniBileti = value;
                }
            }
        }

    
        /// <summary>
        /// There are no comments for BrojRazlicniLetovi in the schema.
        /// </summary>
        [Column(Name = @"broj_razlicni_letovi", Storage = "_BrojRazlicniLetovi", DbType = "INT8", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<long> BrojRazlicniLetovi
        {
            get
            {
                return this._BrojRazlicniLetovi;
            }
            set
            {
                if (this._BrojRazlicniLetovi != value)
                {
                    this._BrojRazlicniLetovi = value;
                }
            }
        }
    }

}
