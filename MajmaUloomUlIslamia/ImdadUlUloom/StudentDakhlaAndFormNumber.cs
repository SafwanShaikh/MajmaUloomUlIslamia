using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajmaUloomUlIslamia
{
    class StudentDakhlaAndFormNumber
    {
        private static int dakhlaNumber;
        private static int formNumber;

        public static int DakhlaNumber
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

        public static int FormNumber
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
    }
}
