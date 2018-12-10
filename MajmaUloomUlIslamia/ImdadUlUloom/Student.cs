using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajmaUloomUlIslamia
{
    class Student
    {
        private StudentDakhlaNumber studentDakhlaNumber;
        private StudentBasicInfo studentBasicInfo;
        private StudentDarjaRecord studentDarjaRecord;
        private StudentFormDate studentFormDate;
        private List<StudentGuardianInfo> studentGuardianInfo;
        private StudentKarachiAddress studentKarachiAddress;
        private StudentPermanentAddress studentPermanentAddress;
        private StudentQawaif studentQawaif;
        private StudentImdadi studentImdadi;

        public Student()
        {
            studentBasicInfo = new StudentBasicInfo();
            studentDakhlaNumber = new StudentDakhlaNumber();
            studentDarjaRecord = new StudentDarjaRecord();
            studentFormDate = new StudentFormDate();
            studentGuardianInfo = new List<StudentGuardianInfo>();
            studentKarachiAddress = new StudentKarachiAddress();
            studentPermanentAddress = new StudentPermanentAddress();
            studentQawaif = new StudentQawaif();
            studentImdadi = new StudentImdadi();

        }
        
        internal StudentDakhlaNumber StudentDakhlaNumber
        {
            get
            {
                return studentDakhlaNumber;
            }

            set
            {
                studentDakhlaNumber = value;
            }
        }

        internal StudentBasicInfo StudentBasicInfo
        {
            get
            {
                return studentBasicInfo;
            }

            set
            {
                studentBasicInfo = value;
            }
        }

        internal StudentDarjaRecord StudentDarjaRecord
        {
            get
            {
                return studentDarjaRecord;
            }

            set
            {
                studentDarjaRecord = value;
            }
        }

        internal StudentFormDate StudentFormDate
        {
            get
            {
                return studentFormDate;
            }

            set
            {
                studentFormDate = value;
            }
        }

        internal List<StudentGuardianInfo> StudentGuardianInfo
        {
            get
            {
                return studentGuardianInfo;
            }

            set
            {
                studentGuardianInfo = value;
            }
        }
        
        internal StudentKarachiAddress StudentKarachiAddress
        {
            get
            {
                return studentKarachiAddress;
            }

            set
            {
                studentKarachiAddress = value;
            }
        }

        internal StudentPermanentAddress StudentPermanentAddress
        {
            get
            {
                return studentPermanentAddress;
            }

            set
            {
                studentPermanentAddress = value;
            }
        }

        internal StudentQawaif StudentQawaif
        {
            get
            {
                return studentQawaif;
            }

            set
            {
                studentQawaif = value;
            }
        }

        internal StudentImdadi StudentImdadi
        {
            get
            {
                return studentImdadi;
            }

            set
            {
                studentImdadi = value;
            }
        }
        
        
    }
}
