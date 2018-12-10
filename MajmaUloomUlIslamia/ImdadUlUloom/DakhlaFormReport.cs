using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MajmaUloomUlIslamia
{
    public partial class DakhlaFormReport : Form
    {
        private Student student;

        public DakhlaFormReport()
        {
            InitializeComponent();
        }

        internal Student Student
        {
            get
            {
                return student;
            }
            set
            {
                student = value;
            }
        }

        private void DakhlaFormReport_Load(object sender, EventArgs e)
        {
            DakhlaFormReportCard rpt = new DakhlaFormReportCard();
            TextObject text;

            text = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["regNumBox"];
            text.Text = student.StudentDakhlaNumber.DakhlaNumber.ToString();
            text = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["nameBox"];
            text.Text = student.StudentBasicInfo.NameStudent.ToString();
            text = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["fnameBox"];
            text.Text = student.StudentBasicInfo.FatherNameStudent.ToString();
            text = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["surNameBox"];
            text.Text = student.StudentBasicInfo.SurName.ToString();
            text = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["dobBox"];
            text.Text = student.StudentBasicInfo.DobStudent.Day.ToString() + "-" + student.StudentBasicInfo.DobStudent.Month.ToString() + "-" + student.StudentBasicInfo.DobStudent.Year.ToString();
            text = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["schoolDarjaBox"];
            text.Text = student.StudentDarjaRecord.SchoolDarja;
            text = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["quraniaDarjaBox"];
            text.Text = student.StudentDarjaRecord.Quraniadarja;
            
            text = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["zilaBox"];
            text.Text = student.StudentPermanentAddress.Zila.ToString();
            text = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["tehseelBox"];
            text.Text = student.StudentPermanentAddress.Tehseel.ToString();
            text = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["dakKhanaBox"];
            text.Text = student.StudentPermanentAddress.DakKhana.ToString();
            text = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["villageBox"];
            text.Text = student.StudentPermanentAddress.Village.ToString();
            text = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["houseBox"];
            text.Text = student.StudentKarachiAddress.HouseNumber.ToString();
            text = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["sectorBox"];
            text.Text = student.StudentKarachiAddress.SectorNumber.ToString();
            text = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["galiBox"];
            text.Text = student.StudentKarachiAddress.BlockNumber.ToString();
            text = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["areaBox"];
            text.Text = student.StudentKarachiAddress.Area.ToString();
            
            text = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["nameGBox"];
            text.Text = student.StudentGuardianInfo[0].NameGuardian.ToString();
            text = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["contactGBox"];
            text.Text = student.StudentGuardianInfo[0].ContactGuardian.ToString();
            text = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["cnicGBox"];
            text.Text = student.StudentGuardianInfo[0].CnicGuardian.ToString();
            text = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["relationGBox"];
            text.Text = student.StudentGuardianInfo[0].RelationGuardian.ToString();
            text = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["previousQurania"];
            text.Text = student.StudentQawaif.Qurania;
            text = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["lastIdaraQurania"];
            text.Text = student.StudentQawaif.LastQuraniaIdara;
            text = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["previousAsriTaleem"];
            text.Text = student.StudentQawaif.AsriTaleem;
            text = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["lastAsriTaleemIdara"];
            text.Text = student.StudentQawaif.LastAsriTaleemIdara;

            text = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["imdadiBox"];
            text.Text = student.StudentImdadi.Imdadi == true ? "ہاں" : "نہیں";
            
            text = (TextObject)rpt.ReportDefinition.Sections["Section2"].ReportObjects["takmeelBox"];
            text.Text = student.StudentFormDate.TakmeelDakhlaDate.ToString();
            crystalReportViewer1.ReportSource = rpt;
        }
        
    }
}