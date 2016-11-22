using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jord.ACHEQA.Entities
    {
    public class InputVariable_Entity
        {
        int _iVarID;
        int _iLookupCatID;
        string  _iProcInitial;
        string _iLookupCatName;
        string _sVariableName;
        string _sDisplayName;
        string _sControlType;
        int _sSeqNo;
        int _CreatedBy;
        DateTime _CreatedDate;
        int _LastUpdatedBy;
        DateTime _LastUpdatedDate;
        bool _bIsActive;
        bool _bIsRequried;


        public int VarID
            {
            get
            { return _iVarID; }
            set
            { _iVarID = value; }
            }
        public int LookupCatID
            {
            get
            { return _iLookupCatID; }
            set
            { _iLookupCatID = value; }
            }
        public string ProcInitial
            {
            get
            { return _iProcInitial; }
            set
            { _iProcInitial = value; }
            }
        public string LookupCatName
            {
            get
            { return _iLookupCatName; }
            set
            { _iLookupCatName = value; }
            }
        public string VariableName
            {
            get
            { return _sVariableName; }
            set
            { _sVariableName = value; }
            }
        public string DisplayName
            {
            get
            { return _sDisplayName; }
            set
            { _sDisplayName = value; }
            }
        public string ControlType
            {
            get
            { return _sControlType; }
            set
            { _sControlType = value; }
            }
        public int SeqNo
            {
            get
            { return _sSeqNo; }
            set
            { _sSeqNo = value; }
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
        public bool IsRequried
            {
            get { return _bIsRequried; }
            set { _bIsRequried = value; }
            }
        }
    }
