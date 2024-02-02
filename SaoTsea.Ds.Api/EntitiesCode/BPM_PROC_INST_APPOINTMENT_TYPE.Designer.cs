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

    [Persistent(@"bpm_proc_inst_appointment_type")]
    public partial class BPM_PROC_INST_APPOINTMENT_TYPE : XPLiteObject
    {
        int fAPPOINTMENT_TYPE_ID;
        [Key(true)]
        [Persistent(@"appointment_type_id")]
        public int APPOINTMENT_TYPE_ID
        {
            get { return fAPPOINTMENT_TYPE_ID; }
            set { SetPropertyValue<int>(nameof(APPOINTMENT_TYPE_ID), ref fAPPOINTMENT_TYPE_ID, value); }
        }
        string fAPPOINTMENT_TYPE_NAME;
        [Size(200)]
        [Persistent(@"appointment_type_name")]
        public string APPOINTMENT_TYPE_NAME
        {
            get { return fAPPOINTMENT_TYPE_NAME; }
            set { SetPropertyValue<string>(nameof(APPOINTMENT_TYPE_NAME), ref fAPPOINTMENT_TYPE_NAME, value); }
        }
        char fRECORD_STATUS;
        [Persistent(@"record_status")]
        public char RECORD_STATUS
        {
            get { return fRECORD_STATUS; }
            set { SetPropertyValue<char>(nameof(RECORD_STATUS), ref fRECORD_STATUS, value); }
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
        char fDEL_FLAG;
        [Persistent(@"del_flag")]
        public char DEL_FLAG
        {
            get { return fDEL_FLAG; }
            set { SetPropertyValue<char>(nameof(DEL_FLAG), ref fDEL_FLAG, value); }
        }
        string fAPPOINTMENT_TYPE_CODE;
        [Size(3)]
        [Persistent(@"appointment_type_code")]
        public string APPOINTMENT_TYPE_CODE
        {
            get { return fAPPOINTMENT_TYPE_CODE; }
            set { SetPropertyValue<string>(nameof(APPOINTMENT_TYPE_CODE), ref fAPPOINTMENT_TYPE_CODE, value); }
        }
    }

}
