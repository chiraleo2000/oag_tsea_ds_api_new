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

    [Persistent(@"cms_organize")]
    public partial class CMS_ORGANIZE : XPLiteObject
    {
        int fORGANIZE_ID;
        [Key(true)]
        [Persistent(@"organize_id")]
        public int ORGANIZE_ID
        {
            get { return fORGANIZE_ID; }
            set { SetPropertyValue<int>(nameof(ORGANIZE_ID), ref fORGANIZE_ID, value); }
        }
        string fORGANIZE_ECMS_ID;
        [Size(13)]
        [Persistent(@"organize_ecms_id")]
        public string ORGANIZE_ECMS_ID
        {
            get { return fORGANIZE_ECMS_ID; }
            set { SetPropertyValue<string>(nameof(ORGANIZE_ECMS_ID), ref fORGANIZE_ECMS_ID, value); }
        }
        string fORGANIZE_CODE_LEV1_OLD;
        [Size(50)]
        [Persistent(@"organize_code_lev1_old")]
        public string ORGANIZE_CODE_LEV1_OLD
        {
            get { return fORGANIZE_CODE_LEV1_OLD; }
            set { SetPropertyValue<string>(nameof(ORGANIZE_CODE_LEV1_OLD), ref fORGANIZE_CODE_LEV1_OLD, value); }
        }
        string fORGANIZE_CODE_LEV2_OLD;
        [Size(50)]
        [Persistent(@"organize_code_lev2_old")]
        public string ORGANIZE_CODE_LEV2_OLD
        {
            get { return fORGANIZE_CODE_LEV2_OLD; }
            set { SetPropertyValue<string>(nameof(ORGANIZE_CODE_LEV2_OLD), ref fORGANIZE_CODE_LEV2_OLD, value); }
        }
        string fORGANIZE_CODE_LEV3_OLD;
        [Size(50)]
        [Persistent(@"organize_code_lev3_old")]
        public string ORGANIZE_CODE_LEV3_OLD
        {
            get { return fORGANIZE_CODE_LEV3_OLD; }
            set { SetPropertyValue<string>(nameof(ORGANIZE_CODE_LEV3_OLD), ref fORGANIZE_CODE_LEV3_OLD, value); }
        }
        string fORGANIZE_CODE_LEV4_OLD;
        [Size(50)]
        [Persistent(@"organize_code_lev4_old")]
        public string ORGANIZE_CODE_LEV4_OLD
        {
            get { return fORGANIZE_CODE_LEV4_OLD; }
            set { SetPropertyValue<string>(nameof(ORGANIZE_CODE_LEV4_OLD), ref fORGANIZE_CODE_LEV4_OLD, value); }
        }
        string fORGANIZE_CODE_LEV5_OLD;
        [Size(50)]
        [Persistent(@"organize_code_lev5_old")]
        public string ORGANIZE_CODE_LEV5_OLD
        {
            get { return fORGANIZE_CODE_LEV5_OLD; }
            set { SetPropertyValue<string>(nameof(ORGANIZE_CODE_LEV5_OLD), ref fORGANIZE_CODE_LEV5_OLD, value); }
        }
        int? fORGANIZE_CODE_LEV1;
        [Persistent(@"organize_code_lev1")]
        public int? ORGANIZE_CODE_LEV1
        {
            get { return fORGANIZE_CODE_LEV1; }
            set { SetPropertyValue<int?>(nameof(ORGANIZE_CODE_LEV1), ref fORGANIZE_CODE_LEV1, value); }
        }
        int? fORGANIZE_CODE_LEV2;
        [Persistent(@"organize_code_lev2")]
        public int? ORGANIZE_CODE_LEV2
        {
            get { return fORGANIZE_CODE_LEV2; }
            set { SetPropertyValue<int?>(nameof(ORGANIZE_CODE_LEV2), ref fORGANIZE_CODE_LEV2, value); }
        }
        int? fORGANIZE_CODE_LEV3;
        [Persistent(@"organize_code_lev3")]
        public int? ORGANIZE_CODE_LEV3
        {
            get { return fORGANIZE_CODE_LEV3; }
            set { SetPropertyValue<int?>(nameof(ORGANIZE_CODE_LEV3), ref fORGANIZE_CODE_LEV3, value); }
        }
        int? fORGANIZE_CODE_LEV4;
        [Persistent(@"organize_code_lev4")]
        public int? ORGANIZE_CODE_LEV4
        {
            get { return fORGANIZE_CODE_LEV4; }
            set { SetPropertyValue<int?>(nameof(ORGANIZE_CODE_LEV4), ref fORGANIZE_CODE_LEV4, value); }
        }
        int? fORGANIZE_CODE_LEV5;
        [Persistent(@"organize_code_lev5")]
        public int? ORGANIZE_CODE_LEV5
        {
            get { return fORGANIZE_CODE_LEV5; }
            set { SetPropertyValue<int?>(nameof(ORGANIZE_CODE_LEV5), ref fORGANIZE_CODE_LEV5, value); }
        }
        int? fORGANIZE_ROOT_ID;
        [Persistent(@"organize_root_id")]
        public int? ORGANIZE_ROOT_ID
        {
            get { return fORGANIZE_ROOT_ID; }
            set { SetPropertyValue<int?>(nameof(ORGANIZE_ROOT_ID), ref fORGANIZE_ROOT_ID, value); }
        }
        int? fORGANIZE_LEVEL_ID;
        [Persistent(@"organize_level_id")]
        public int? ORGANIZE_LEVEL_ID
        {
            get { return fORGANIZE_LEVEL_ID; }
            set { SetPropertyValue<int?>(nameof(ORGANIZE_LEVEL_ID), ref fORGANIZE_LEVEL_ID, value); }
        }
        string fORGANIZE_ARIA_CODE;
        [Size(2)]
        [Persistent(@"organize_aria_code")]
        public string ORGANIZE_ARIA_CODE
        {
            get { return fORGANIZE_ARIA_CODE; }
            set { SetPropertyValue<string>(nameof(ORGANIZE_ARIA_CODE), ref fORGANIZE_ARIA_CODE, value); }
        }
        string fORGANIZE_NAME_DETAIL;
        [Size(5000)]
        [Persistent(@"organize_name_detail")]
        public string ORGANIZE_NAME_DETAIL
        {
            get { return fORGANIZE_NAME_DETAIL; }
            set { SetPropertyValue<string>(nameof(ORGANIZE_NAME_DETAIL), ref fORGANIZE_NAME_DETAIL, value); }
        }
        string fORGANIZE_NAME_THA;
        [Size(500)]
        [Persistent(@"organize_name_tha")]
        public string ORGANIZE_NAME_THA
        {
            get { return fORGANIZE_NAME_THA; }
            set { SetPropertyValue<string>(nameof(ORGANIZE_NAME_THA), ref fORGANIZE_NAME_THA, value); }
        }
        string fORGANIZE_NAME_ENG;
        [Size(250)]
        [Persistent(@"organize_name_eng")]
        public string ORGANIZE_NAME_ENG
        {
            get { return fORGANIZE_NAME_ENG; }
            set { SetPropertyValue<string>(nameof(ORGANIZE_NAME_ENG), ref fORGANIZE_NAME_ENG, value); }
        }
        string fORGANIZE_ABBR_THA;
        [Size(250)]
        [Persistent(@"organize_abbr_tha")]
        public string ORGANIZE_ABBR_THA
        {
            get { return fORGANIZE_ABBR_THA; }
            set { SetPropertyValue<string>(nameof(ORGANIZE_ABBR_THA), ref fORGANIZE_ABBR_THA, value); }
        }
        string fORGANIZE_ABBR_ENG;
        [Size(250)]
        [Persistent(@"organize_abbr_eng")]
        public string ORGANIZE_ABBR_ENG
        {
            get { return fORGANIZE_ABBR_ENG; }
            set { SetPropertyValue<string>(nameof(ORGANIZE_ABBR_ENG), ref fORGANIZE_ABBR_ENG, value); }
        }
        string fORGANIZE_TELEPHONE;
        [Size(250)]
        [Persistent(@"organize_telephone")]
        public string ORGANIZE_TELEPHONE
        {
            get { return fORGANIZE_TELEPHONE; }
            set { SetPropertyValue<string>(nameof(ORGANIZE_TELEPHONE), ref fORGANIZE_TELEPHONE, value); }
        }
        string fORGANIZE_FAX;
        [Size(250)]
        [Persistent(@"organize_fax")]
        public string ORGANIZE_FAX
        {
            get { return fORGANIZE_FAX; }
            set { SetPropertyValue<string>(nameof(ORGANIZE_FAX), ref fORGANIZE_FAX, value); }
        }
        string fORGANIZE_CONTACT;
        [Size(250)]
        [Persistent(@"organize_contact")]
        public string ORGANIZE_CONTACT
        {
            get { return fORGANIZE_CONTACT; }
            set { SetPropertyValue<string>(nameof(ORGANIZE_CONTACT), ref fORGANIZE_CONTACT, value); }
        }
        string fORGANIZE_EMAIL;
        [Size(250)]
        [Persistent(@"organize_email")]
        public string ORGANIZE_EMAIL
        {
            get { return fORGANIZE_EMAIL; }
            set { SetPropertyValue<string>(nameof(ORGANIZE_EMAIL), ref fORGANIZE_EMAIL, value); }
        }
        string fORGANIZE_ADDRESS_NO;
        [Size(16)]
        [Persistent(@"organize_address_no")]
        public string ORGANIZE_ADDRESS_NO
        {
            get { return fORGANIZE_ADDRESS_NO; }
            set { SetPropertyValue<string>(nameof(ORGANIZE_ADDRESS_NO), ref fORGANIZE_ADDRESS_NO, value); }
        }
        string fORGANIZE_ADDRESS_MOO;
        [Size(16)]
        [Persistent(@"organize_address_moo")]
        public string ORGANIZE_ADDRESS_MOO
        {
            get { return fORGANIZE_ADDRESS_MOO; }
            set { SetPropertyValue<string>(nameof(ORGANIZE_ADDRESS_MOO), ref fORGANIZE_ADDRESS_MOO, value); }
        }
        string fORGANIZE_ADDRESS_BUILDING;
        [Size(255)]
        [Persistent(@"organize_address_building")]
        public string ORGANIZE_ADDRESS_BUILDING
        {
            get { return fORGANIZE_ADDRESS_BUILDING; }
            set { SetPropertyValue<string>(nameof(ORGANIZE_ADDRESS_BUILDING), ref fORGANIZE_ADDRESS_BUILDING, value); }
        }
        string fORGANIZE_ADDRESS_SOI;
        [Size(255)]
        [Persistent(@"organize_address_soi")]
        public string ORGANIZE_ADDRESS_SOI
        {
            get { return fORGANIZE_ADDRESS_SOI; }
            set { SetPropertyValue<string>(nameof(ORGANIZE_ADDRESS_SOI), ref fORGANIZE_ADDRESS_SOI, value); }
        }
        string fORGANIZE_ADDRESS_STREET;
        [Size(255)]
        [Persistent(@"organize_address_street")]
        public string ORGANIZE_ADDRESS_STREET
        {
            get { return fORGANIZE_ADDRESS_STREET; }
            set { SetPropertyValue<string>(nameof(ORGANIZE_ADDRESS_STREET), ref fORGANIZE_ADDRESS_STREET, value); }
        }
        int? fORGANIZE_ADDRESS_PROVINCE;
        [Persistent(@"organize_address_province")]
        public int? ORGANIZE_ADDRESS_PROVINCE
        {
            get { return fORGANIZE_ADDRESS_PROVINCE; }
            set { SetPropertyValue<int?>(nameof(ORGANIZE_ADDRESS_PROVINCE), ref fORGANIZE_ADDRESS_PROVINCE, value); }
        }
        int? fORGANIZE_ADDRESS_DISRICT;
        [Persistent(@"organize_address_disrict")]
        public int? ORGANIZE_ADDRESS_DISRICT
        {
            get { return fORGANIZE_ADDRESS_DISRICT; }
            set { SetPropertyValue<int?>(nameof(ORGANIZE_ADDRESS_DISRICT), ref fORGANIZE_ADDRESS_DISRICT, value); }
        }
        int? fORGANIZE_ADDRESS_SUB_DISTRICT;
        [Persistent(@"organize_address_sub_district")]
        public int? ORGANIZE_ADDRESS_SUB_DISTRICT
        {
            get { return fORGANIZE_ADDRESS_SUB_DISTRICT; }
            set { SetPropertyValue<int?>(nameof(ORGANIZE_ADDRESS_SUB_DISTRICT), ref fORGANIZE_ADDRESS_SUB_DISTRICT, value); }
        }
        int? fORGANIZE_ADDRESS_POSTCODE;
        [Persistent(@"organize_address_postcode")]
        public int? ORGANIZE_ADDRESS_POSTCODE
        {
            get { return fORGANIZE_ADDRESS_POSTCODE; }
            set { SetPropertyValue<int?>(nameof(ORGANIZE_ADDRESS_POSTCODE), ref fORGANIZE_ADDRESS_POSTCODE, value); }
        }
        string fORGANIZE_IMAGE_PATH;
        [Size(500)]
        [Persistent(@"organize_image_path")]
        public string ORGANIZE_IMAGE_PATH
        {
            get { return fORGANIZE_IMAGE_PATH; }
            set { SetPropertyValue<string>(nameof(ORGANIZE_IMAGE_PATH), ref fORGANIZE_IMAGE_PATH, value); }
        }
        string fORGANIZE_LOGO_PATH;
        [Size(500)]
        [Persistent(@"organize_logo_path")]
        public string ORGANIZE_LOGO_PATH
        {
            get { return fORGANIZE_LOGO_PATH; }
            set { SetPropertyValue<string>(nameof(ORGANIZE_LOGO_PATH), ref fORGANIZE_LOGO_PATH, value); }
        }
        string fORGANIZE_FILE_PATH;
        [Size(500)]
        [Persistent(@"organize_file_path")]
        public string ORGANIZE_FILE_PATH
        {
            get { return fORGANIZE_FILE_PATH; }
            set { SetPropertyValue<string>(nameof(ORGANIZE_FILE_PATH), ref fORGANIZE_FILE_PATH, value); }
        }
        string fORGANIZE_URL_INTERNET;
        [Size(500)]
        [Persistent(@"organize_url_internet")]
        public string ORGANIZE_URL_INTERNET
        {
            get { return fORGANIZE_URL_INTERNET; }
            set { SetPropertyValue<string>(nameof(ORGANIZE_URL_INTERNET), ref fORGANIZE_URL_INTERNET, value); }
        }
        string fORGANIZE_URL_INTRANET;
        [Size(500)]
        [Persistent(@"organize_url_intranet")]
        public string ORGANIZE_URL_INTRANET
        {
            get { return fORGANIZE_URL_INTRANET; }
            set { SetPropertyValue<string>(nameof(ORGANIZE_URL_INTRANET), ref fORGANIZE_URL_INTRANET, value); }
        }
        string fORGANIZE_URL_DM;
        [Size(500)]
        [Persistent(@"organize_url_dm")]
        public string ORGANIZE_URL_DM
        {
            get { return fORGANIZE_URL_DM; }
            set { SetPropertyValue<string>(nameof(ORGANIZE_URL_DM), ref fORGANIZE_URL_DM, value); }
        }
        string fORGANIZE_FORMAL_FLAG;
        [Size(1)]
        [Persistent(@"organize_formal_flag")]
        public string ORGANIZE_FORMAL_FLAG
        {
            get { return fORGANIZE_FORMAL_FLAG; }
            set { SetPropertyValue<string>(nameof(ORGANIZE_FORMAL_FLAG), ref fORGANIZE_FORMAL_FLAG, value); }
        }
        int? fORGANIZE_TYPE_ID;
        [Persistent(@"organize_type_id")]
        public int? ORGANIZE_TYPE_ID
        {
            get { return fORGANIZE_TYPE_ID; }
            set { SetPropertyValue<int?>(nameof(ORGANIZE_TYPE_ID), ref fORGANIZE_TYPE_ID, value); }
        }
        int? fORGANIZE_SEQ;
        [Persistent(@"organize_seq")]
        public int? ORGANIZE_SEQ
        {
            get { return fORGANIZE_SEQ; }
            set { SetPropertyValue<int?>(nameof(ORGANIZE_SEQ), ref fORGANIZE_SEQ, value); }
        }
        int? fGOVERNMENT_ID;
        [Persistent(@"government_id")]
        public int? GOVERNMENT_ID
        {
            get { return fGOVERNMENT_ID; }
            set { SetPropertyValue<int?>(nameof(GOVERNMENT_ID), ref fGOVERNMENT_ID, value); }
        }
        int? fGOVERNMENT_TYPE_ID;
        [Persistent(@"government_type_id")]
        public int? GOVERNMENT_TYPE_ID
        {
            get { return fGOVERNMENT_TYPE_ID; }
            set { SetPropertyValue<int?>(nameof(GOVERNMENT_TYPE_ID), ref fGOVERNMENT_TYPE_ID, value); }
        }
        int? fMANAGER_ID;
        [Persistent(@"manager_id")]
        public int? MANAGER_ID
        {
            get { return fMANAGER_ID; }
            set { SetPropertyValue<int?>(nameof(MANAGER_ID), ref fMANAGER_ID, value); }
        }
        int? fMANAGER2_ID;
        [Persistent(@"manager2_id")]
        public int? MANAGER2_ID
        {
            get { return fMANAGER2_ID; }
            set { SetPropertyValue<int?>(nameof(MANAGER2_ID), ref fMANAGER2_ID, value); }
        }
        int fCREATE_USER_ID;
        [Persistent(@"create_user_id")]
        public int CREATE_USER_ID
        {
            get { return fCREATE_USER_ID; }
            set { SetPropertyValue<int>(nameof(CREATE_USER_ID), ref fCREATE_USER_ID, value); }
        }
        int? fUPDATE_USER_ID;
        [Persistent(@"update_user_id")]
        public int? UPDATE_USER_ID
        {
            get { return fUPDATE_USER_ID; }
            set { SetPropertyValue<int?>(nameof(UPDATE_USER_ID), ref fUPDATE_USER_ID, value); }
        }
        DateTime fCREATE_DATE;
        [Persistent(@"create_date")]
        public DateTime CREATE_DATE
        {
            get { return fCREATE_DATE; }
            set { SetPropertyValue<DateTime>(nameof(CREATE_DATE), ref fCREATE_DATE, value); }
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
        int? fREF_ID;
        [Persistent(@"ref_id")]
        public int? REF_ID
        {
            get { return fREF_ID; }
            set { SetPropertyValue<int?>(nameof(REF_ID), ref fREF_ID, value); }
        }
        string fREF_UNIQUE;
        [Size(17)]
        [Persistent(@"ref_unique")]
        public string REF_UNIQUE
        {
            get { return fREF_UNIQUE; }
            set { SetPropertyValue<string>(nameof(REF_UNIQUE), ref fREF_UNIQUE, value); }
        }
    }

}
