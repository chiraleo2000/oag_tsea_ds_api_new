﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace SaoTsea.Ds.Api.EntitiesCode
{

    [Persistent(@"adm_system_info")]
    public partial class ADM_SYSTEM_INFO : XPLiteObject
    {
        int fSYSTEM_ID;
        [Key(true)]
        [Persistent(@"system_id")]
        public int SYSTEM_ID
        {
            get { return fSYSTEM_ID; }
            set { SetPropertyValue<int>(nameof(SYSTEM_ID), ref fSYSTEM_ID, value); }
        }
        string fSYSTEM_CODE;
        [Size(50)]
        [Persistent(@"system_code")]
        public string SYSTEM_CODE
        {
            get { return fSYSTEM_CODE; }
            set { SetPropertyValue<string>(nameof(SYSTEM_CODE), ref fSYSTEM_CODE, value); }
        }
        string fSYSTEM_NAME;
        [Size(255)]
        [Persistent(@"system_name")]
        public string SYSTEM_NAME
        {
            get { return fSYSTEM_NAME; }
            set { SetPropertyValue<string>(nameof(SYSTEM_NAME), ref fSYSTEM_NAME, value); }
        }
        string fRECORD_STATUS;
        [Persistent(@"record_status")]
        public string RECORD_STATUS
        {
            get { return fRECORD_STATUS; }
            set { SetPropertyValue<string>(nameof(RECORD_STATUS), ref fRECORD_STATUS, value); }
        }
        int fCREATE_USER_ID;
        [Persistent(@"create_user_id")]
        public int CREATE_USER_ID
        {
            get { return fCREATE_USER_ID; }
            set { SetPropertyValue<int>(nameof(CREATE_USER_ID), ref fCREATE_USER_ID, value); }
        }
        DateTime fCREATE_DATE;
        [Persistent(@"create_date")]
        public DateTime CREATE_DATE
        {
            get { return fCREATE_DATE; }
            set { SetPropertyValue<DateTime>(nameof(CREATE_DATE), ref fCREATE_DATE, value); }
        }
        int fUPDATE_USER_ID;
        [Persistent(@"update_user_id")]
        public int UPDATE_USER_ID
        {
            get { return fUPDATE_USER_ID; }
            set { SetPropertyValue<int>(nameof(UPDATE_USER_ID), ref fUPDATE_USER_ID, value); }
        }
        DateTime fUPDATE_DATE;
        [Persistent(@"update_date")]
        public DateTime UPDATE_DATE
        {
            get { return fUPDATE_DATE; }
            set { SetPropertyValue<DateTime>(nameof(UPDATE_DATE), ref fUPDATE_DATE, value); }
        }
        string fDEL_FLAG;
        [Persistent(@"del_flag")]
        public string DEL_FLAG
        {
            get { return fDEL_FLAG; }
            set { SetPropertyValue<string>(nameof(DEL_FLAG), ref fDEL_FLAG, value); }
        }
        string fSYSTEM_URL;
        [Size(5000)]
        [Persistent(@"system_url")]
        public string SYSTEM_URL
        {
            get { return fSYSTEM_URL; }
            set { SetPropertyValue<string>(nameof(SYSTEM_URL), ref fSYSTEM_URL, value); }
        }
    }

}