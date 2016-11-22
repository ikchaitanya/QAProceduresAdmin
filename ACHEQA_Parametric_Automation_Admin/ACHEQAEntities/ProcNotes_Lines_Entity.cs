using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jord.ACHEQA.Entities
{
    public class ProcNotes_Lines_Entity
    {
        int _iProcNotes_Line_ID;
        int _iProcNotes_ID;
        int _iLineNumber;
        string _sNotes_Type;
        string _sNotes;
        byte[] _bNotes_Binary;
        bool _bIsActive;
        int _CreatedBy;
        DateTime _CreatedDate;
        int _LastUpdatedBy;
        DateTime _LastUpdatedDate;

        public int ProcNotes_Line_ID
        {
            get
            { return _iProcNotes_Line_ID; }
            set
            { _iProcNotes_Line_ID = value; }
        }

        public int ProcNotes_ID
        {
            get
            { return _iProcNotes_ID; }
            set
            { _iProcNotes_ID = value; }
        }

        public int LineNumber
        {
            get
            { return _iLineNumber; }
            set
            { _iLineNumber = value; }
        }

        public string Notes_Type
        {
            get
            { return _sNotes_Type; }
            set
            { _sNotes_Type = value; }
        }

        public string Notes
        {
            get
            { return _sNotes; }
            set
            { _sNotes = value; }
        }

        public byte[] Notes_Binary
        {
            get
            { return _bNotes_Binary; }
            set
            { _bNotes_Binary = value; }
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
    }
}
