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
    /// There are no comments for Db201617zVaProektRnabContext.PatnikKojNajmnoguPotrpsil in the schema.
    /// </summary>
    [Table(Name = @"public.patnik_koj_najmnogu_potrpsil")]
    public partial class PatnikKojNajmnoguPotrpsil
    {
        #pragma warning disable 0649

        private int _PatnikId;

        private System.Nullable<float> _Potroshil;
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
        /// There are no comments for OnPatnikIdChanging method in the schema.
        /// </summary>
        partial void OnPatnikIdChanging(int value);

        /// <summary>
        /// There are no comments for OnPatnikIdChanged method in the schema.
        /// </summary>
        partial void OnPatnikIdChanged();

        /// <summary>
        /// There are no comments for OnPotroshilChanging method in the schema.
        /// </summary>
        partial void OnPotroshilChanging(System.Nullable<float> value);

        /// <summary>
        /// There are no comments for OnPotroshilChanged method in the schema.
        /// </summary>
        partial void OnPotroshilChanged();
        #endregion

        /// <summary>
        /// There are no comments for PatnikKojNajmnoguPotrpsil constructor in the schema.
        /// </summary>
        public PatnikKojNajmnoguPotrpsil()
        {
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for PatnikId in the schema.
        /// </summary>
        [Column(Name = @"patnik_id", Storage = "_PatnikId", CanBeNull = false, DbType = "INT4 NOT NULL", UpdateCheck = UpdateCheck.Never)]
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
                    this._PatnikId = value;
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Potroshil in the schema.
        /// </summary>
        [Column(Name = @"potroshil", Storage = "_Potroshil", DbType = "FLOAT4", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<float> Potroshil
        {
            get
            {
                return this._Potroshil;
            }
            set
            {
                if (this._Potroshil != value)
                {
                    this._Potroshil = value;
                }
            }
        }
    }

}