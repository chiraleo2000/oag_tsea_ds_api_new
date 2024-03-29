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

    [Persistent(@"cms_personal")]
    public partial class CMS_PERSONAL : XPLiteObject
    {
        int fPERSONAL_ID;
        [Key(true)]
        [Persistent(@"personal_id")]
        public int PERSONAL_ID
        {
            get { return fPERSONAL_ID; }
            set { SetPropertyValue<int>(nameof(PERSONAL_ID), ref fPERSONAL_ID, value); }
        }
        string fPERSONAL_CODE;
        [Persistent(@"personal_code")]
        public string PERSONAL_CODE
        {
            get { return fPERSONAL_CODE; }
            set { SetPropertyValue<string>(nameof(PERSONAL_CODE), ref fPERSONAL_CODE, value); }
        }
        int? fTITLE_ID;
        [Persistent(@"title_id")]
        public int? TITLE_ID
        {
            get { return fTITLE_ID; }
            set { SetPropertyValue<int?>(nameof(TITLE_ID), ref fTITLE_ID, value); }
        }
        string fPERSONAL_FNAME_THA;
        [Size(255)]
        [Persistent(@"personal_fname_tha")]
        public string PERSONAL_FNAME_THA
        {
            get { return fPERSONAL_FNAME_THA; }
            set { SetPropertyValue<string>(nameof(PERSONAL_FNAME_THA), ref fPERSONAL_FNAME_THA, value); }
        }
        string fPERSONAL_LNAME_THA;
        [Size(255)]
        [Persistent(@"personal_lname_tha")]
        public string PERSONAL_LNAME_THA
        {
            get { return fPERSONAL_LNAME_THA; }
            set { SetPropertyValue<string>(nameof(PERSONAL_LNAME_THA), ref fPERSONAL_LNAME_THA, value); }
        }
        DateTime? fPERSONAL_START_DATE;
        [Persistent(@"personal_start_date")]
        public DateTime? PERSONAL_START_DATE
        {
            get { return fPERSONAL_START_DATE; }
            set { SetPropertyValue<DateTime?>(nameof(PERSONAL_START_DATE), ref fPERSONAL_START_DATE, value); }
        }
        DateTime? fPERSONAL_BIRTH_DATE;
        [Persistent(@"personal_birth_date")]
        public DateTime? PERSONAL_BIRTH_DATE
        {
            get { return fPERSONAL_BIRTH_DATE; }
            set { SetPropertyValue<DateTime?>(nameof(PERSONAL_BIRTH_DATE), ref fPERSONAL_BIRTH_DATE, value); }
        }
        DateTime? fPERSONAL_LEAVE_DATE;
        [Persistent(@"personal_leave_date")]
        public DateTime? PERSONAL_LEAVE_DATE
        {
            get { return fPERSONAL_LEAVE_DATE; }
            set { SetPropertyValue<DateTime?>(nameof(PERSONAL_LEAVE_DATE), ref fPERSONAL_LEAVE_DATE, value); }
        }
        string fPERSONAL_SIGNATURE_PICTURE;
        [Size(255)]
        [Persistent(@"personal_signature_picture")]
        public string PERSONAL_SIGNATURE_PICTURE
        {
            get { return fPERSONAL_SIGNATURE_PICTURE; }
            set { SetPropertyValue<string>(nameof(PERSONAL_SIGNATURE_PICTURE), ref fPERSONAL_SIGNATURE_PICTURE, value); }
        }
        int fPERSONAL_TYPE_ID;
        [Persistent(@"personal_type_id")]
        public int PERSONAL_TYPE_ID
        {
            get { return fPERSONAL_TYPE_ID; }
            set { SetPropertyValue<int>(nameof(PERSONAL_TYPE_ID), ref fPERSONAL_TYPE_ID, value); }
        }
        int? fPOSITION_ID;
        [Persistent(@"position_id")]
        public int? POSITION_ID
        {
            get { return fPOSITION_ID; }
            set { SetPropertyValue<int?>(nameof(POSITION_ID), ref fPOSITION_ID, value); }
        }
        string fPOSITION_NAME;
        [Size(500)]
        [Persistent(@"position_name")]
        public string POSITION_NAME
        {
            get { return fPOSITION_NAME; }
            set { SetPropertyValue<string>(nameof(POSITION_NAME), ref fPOSITION_NAME, value); }
        }
        int? fPOSITION_MNG_ID;
        [Persistent(@"position_mng_id")]
        public int? POSITION_MNG_ID
        {
            get { return fPOSITION_MNG_ID; }
            set { SetPropertyValue<int?>(nameof(POSITION_MNG_ID), ref fPOSITION_MNG_ID, value); }
        }
        string fPOSITION_MNG_NAME;
        [Size(500)]
        [Persistent(@"position_mng_name")]
        public string POSITION_MNG_NAME
        {
            get { return fPOSITION_MNG_NAME; }
            set { SetPropertyValue<string>(nameof(POSITION_MNG_NAME), ref fPOSITION_MNG_NAME, value); }
        }
        int? fPOSITION_MNG_LEVEL;
        [Persistent(@"position_mng_level")]
        public int? POSITION_MNG_LEVEL
        {
            get { return fPOSITION_MNG_LEVEL; }
            set { SetPropertyValue<int?>(nameof(POSITION_MNG_LEVEL), ref fPOSITION_MNG_LEVEL, value); }
        }
        int fORG_ID;
        [Persistent(@"org_id")]
        public int ORG_ID
        {
            get { return fORG_ID; }
            set { SetPropertyValue<int>(nameof(ORG_ID), ref fORG_ID, value); }
        }
        string fORG_NAME;
        [Size(1000)]
        [Persistent(@"org_name")]
        public string ORG_NAME
        {
            get { return fORG_NAME; }
            set { SetPropertyValue<string>(nameof(ORG_NAME), ref fORG_NAME, value); }
        }
        string fPERSONAL_TEL_NO;
        [Size(20)]
        [Persistent(@"personal_tel_no")]
        public string PERSONAL_TEL_NO
        {
            get { return fPERSONAL_TEL_NO; }
            set { SetPropertyValue<string>(nameof(PERSONAL_TEL_NO), ref fPERSONAL_TEL_NO, value); }
        }
        string fPERSONAL_NATIONALITY;
        [Size(500)]
        [Persistent(@"personal_nationality")]
        public string PERSONAL_NATIONALITY
        {
            get { return fPERSONAL_NATIONALITY; }
            set { SetPropertyValue<string>(nameof(PERSONAL_NATIONALITY), ref fPERSONAL_NATIONALITY, value); }
        }
        string fPERSONAL_RACE;
        [Size(500)]
        [Persistent(@"personal_race")]
        public string PERSONAL_RACE
        {
            get { return fPERSONAL_RACE; }
            set { SetPropertyValue<string>(nameof(PERSONAL_RACE), ref fPERSONAL_RACE, value); }
        }
        string fPERSONAL_TEL_HOME;
        [Size(10)]
        [Persistent(@"personal_tel_home")]
        public string PERSONAL_TEL_HOME
        {
            get { return fPERSONAL_TEL_HOME; }
            set { SetPropertyValue<string>(nameof(PERSONAL_TEL_HOME), ref fPERSONAL_TEL_HOME, value); }
        }
        string fPERSONAL_TEL_POSITION;
        [Size(10)]
        [Persistent(@"personal_tel_position")]
        public string PERSONAL_TEL_POSITION
        {
            get { return fPERSONAL_TEL_POSITION; }
            set { SetPropertyValue<string>(nameof(PERSONAL_TEL_POSITION), ref fPERSONAL_TEL_POSITION, value); }
        }
        string fPERSONAL_ADDRESS_HOME_REGISTER;
        [Size(500)]
        [Persistent(@"personal_address_home_register")]
        public string PERSONAL_ADDRESS_HOME_REGISTER
        {
            get { return fPERSONAL_ADDRESS_HOME_REGISTER; }
            set { SetPropertyValue<string>(nameof(PERSONAL_ADDRESS_HOME_REGISTER), ref fPERSONAL_ADDRESS_HOME_REGISTER, value); }
        }
        string fPERSONAL_ACCIDENCE_TEL;
        [Size(10)]
        [Persistent(@"personal_accidence_tel")]
        public string PERSONAL_ACCIDENCE_TEL
        {
            get { return fPERSONAL_ACCIDENCE_TEL; }
            set { SetPropertyValue<string>(nameof(PERSONAL_ACCIDENCE_TEL), ref fPERSONAL_ACCIDENCE_TEL, value); }
        }
        string fPERSONAL_STATUS;
        [Persistent(@"personal_status")]
        public string PERSONAL_STATUS
        {
            get { return fPERSONAL_STATUS; }
            set { SetPropertyValue<string>(nameof(PERSONAL_STATUS), ref fPERSONAL_STATUS, value); }
        }
        string fPERSONAL_CITIZEN_NUMBER;
        [Size(500)]
        [Persistent(@"personal_citizen_number")]
        public string PERSONAL_CITIZEN_NUMBER
        {
            get { return fPERSONAL_CITIZEN_NUMBER; }
            set { SetPropertyValue<string>(nameof(PERSONAL_CITIZEN_NUMBER), ref fPERSONAL_CITIZEN_NUMBER, value); }
        }
        string fPERSONAL_ADDRESS;
        [Size(500)]
        [Persistent(@"personal_address")]
        public string PERSONAL_ADDRESS
        {
            get { return fPERSONAL_ADDRESS; }
            set { SetPropertyValue<string>(nameof(PERSONAL_ADDRESS), ref fPERSONAL_ADDRESS, value); }
        }
        int? fPROVINCE_ID;
        [Persistent(@"province_id")]
        public int? PROVINCE_ID
        {
            get { return fPROVINCE_ID; }
            set { SetPropertyValue<int?>(nameof(PROVINCE_ID), ref fPROVINCE_ID, value); }
        }
        int? fDISTICT_ID;
        [Persistent(@"distict_id")]
        public int? DISTICT_ID
        {
            get { return fDISTICT_ID; }
            set { SetPropertyValue<int?>(nameof(DISTICT_ID), ref fDISTICT_ID, value); }
        }
        int? fSUB_DISTICT_ID;
        [Persistent(@"sub_distict_id")]
        public int? SUB_DISTICT_ID
        {
            get { return fSUB_DISTICT_ID; }
            set { SetPropertyValue<int?>(nameof(SUB_DISTICT_ID), ref fSUB_DISTICT_ID, value); }
        }
        int? fPOST_CODE;
        [Persistent(@"post_code")]
        public int? POST_CODE
        {
            get { return fPOST_CODE; }
            set { SetPropertyValue<int?>(nameof(POST_CODE), ref fPOST_CODE, value); }
        }
        int? fHOME_REGISTER_PROVINCE_ID;
        [Persistent(@"home_register_province_id")]
        public int? HOME_REGISTER_PROVINCE_ID
        {
            get { return fHOME_REGISTER_PROVINCE_ID; }
            set { SetPropertyValue<int?>(nameof(HOME_REGISTER_PROVINCE_ID), ref fHOME_REGISTER_PROVINCE_ID, value); }
        }
        int? fHOME_REGISTER_DISTICT_ID;
        [Persistent(@"home_register_distict_id")]
        public int? HOME_REGISTER_DISTICT_ID
        {
            get { return fHOME_REGISTER_DISTICT_ID; }
            set { SetPropertyValue<int?>(nameof(HOME_REGISTER_DISTICT_ID), ref fHOME_REGISTER_DISTICT_ID, value); }
        }
        int? fHOME_REGISTER_SUB_DISTICT_ID;
        [Persistent(@"home_register_sub_distict_id")]
        public int? HOME_REGISTER_SUB_DISTICT_ID
        {
            get { return fHOME_REGISTER_SUB_DISTICT_ID; }
            set { SetPropertyValue<int?>(nameof(HOME_REGISTER_SUB_DISTICT_ID), ref fHOME_REGISTER_SUB_DISTICT_ID, value); }
        }
        int? fHOME_REGISTER_POST_CODE;
        [Persistent(@"home_register_post_code")]
        public int? HOME_REGISTER_POST_CODE
        {
            get { return fHOME_REGISTER_POST_CODE; }
            set { SetPropertyValue<int?>(nameof(HOME_REGISTER_POST_CODE), ref fHOME_REGISTER_POST_CODE, value); }
        }
        string fACCIDENCE_TEL;
        [Size(10)]
        [Persistent(@"accidence_tel")]
        public string ACCIDENCE_TEL
        {
            get { return fACCIDENCE_TEL; }
            set { SetPropertyValue<string>(nameof(ACCIDENCE_TEL), ref fACCIDENCE_TEL, value); }
        }
        string fACCIDENCE_ADDRESS;
        [Size(500)]
        [Persistent(@"accidence_address")]
        public string ACCIDENCE_ADDRESS
        {
            get { return fACCIDENCE_ADDRESS; }
            set { SetPropertyValue<string>(nameof(ACCIDENCE_ADDRESS), ref fACCIDENCE_ADDRESS, value); }
        }
        int? fACCIDENCE_PROVINCE;
        [Persistent(@"accidence_province")]
        public int? ACCIDENCE_PROVINCE
        {
            get { return fACCIDENCE_PROVINCE; }
            set { SetPropertyValue<int?>(nameof(ACCIDENCE_PROVINCE), ref fACCIDENCE_PROVINCE, value); }
        }
        int? fACCIDENCE_DISTICT;
        [Persistent(@"accidence_distict")]
        public int? ACCIDENCE_DISTICT
        {
            get { return fACCIDENCE_DISTICT; }
            set { SetPropertyValue<int?>(nameof(ACCIDENCE_DISTICT), ref fACCIDENCE_DISTICT, value); }
        }
        int? fACCIDENCE_SUB_DISTICT;
        [Persistent(@"accidence_sub_distict")]
        public int? ACCIDENCE_SUB_DISTICT
        {
            get { return fACCIDENCE_SUB_DISTICT; }
            set { SetPropertyValue<int?>(nameof(ACCIDENCE_SUB_DISTICT), ref fACCIDENCE_SUB_DISTICT, value); }
        }
        int? fACCIDENCE_POST_CODE;
        [Persistent(@"accidence_post_code")]
        public int? ACCIDENCE_POST_CODE
        {
            get { return fACCIDENCE_POST_CODE; }
            set { SetPropertyValue<int?>(nameof(ACCIDENCE_POST_CODE), ref fACCIDENCE_POST_CODE, value); }
        }
        string fPERSONAL_RELIGION;
        [Size(10)]
        [Persistent(@"personal_religion")]
        public string PERSONAL_RELIGION
        {
            get { return fPERSONAL_RELIGION; }
            set { SetPropertyValue<string>(nameof(PERSONAL_RELIGION), ref fPERSONAL_RELIGION, value); }
        }
        string fPERSONAL_EMAIL;
        [Persistent(@"personal_email")]
        public string PERSONAL_EMAIL
        {
            get { return fPERSONAL_EMAIL; }
            set { SetPropertyValue<string>(nameof(PERSONAL_EMAIL), ref fPERSONAL_EMAIL, value); }
        }
        int? fPERSONAL_SALARY;
        [Persistent(@"personal_salary")]
        public int? PERSONAL_SALARY
        {
            get { return fPERSONAL_SALARY; }
            set { SetPropertyValue<int?>(nameof(PERSONAL_SALARY), ref fPERSONAL_SALARY, value); }
        }
        string fPERSONAL_WORK_ADDRESS;
        [Size(500)]
        [Persistent(@"personal_work_address")]
        public string PERSONAL_WORK_ADDRESS
        {
            get { return fPERSONAL_WORK_ADDRESS; }
            set { SetPropertyValue<string>(nameof(PERSONAL_WORK_ADDRESS), ref fPERSONAL_WORK_ADDRESS, value); }
        }
        string fPERSONAL_PICTURE;
        [Size(2000)]
        [Persistent(@"personal_picture")]
        public string PERSONAL_PICTURE
        {
            get { return fPERSONAL_PICTURE; }
            set { SetPropertyValue<string>(nameof(PERSONAL_PICTURE), ref fPERSONAL_PICTURE, value); }
        }
        string fACCIDENCE_PERSON;
        [Size(200)]
        [Persistent(@"accidence_person")]
        public string ACCIDENCE_PERSON
        {
            get { return fACCIDENCE_PERSON; }
            set { SetPropertyValue<string>(nameof(ACCIDENCE_PERSON), ref fACCIDENCE_PERSON, value); }
        }
        string fACCIDENCE_RELATION;
        [Size(200)]
        [Persistent(@"accidence_relation")]
        public string ACCIDENCE_RELATION
        {
            get { return fACCIDENCE_RELATION; }
            set { SetPropertyValue<string>(nameof(ACCIDENCE_RELATION), ref fACCIDENCE_RELATION, value); }
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
        [ColumnDbDefaultValue("'a'::bpchar")]
        public string RECORD_STATUS
        {
            get { return fRECORD_STATUS; }
            set { SetPropertyValue<string>(nameof(RECORD_STATUS), ref fRECORD_STATUS, value); }
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
        string fHOME_REGISTER_ADDRESS;
        [Size(500)]
        [Persistent(@"home_register_address")]
        public string HOME_REGISTER_ADDRESS
        {
            get { return fHOME_REGISTER_ADDRESS; }
            set { SetPropertyValue<string>(nameof(HOME_REGISTER_ADDRESS), ref fHOME_REGISTER_ADDRESS, value); }
        }
        short? fPERSONAL_GENDER;
        [Persistent(@"personal_gender")]
        public short? PERSONAL_GENDER
        {
            get { return fPERSONAL_GENDER; }
            set { SetPropertyValue<short?>(nameof(PERSONAL_GENDER), ref fPERSONAL_GENDER, value); }
        }
        string fPERSONAL_LASER_NUMBER;
        [Size(12)]
        [Persistent(@"personal_laser_number")]
        public string PERSONAL_LASER_NUMBER
        {
            get { return fPERSONAL_LASER_NUMBER; }
            set { SetPropertyValue<string>(nameof(PERSONAL_LASER_NUMBER), ref fPERSONAL_LASER_NUMBER, value); }
        }
        string fPERSONAL_CITIZEN_PICTURE;
        [Size(4000)]
        [Persistent(@"personal_citizen_picture")]
        public string PERSONAL_CITIZEN_PICTURE
        {
            get { return fPERSONAL_CITIZEN_PICTURE; }
            set { SetPropertyValue<string>(nameof(PERSONAL_CITIZEN_PICTURE), ref fPERSONAL_CITIZEN_PICTURE, value); }
        }
        string fPERSONAL_LASER_PICTURE;
        [Size(4000)]
        [Persistent(@"personal_laser_picture")]
        public string PERSONAL_LASER_PICTURE
        {
            get { return fPERSONAL_LASER_PICTURE; }
            set { SetPropertyValue<string>(nameof(PERSONAL_LASER_PICTURE), ref fPERSONAL_LASER_PICTURE, value); }
        }
        string fPERSONAL_IAL;
        [Size(3)]
        [Persistent(@"personal_ial")]
        public string PERSONAL_IAL
        {
            get { return fPERSONAL_IAL; }
            set { SetPropertyValue<string>(nameof(PERSONAL_IAL), ref fPERSONAL_IAL, value); }
        }
        string fPERSONAL_MOO;
        [Size(500)]
        [Persistent(@"personal_moo")]
        public string PERSONAL_MOO
        {
            get { return fPERSONAL_MOO; }
            set { SetPropertyValue<string>(nameof(PERSONAL_MOO), ref fPERSONAL_MOO, value); }
        }
        string fPERSONAL_STREET;
        [Size(500)]
        [Persistent(@"personal_street")]
        public string PERSONAL_STREET
        {
            get { return fPERSONAL_STREET; }
            set { SetPropertyValue<string>(nameof(PERSONAL_STREET), ref fPERSONAL_STREET, value); }
        }
        string fPERSONAL_SOI;
        [Size(500)]
        [Persistent(@"personal_soi")]
        public string PERSONAL_SOI
        {
            get { return fPERSONAL_SOI; }
            set { SetPropertyValue<string>(nameof(PERSONAL_SOI), ref fPERSONAL_SOI, value); }
        }
        string fHOME_REGISTER_MOO;
        [Size(500)]
        [Persistent(@"home_register_moo")]
        public string HOME_REGISTER_MOO
        {
            get { return fHOME_REGISTER_MOO; }
            set { SetPropertyValue<string>(nameof(HOME_REGISTER_MOO), ref fHOME_REGISTER_MOO, value); }
        }
        string fHOME_REGISTER_STREET;
        [Size(500)]
        [Persistent(@"home_register_street")]
        public string HOME_REGISTER_STREET
        {
            get { return fHOME_REGISTER_STREET; }
            set { SetPropertyValue<string>(nameof(HOME_REGISTER_STREET), ref fHOME_REGISTER_STREET, value); }
        }
        string fHOME_REGISTER_SOI;
        [Size(500)]
        [Persistent(@"home_register_soi")]
        public string HOME_REGISTER_SOI
        {
            get { return fHOME_REGISTER_SOI; }
            set { SetPropertyValue<string>(nameof(HOME_REGISTER_SOI), ref fHOME_REGISTER_SOI, value); }
        }
        int? fREF_REGISTER_ID;
        [Persistent(@"ref_register_id")]
        public int? REF_REGISTER_ID
        {
            get { return fREF_REGISTER_ID; }
            set { SetPropertyValue<int?>(nameof(REF_REGISTER_ID), ref fREF_REGISTER_ID, value); }
        }
        string fPERSONAL_MIDDLE_THA;
        [Size(500)]
        [Persistent(@"personal_middle_tha")]
        public string PERSONAL_MIDDLE_THA
        {
            get { return fPERSONAL_MIDDLE_THA; }
            set { SetPropertyValue<string>(nameof(PERSONAL_MIDDLE_THA), ref fPERSONAL_MIDDLE_THA, value); }
        }
        int fPERSONAL_NATION_ID;
        [Persistent(@"personal_nation_id")]
        public int PERSONAL_NATION_ID
        {
            get { return fPERSONAL_NATION_ID; }
            set { SetPropertyValue<int>(nameof(PERSONAL_NATION_ID), ref fPERSONAL_NATION_ID, value); }
        }
        string fPERSONAL_BUILDING;
        [Size(255)]
        [Persistent(@"personal_building")]
        public string PERSONAL_BUILDING
        {
            get { return fPERSONAL_BUILDING; }
            set { SetPropertyValue<string>(nameof(PERSONAL_BUILDING), ref fPERSONAL_BUILDING, value); }
        }
        string fPERSONAL_FLOOR;
        [Size(255)]
        [Persistent(@"personal_floor")]
        public string PERSONAL_FLOOR
        {
            get { return fPERSONAL_FLOOR; }
            set { SetPropertyValue<string>(nameof(PERSONAL_FLOOR), ref fPERSONAL_FLOOR, value); }
        }
        string fSECURITY_FLAG;
        [Persistent(@"security_flag")]
        public string SECURITY_FLAG
        {
            get { return fSECURITY_FLAG; }
            set { SetPropertyValue<string>(nameof(SECURITY_FLAG), ref fSECURITY_FLAG, value); }
        }
        string fSECURITY_TYPE;
        [Persistent(@"security_type")]
        public string SECURITY_TYPE
        {
            get { return fSECURITY_TYPE; }
            set { SetPropertyValue<string>(nameof(SECURITY_TYPE), ref fSECURITY_TYPE, value); }
        }
        string fSECURITY_CODE;
        [Size(6)]
        [Persistent(@"security_code")]
        public string SECURITY_CODE
        {
            get { return fSECURITY_CODE; }
            set { SetPropertyValue<string>(nameof(SECURITY_CODE), ref fSECURITY_CODE, value); }
        }
    }

}
