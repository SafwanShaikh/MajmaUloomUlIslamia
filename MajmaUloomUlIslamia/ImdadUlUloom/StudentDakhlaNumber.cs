using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajmaUloomUlIslamia
{
    class StudentDakhlaNumber
    {
        private int dakhlaNumber;
        private int formNumber;
        private Boolean activeIndex;

        public StudentDakhlaNumber(int dakhlaNumber, int formNumber, bool activeIndex)
        {
            this.dakhlaNumber = dakhlaNumber;
            this.formNumber = formNumber;
            this.activeIndex = activeIndex;
        }

        public StudentDakhlaNumber()
        {
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

        public int FormNumber
        {
            get
            {
                return formNumber;
            }

            set
            {
                formNumber = value;
            }
        }

        public bool ActiveIndex
        {
            get
            {
                return activeIndex;
            }

            set
            {
                activeIndex = value;
            }
        }
    }
}
