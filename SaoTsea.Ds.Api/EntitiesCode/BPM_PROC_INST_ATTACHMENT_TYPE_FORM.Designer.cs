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

    [Persistent(@"bpm_proc_inst_attachment_type_form")]
    public partial class BPM_PROC_INST_ATTACHMENT_TYPE_FORM : XPLiteObject
    {
        int fINST_ATTACHMENT_TYPE_FORM_ID;
        [Key]
        [Persistent(@"inst_attachment_type_form_id")]
        public int INST_ATTACHMENT_TYPE_FORM_ID
        {
            get { return fINST_ATTACHMENT_TYPE_FORM_ID; }
            set { SetPropertyValue<int>(nameof(INST_ATTACHMENT_TYPE_FORM_ID), ref fINST_ATTACHMENT_TYPE_FORM_ID, value); }
        }
        int fFORM_ID;
        [Persistent(@"form_id")]
        public int FORM_ID
        {
            get { return fFORM_ID; }
            set { SetPropertyValue<int>(nameof(FORM_ID), ref fFORM_ID, value); }
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
        string fREQUIRE_FLAG;
        [Persistent(@"require_flag")]
        public string REQUIRE_FLAG
        {
            get { return fREQUIRE_FLAG; }
            set { SetPropertyValue<string>(nameof(REQUIRE_FLAG), ref fREQUIRE_FLAG, value); }
        }
        int fATTACHMENT_TYPE_ID;
        [Persistent(@"attachment_type_id")]
        public int ATTACHMENT_TYPE_ID
        {
            get { return fATTACHMENT_TYPE_ID; }
            set { SetPropertyValue<int>(nameof(ATTACHMENT_TYPE_ID), ref fATTACHMENT_TYPE_ID, value); }
        }
        int fATTACHMENT_TYPE_SEQ;
        [Persistent(@"attachment_type_seq")]
        public int ATTACHMENT_TYPE_SEQ
        {
            get { return fATTACHMENT_TYPE_SEQ; }
            set { SetPropertyValue<int>(nameof(ATTACHMENT_TYPE_SEQ), ref fATTACHMENT_TYPE_SEQ, value); }
        }
    }

}
