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

    [Persistent(@"view_app_org")]
    public partial class VIEW_APP_ORG : XPLiteObject
    {
        int fAPP_ORG_ID;
        [Key]
        [Persistent(@"app_org_id")]
        public int APP_ORG_ID
        {
            get { return fAPP_ORG_ID; }
            set { SetPropertyValue<int>(nameof(APP_ORG_ID), ref fAPP_ORG_ID, value); }
        }
        int fAPP_ID;
        [Persistent(@"app_id")]
        public int APP_ID
        {
            get { return fAPP_ID; }
            set { SetPropertyValue<int>(nameof(APP_ID), ref fAPP_ID, value); }
        }
        int fORG_ROOT_ID;
        [Persistent(@"org_root_id")]
        public int ORG_ROOT_ID
        {
            get { return fORG_ROOT_ID; }
            set { SetPropertyValue<int>(nameof(ORG_ROOT_ID), ref fORG_ROOT_ID, value); }
        }
        string fRECORD_STATUS;
        [Persistent(@"record_status")]
        public string RECORD_STATUS
        {
            get { return fRECORD_STATUS; }
            set { SetPropertyValue<string>(nameof(RECORD_STATUS), ref fRECORD_STATUS, value); }
        }
        string fDEL_FLAG;
        [Persistent(@"del_flag")]
        public string DEL_FLAG
        {
            get { return fDEL_FLAG; }
            set { SetPropertyValue<string>(nameof(DEL_FLAG), ref fDEL_FLAG, value); }
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
        string fAPP_CODE;
        [Persistent(@"app_code")]
        public string APP_CODE
        {
            get { return fAPP_CODE; }
            set { SetPropertyValue<string>(nameof(APP_CODE), ref fAPP_CODE, value); }
        }
        string fAPP_NAME;
        [Size(500)]
        [Persistent(@"app_name")]
        public string APP_NAME
        {
            get { return fAPP_NAME; }
            set { SetPropertyValue<string>(nameof(APP_NAME), ref fAPP_NAME, value); }
        }
        string fAPP_ICON;
        [Size(500)]
        [Persistent(@"app_icon")]
        public string APP_ICON
        {
            get { return fAPP_ICON; }
            set { SetPropertyValue<string>(nameof(APP_ICON), ref fAPP_ICON, value); }
        }
        string fAPP_URL;
        [Size(500)]
        [Persistent(@"app_url")]
        public string APP_URL
        {
            get { return fAPP_URL; }
            set { SetPropertyValue<string>(nameof(APP_URL), ref fAPP_URL, value); }
        }
        string fAPP_SEQ;
        [Size(10)]
        [Persistent(@"app_seq")]
        public string APP_SEQ
        {
            get { return fAPP_SEQ; }
            set { SetPropertyValue<string>(nameof(APP_SEQ), ref fAPP_SEQ, value); }
        }
        string fORGANIZE_NAME_THA;
        [Size(500)]
        [Persistent(@"organize_name_tha")]
        public string ORGANIZE_NAME_THA
        {
            get { return fORGANIZE_NAME_THA; }
            set { SetPropertyValue<string>(nameof(ORGANIZE_NAME_THA), ref fORGANIZE_NAME_THA, value); }
        }
    }

}
