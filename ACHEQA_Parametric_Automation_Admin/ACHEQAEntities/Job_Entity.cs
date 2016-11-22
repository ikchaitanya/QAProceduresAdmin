using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jord.ACHEQA.Entities
    {
   public  class Job_Entity
        {
        int _iJobID;
        string _sJobNumber;
        string _sProject;
        string _sCustomer;
        int _CreatedBy;
        DateTime _CreatedDate;
        int _LastUpdatedBy;
        DateTime _LastUpdatedDate;

        public int JobID
            {
            get
            { return _iJobID; }
            set
            { _iJobID = value; }
            }
        public string JobNumber
            {
            get
            { return _sJobNumber; }
            set
            { _sJobNumber = value; }
            }
        public string Project
            {
            get
            { return _sProject; }
            set
            { _sProject = value; }
            }
        public string Customer
            {
            get
            { return _sCustomer; }
            set
            { _sCustomer = value; }
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
