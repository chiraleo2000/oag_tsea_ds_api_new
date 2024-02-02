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

    [Persistent(@"view_holiday_info")]
    public partial class VIEW_HOLIDAY_INFO : XPLiteObject
    {
        int fHOLIDAY_INFO_ID;
        [Key]
        [Persistent(@"holiday_info_id")]
        public int HOLIDAY_INFO_ID
        {
            get { return fHOLIDAY_INFO_ID; }
            set { SetPropertyValue<int>(nameof(HOLIDAY_INFO_ID), ref fHOLIDAY_INFO_ID, value); }
        }
        int fORG_ROOT_ID;
        [Persistent(@"org_root_id")]
        public int ORG_ROOT_ID
        {
            get { return fORG_ROOT_ID; }
            set { SetPropertyValue<int>(nameof(ORG_ROOT_ID), ref fORG_ROOT_ID, value); }
        }
        string fHOLIDAY_INFO_CODE;
        [Size(3)]
        [Persistent(@"holiday_info_code")]
        public string HOLIDAY_INFO_CODE
        {
            get { return fHOLIDAY_INFO_CODE; }
            set { SetPropertyValue<string>(nameof(HOLIDAY_INFO_CODE), ref fHOLIDAY_INFO_CODE, value); }
        }
        string fHOLIDAY_INFO_NAME;
        [Size(200)]
        [Persistent(@"holiday_info_name")]
        public string HOLIDAY_INFO_NAME
        {
            get { return fHOLIDAY_INFO_NAME; }
            set { SetPropertyValue<string>(nameof(HOLIDAY_INFO_NAME), ref fHOLIDAY_INFO_NAME, value); }
        }
        DateTime fHOLIDAY_INFO_DATE;
        [Persistent(@"holiday_info_date")]
        public DateTime HOLIDAY_INFO_DATE
        {
            get { return fHOLIDAY_INFO_DATE; }
            set { SetPropertyValue<DateTime>(nameof(HOLIDAY_INFO_DATE), ref fHOLIDAY_INFO_DATE, value); }
        }
        string fHOLIDAY_INFO_DESC;
        [Size(500)]
        [Persistent(@"holiday_info_desc")]
        public string HOLIDAY_INFO_DESC
        {
            get { return fHOLIDAY_INFO_DESC; }
            set { SetPropertyValue<string>(nameof(HOLIDAY_INFO_DESC), ref fHOLIDAY_INFO_DESC, value); }
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