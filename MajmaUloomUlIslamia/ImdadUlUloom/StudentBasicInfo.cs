using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajmaUloomUlIslamia
{
    class StudentBasicInfo
    {
        private String nameStudent;
        private String fatherNameStudent;
        private String surName;
        private DateTime dobStudent;
        private Byte[] imageStudent;

        public StudentBasicInfo() { }

        public StudentBasicInfo(string nameStudent, string fatherNameStudent, string surName, DateTime dobStudent, byte[] imageStudent)
        {
            this.nameStudent = nameStudent;
            this.fatherNameStudent = fatherNameStudent;
            this.surName = surName;
            this.dobStudent = dobStudent;
            this.imageStudent = imageStudent;
        }

        public string NameStudent
        {
            get
            {
                return nameStudent;
            }

            set
            {
                nameStudent = value;
            }
        }
        
        public string FatherNameStudent
        {
            get
            {
                return fatherNameStudent;
            }

            set
            {
                fatherNameStudent = value;
            }
        }

        public string SurName
        {
            get
            {
                return surName;
            }

            set
            {
                surName = value;
            }
        }

        public DateTime DobStudent
        {
            get
            {
                return dobStudent;
            }

            set
            {
                dobStudent = value;
            }
        }

        public byte[] ImageStudent
        {
            get
            {
                return imageStudent;
            }

            set
            {
                imageStudent = value;
            }
        }
    }
}
