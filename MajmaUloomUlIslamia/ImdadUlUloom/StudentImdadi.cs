using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajmaUloomUlIslamia
{
    class StudentImdadi
    {
        private Boolean imdadi;

        public StudentImdadi() { }

        public bool Imdadi
        {
            get
            {
                return imdadi;
            }

            set
            {
                imdadi = value;
            }
        }
        
        
        public StudentImdadi(bool imdadi)
        {
            this.Imdadi = imdadi;
        }
    }
}
