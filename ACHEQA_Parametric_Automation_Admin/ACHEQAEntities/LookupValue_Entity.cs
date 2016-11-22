using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jord.ACHEQA.Entities
    {
 public    class LookupValue_Entity
        {
        int _iRow_ID;
        int _iLookup_Catg_ID;
        string _sValueText;
        string _sDisplayText;      
        string _sFlexField1_Name;
        string _sFlexField2_Name;
        string _sFlexField3_Name;
        string _sFlexField4_Name;
        string _sFlexField5_Name;
        int _CreatedBy;
        DateTime _CreatedDate;
        int _LastUpdatedBy;
        DateTime _LastUpdatedDate;
        bool _bIsActive;

        public int Row_ID
            {
            get
            { return _iRow_ID; }
            set
            { _iRow_ID = value; }
            }
        public int Lookup_Catg_ID
            {
            get
            { return _iLookup_Catg_ID; }
            set
            { _iLookup_Catg_ID = value; }
            }
        public string ValueText
            {
            get
            { return _sValueText; }
            set
            { _sValueText = value; }
            }
        public string DisplayText
            {
            get
            { return _sDisplayText; }
            set
            { _sDisplayText = value; }
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
        public bool IsActive
            {
            get { return _bIsActive; }
            set { _bIsActive = value; }
            }
        }
    }
