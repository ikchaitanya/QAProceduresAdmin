using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jord.ACHEQA.Entities
{
    public class ProcedureNotes_Entity
    {
        int _iProcNotes_ID;
        int _iProc_ID;
        int _iParentID;
        string _sSerialNumber;
        string _sNotes;
        bool _bIsActive;
        int _CreatedBy;
        DateTime _CreatedDate;
        int _LastUpdatedBy;
        DateTime _LastUpdatedDate;
        int _iSequenceNumber;
        int _iSNO;
        int _iSeqNum;

        public int ProcNotes_ID
        {
            get
            { return _iProcNotes_ID; }
            set
            { _iProcNotes_ID = value; }
        }

        public int Proc_ID
        {
            get
            { return _iProc_ID; }
            set
            { _iProc_ID = value; }
        }

        public int ParentID
        {
            get
            { return _iParentID; }
            set
            { _iParentID = value; }
        }

        public string SerialNumber
        {
            get
            { return _sSerialNumber; }
            set
            { _sSerialNumber = value; }
        }

        public string Notes
        {
            get
            { return _sNotes; }
            set
            { _sNotes = value; }
        }

        public bool IsActive
        {
            get { return _bIsActive; }
            set { _bIsActive = value; }
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

        public int SequenceNumber
        {
            get
            { return _iSequenceNumber; }
            set
            { _iSequenceNumber = value; }
        }

        public int SNO
        {
            get
            { return _iSNO; }
            set
            { _iSNO = value; }
        }

        public int SeqNum
        {
            get
            { return _iSeqNum; }
            set
            { _iSeqNum = value; }
        }
    }
}
