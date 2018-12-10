using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajmaUloomUlIslamia
{
    class StudentGuardianInfo
    {
        private int guardianInfoId;
        private int dakhlaNumber;
        private String cnicGuardian;
        private String nameGuardian;
        private String relationGuardian;
        private String contactGuardian;
        private Boolean isPrimary;


        public StudentGuardianInfo() { }

        public StudentGuardianInfo(int dakhlaNumber, string cnicGuardian, string nameGuardian, string relationGuardian, string contactGuardian, Boolean isPrimary)
        {
            this.dakhlaNumber = dakhlaNumber;
            this.cnicGuardian = cnicGuardian;
            this.nameGuardian = nameGuardian;
            this.relationGuardian = relationGuardian;
            this.contactGuardian = contactGuardian;
            this.isPrimary = isPrimary;
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

        public string CnicGuardian
        {
            get
            {
                return cnicGuardian;
            }

            set
            {
                cnicGuardian = value;
            }
        }

        public string NameGuardian
        {
            get
            {
                return nameGuardian;
            }

            set
            {
                nameGuardian = value;
            }
        }

        public string RelationGuardian
        {
            get
            {
                return relationGuardian;
            }

            set
            {
                relationGuardian = value;
            }
        }

        public string ContactGuardian
        {
            get
            {
                return contactGuardian;
            }

            set
            {
                contactGuardian = value;
            }
        }

        public bool IsPrimary
        {
            get
            {
                return isPrimary;
            }

            set
            {
                isPrimary = value;
            }
        }

        public int GuardianInfoId
        {
            get
            {
                return guardianInfoId;
            }

            set
            {
                guardianInfoId = value;
            }
        }
    }
}
