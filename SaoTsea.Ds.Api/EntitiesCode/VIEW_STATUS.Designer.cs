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

    [Persistent(@"view_status")]
    public partial class VIEW_STATUS : XPLiteObject
    {
        int fSTATUS_ID;
        [Key]
        [Persistent(@"status_id")]
        public int STATUS_ID
        {
            get { return fSTATUS_ID; }
            set { SetPropertyValue<int>(nameof(STATUS_ID), ref fSTATUS_ID, value); }
        }
        string fSTATUS_NAME;
        [Size(200)]
        [Persistent(@"status_name")]
        public string STATUS_NAME
        {
            get { return fSTATUS_NAME; }
            set { SetPropertyValue<string>(nameof(STATUS_NAME), ref fSTATUS_NAME, value); }
        }
        int fGROUP_STATUS_ID;
        [Persistent(@"group_status_id")]
        public int GROUP_STATUS_ID
        {
            get { return fGROUP_STATUS_ID; }
            set { SetPropertyValue<int>(nameof(GROUP_STATUS_ID), ref fGROUP_STATUS_ID, value); }
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
        int? fUPDATE_USER_ID;
        [Persistent(@"update_user_id")]
        public int? UPDATE_USER_ID
        {
            get { return fUPDATE_USER_ID; }
            set { SetPropertyValue<int?>(nameof(UPDATE_USER_ID), ref fUPDATE_USER_ID, value); }
        }
        DateTime? fUPDATE_DATE;
        [Persistent(@"update_date")]
        public DateTime? UPDATE_DATE
        {
            get { return fUPDATE_DATE; }
            set { SetPropertyValue<DateTime?>(nameof(UPDATE_DATE), ref fUPDATE_DATE, value); }
        }
        string fDEL_FLAG;
        [Persistent(@"del_flag")]
        public string DEL_FLAG
        {
            get { return fDEL_FLAG; }
            set { SetPropertyValue<string>(nameof(DEL_FLAG), ref fDEL_FLAG, value); }
        }
        int fSTATUS_SEQ;
        [Persistent(@"status_seq")]
        public int STATUS_SEQ
        {
            get { return fSTATUS_SEQ; }
            set { SetPropertyValue<int>(nameof(STATUS_SEQ), ref fSTATUS_SEQ, value); }
        }
        string fSTATUS_ICON;
        [Size(200)]
        [Persistent(@"status_icon")]
        public string STATUS_ICON
        {
            get { return fSTATUS_ICON; }
            set { SetPropertyValue<string>(nameof(STATUS_ICON), ref fSTATUS_ICON, value); }
        }
        string fSTATUS_CODE;
        [Size(3)]
        [Persistent(@"status_code")]
        public string STATUS_CODE
        {
            get { return fSTATUS_CODE; }
            set { SetPropertyValue<string>(nameof(STATUS_CODE), ref fSTATUS_CODE, value); }
        }
        string fGROUP_STATUS_CODE;
        [Persistent(@"group_status_code")]
        public string GROUP_STATUS_CODE
        {
            get { return fGROUP_STATUS_CODE; }
            set { SetPropertyValue<string>(nameof(GROUP_STATUS_CODE), ref fGROUP_STATUS_CODE, value); }
        }
        string fGROUP_STATUS_NAME;
        [Persistent(@"group_status_name")]
        public string GROUP_STATUS_NAME
        {
            get { return fGROUP_STATUS_NAME; }
            set { SetPropertyValue<string>(nameof(GROUP_STATUS_NAME), ref fGROUP_STATUS_NAME, value); }
        }
    }

}
