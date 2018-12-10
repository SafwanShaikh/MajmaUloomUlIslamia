using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajmaUloomUlIslamia
{
    class StudentQawaif
    {
        private string qurania;
        private String lastQuraniaIdara;
        private String lastAsriTaleemIdara;
        private String asriTaleem;

        public StudentQawaif(string qurania, string lastQuraniaIdara, string lastAsriTaleemIdara, string asriTaleem)
        {
            this.qurania = qurania;
            this.lastQuraniaIdara = lastQuraniaIdara;
            this.lastAsriTaleemIdara = lastAsriTaleemIdara;
            this.asriTaleem = asriTaleem;
        }

        public StudentQawaif()
        {
        }

        public string Qurania
        {
            get
            {
                return qurania;
            }

            set
            {
                qurania = value;
            }
        }

        public string LastQuraniaIdara
        {
            get
            {
                return lastQuraniaIdara;
            }

            set
            {
                lastQuraniaIdara = value;
            }
        }

        public string LastAsriTaleemIdara
        {
            get
            {
                return lastAsriTaleemIdara;
            }

            set
            {
                lastAsriTaleemIdara = value;
            }
        }

        public string AsriTaleem
        {
            get
            {
                return asriTaleem;
            }

            set
            {
                asriTaleem = value;
            }
        }
    }
}
