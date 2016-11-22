using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jord.ACHEQA.Entities
    {
 public   class LookupCategory_Entity
        {
        int _iLookup_Catg_ID;
        int _iApplicationID;
        string _sLookup_Catg_Name;
        string _sCatg_Description;
        string _sRefClause;
        string _sFlexField1_Name;
        string _sFlexField2_Name;
        string _sFlexField3_Name;
        string _sFlexField4_Name;
        string _sFlexField5_Name;
        string _sSORTEXPRESSION;
        int _CreatedBy;
        DateTime _CreatedDate;
        int _LastUpdatedBy;
        DateTime _LastUpdatedDate;

        public int Lookup_Catg_ID
            {
            get
            { return _iLookup_Catg_ID; }
            set
            { _iLookup_Catg_ID = value; }
            }
        public int ApplicationID
            {
            get
            { return _iApplicationID; }
            set
            { _iApplicationID = value; }
            }
        public string Lookup_Catg_Name
            {
            get
            { return _sLookup_Catg_Name; }
            set
            { _sLookup_Catg_Name = value; }
            }
        public string Catg_Description
            {
            get
            { return _sCatg_Description; }
            set
            { _sCatg_Description = value; }
            }
        public string RefClause
            {
            get
            { return _sRefClause; }
            set
            { _sRefClause = value; }
            }
        public string FlexField1_Name
            {
            get
            { return _sFlexField1_Name; }
            set
            { _sFlexField1_Name = value; }
            }
        public string FlexField2_Name
            {
            get
            { return _sFlexField2_Name; }
            set
            { _sFlexField2_Name = value; }
            }
        public string FlexField3_Name
            {
            get
            { return _sFlexField3_Name; }
            set
            { _sFlexField3_Name = value; }
            }
        public string FlexField4_Name
            {
            get
            { return _sFlexField4_Name; }
            set
            { _sFlexField4_Name = value; }
            }
        public string FlexField5_Name
            {
            get
            { return _sFlexField5_Name; }
            set
            { _sFlexField5_Name = value; }
            }
        public string SORTEXPRESSION
            {
            get
            { return _sSORTEXPRESSION; }
            set
            { _sSORTEXPRESSION = value; }
            }
        public int CreatedBy
            {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
            }

        public DateTime CreatedDate
            {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
            }

        public int LastUpdatedBy
            {
            get { return _LastUpdatedBy; }
            set { _LastUpdatedBy = value; }
            }

        public DateTime LastUpdatedDate
            {
            get { return _LastUpdatedDate; }
            set { _LastUpdatedDate = value; }
            }
        }

    }
