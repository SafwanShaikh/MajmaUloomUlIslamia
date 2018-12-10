using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajmaUloomUlIslamia
{
    class StudentDarjaRecord
    {
        private int dakhlaNumber;
        private String schoolDarja;
        private String quraniadarja;
        private String yearSchool;
        private String yearQurania;
        private Boolean activeInd;

        public StudentDarjaRecord(string schoolDarja, string quraniadarja, string yearSchool, string yearQurania, Boolean activeInd)
        {
            this.schoolDarja = schoolDarja;
            this.quraniadarja = quraniadarja;
            this.yearSchool = yearSchool;
            this.yearQurania = yearQurania;
            this.ActiveInd = activeInd;
        }

        public StudentDarjaRecord()
        {
        }

        public string SchoolDarja
        {
            get
            {
                return schoolDarja;
            }

            set
            {
                schoolDarja = value;
            }
        }

        public string Quraniadarja
        {
            get
            {
                return quraniadarja;
            }

            set
            {
                quraniadarja = value;
            }
        }

        public string YearSchool
        {
            get
            {
                return yearSchool;
            }

            set
            {
                yearSchool = value;
            }
        }

        public string YearQurania
        {
            get
            {
                return yearQurania;
            }

            set
            {
                yearQurania = value;
            }
        }

        public bool ActiveInd
        {
            get
            {
                return activeInd;
            }

            set
            {
                activeInd = value;
            }
        }

        public int DakhlaNumber
        {
            get
            {
                return dakhlaNumber;
            }

            set
            {
                dakhlaNumber = value;
            }
        }
    }
}
