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

    [Persistent(@"view_doc_attachment_all")]
    public partial class VIEW_DOC_ATTACHMENT_ALL : XPLiteObject
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
        int fINST_ATTACHMENT_TYPE_ID;
        [Persistent(@"inst_attachment_type_id")]
        public int INST_ATTACHMENT_TYPE_ID
        {
            get { return fINST_ATTACHMENT_TYPE_ID; }
            set { SetPropertyValue<int>(nameof(INST_ATTACHMENT_TYPE_ID), ref fINST_ATTACHMENT_TYPE_ID, value); }
        }
        string fINST_ATTACHMENT_TYPE_NAME;
        [Size(2000)]
        [Persistent(@"inst_attachment_type_name")]
        public string INST_ATTACHMENT_TYPE_NAME
        {
            get { return fINST_ATTACHMENT_TYPE_NAME; }
            set { SetPropertyValue<string>(nameof(INST_ATTACHMENT_TYPE_NAME), ref fINST_ATTACHMENT_TYPE_NAME, value); }
        }
        string fRECORD_STATUS;
        [Persistent(@"record_status")]
        public string RECORD_STATUS
        {
            get { return fRECORD_STATUS; }
            set { SetPropertyValue<string>(nameof(RECORD_STATUS), ref fRECORD_STATUS, value); }
        }
        DateTime fCREATE_DATE;
        [Persistent(@"create_date")]
        public DateTime CREATE_DATE
        {
            get { return fCREATE_DATE; }
            set { SetPropertyValue<DateTime>(nameof(CREATE_DATE), ref fCREATE_DATE, value); }
        }
    }

}
