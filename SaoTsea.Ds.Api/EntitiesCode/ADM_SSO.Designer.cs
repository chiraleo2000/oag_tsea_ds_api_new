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

    [Persistent(@"adm_sso")]
    public partial class ADM_SSO : XPLiteObject
    {
        int fSSO_ID;
        [Key(true)]
        [Persistent(@"sso_id")]
        public int SSO_ID
        {
            get { return fSSO_ID; }
            set { SetPropertyValue<int>(nameof(SSO_ID), ref fSSO_ID, value); }
        }
        int fSYSTEM_ID;
        [Persistent(@"system_id")]
        public int SYSTEM_ID
        {
            get { return fSYSTEM_ID; }
            set { SetPropertyValue<int>(nameof(SYSTEM_ID), ref fSYSTEM_ID, value); }
        }
        string fUSER_NAME;
        [Size(500)]
        [Persistent(@"user_name")]
        public string USER_NAME
        {
            get { return fUSER_NAME; }
            set { SetPropertyValue<string>(nameof(USER_NAME), ref fUSER_NAME, value); }
        }
        int fPERSONAL_ID;
        [Persistent(@"personal_id")]
        public int PERSONAL_ID
        {
            get { return fPERSONAL_ID; }
            set { SetPropertyValue<int>(nameof(PERSONAL_ID), ref fPERSONAL_ID, value); }
        }
        string fREMARK;
        [Size(5000)]
        [Persistent(@"remark")]
        public string REMARK
        {
            get { return fREMARK; }
            set { SetPropertyValue<string>(nameof(REMARK), ref fREMARK, value); }
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
    }

}
