using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Drawing;


namespace MajmaUloomUlIslamia
{
    public partial class LandingPage : Form
    {
        private Student[] activeStudentList;
        private Student[] inActiveStudentList;
        //private Dictionary<int, Student> sameRegistrationNumberStudentsList = new Dictionary<int, Student>();
        private String fileName;

        public LandingPage()
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            activeStudentList = DataManipulation.getAllStudents(true).ToArray();
            inActiveStudentList = DataManipulation.getAllStudents(false).ToArray();
            fileName = null;
            editStudentButton.Enabled = false;
            deleteStudentButton.Enabled = false;
            printCardButton.Enabled = false;
            exportGridView.Enabled = false;
            Cursor.Current = Cursors.Default;
        }

        private void mainTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(mainTab.SelectedTab == mainTab.TabPages["addNewStudentTab"])
            {
                Cursor.Current = Cursors.WaitCursor;

                fillZilaComboBox();
                fillTehseelComboBox();
                fillDakKhanaComboBox();
                fillVillageComboBox();
                fillAreaComboBox();
                fillSectorComboBox();

                DataManipulation.getFormAndDakhlaNumber();
                formNumberLabel.Text = StudentDakhlaAndFormNumber.FormNumber.ToString();
                registrationNumberLabel.Text = StudentDakhlaAndFormNumber.DakhlaNumber.ToString();
                Cursor.Current = Cursors.Default;
            }
            else if(mainTab.SelectedTab == mainTab.TabPages["addPreviousStudentTab"])
            {
                //Cursor.Current = Cursors.WaitCursor;
                //DataManipulation.getNewDakhlaNumber();
                //DataManipulation.getNewFormNumber();
                //newFormNumberLabel.Text = StudentRegAndDakhlaNumber.FormNumber.ToString();
                //newDakhlaNumberLabel.Text = StudentRegAndDakhlaNumber.DakhlaNumber.ToString();
                //Cursor.Current = Cursors.Default;
            }
            else if(mainTab.SelectedTab == mainTab.TabPages["ReceiptBook"])
            {
                Cursor.Current = Cursors.WaitCursor;
                bookLists.DataSource = DataManipulation.getAllReceiptBooks();
                List<string> activeBookInfo = DataManipulation.getActiveReceiptBook();
                activeBook.Text = activeBookInfo[0];
                firstSlipInfoTextbox.Text = activeBookInfo[1];
                lastSlipInfoTextbox.Text = activeBookInfo[2];
                lastSlipUsedInfoTextbox.Text = activeBookInfo[3];
                Cursor.Current = Cursors.Default;
            }
        }

        private void LandingPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        //      Save Student Tab
        
        private void saveButton_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(nameStudentTextbox.Text) || String.IsNullOrEmpty(fatherNameStudentTextbox.Text) ||
                String.IsNullOrEmpty(takmeelDateCombobox.Text) ||
                String.IsNullOrEmpty(takmeelMonthCombobox.Text) || String.IsNullOrEmpty(takmeelYearCombobox.Text))
            {
                if (String.IsNullOrEmpty(nameStudentTextbox.Text))
                {
                    errorProvider.SetError(nameStudentTextbox, "طالبعلم کا نام ضروری ہے۔");
                }

                if (String.IsNullOrEmpty(fatherNameStudentTextbox.Text))
                {
                    errorProvider.SetError(fatherNameStudentTextbox, "والد کا نام ضروری ہے۔");
                }
                
                if (String.IsNullOrEmpty(takmeelDateCombobox.Text) || String.IsNullOrEmpty(takmeelMonthCombobox.Text) ||
                    String.IsNullOrEmpty(takmeelYearCombobox.Text))
                {
                    errorProvider.SetError(takmeelDateCombobox, "تاریخ تکمیل ضروری ہے۔");
                }
            }
            else
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    Student newStudent = getStudentFromForm();
                    DataManipulation.addStudent(newStudent, false);

                    DakhlaCardReport rpt = new DakhlaCardReport();
                    rpt.Student = newStudent;

                    LandingPage newPage = new LandingPage();
                    this.Hide();
                    newPage.Show();
                    rpt.Show();
                    Cursor.Current = Cursors.Default;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Cursor.Current = Cursors.Default;
                }
            }
            
        }

        private Student getStudentFromForm()
        {
            Student newStudent = new Student();

            try
            {
                newStudent.StudentDakhlaNumber.DakhlaNumber = Convert.ToInt32(registrationNumberLabel.Text);
                newStudent.StudentDakhlaNumber.FormNumber = Convert.ToInt32(formNumberLabel.Text);
                newStudent.StudentDakhlaNumber.ActiveIndex = true;
                
                newStudent.StudentBasicInfo.NameStudent = nameStudentTextbox.Text;
                newStudent.StudentBasicInfo.FatherNameStudent = fatherNameStudentTextbox.Text;
                newStudent.StudentBasicInfo.SurName = surNameStudentTextbox.Text;
                newStudent.StudentBasicInfo.DobStudent = dobStudentDatetimepicker.Value;
                if(!imageLocationLabel.Text.Equals("Location"))
                {
                    FileStream fs = new FileStream(imageLocationLabel.Text, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    newStudent.StudentBasicInfo.ImageStudent = br.ReadBytes((int)fs.Length);
                }
                else
                {
                    newStudent.StudentBasicInfo.ImageStudent = null;
                }

                String takmeelDate = takmeelYearCombobox.Text+"-"+takmeelMonthCombobox.Text+"-"+takmeelDateCombobox.Text;
                String ikhrajDate = ikhrajYearCombobox.Text + "-" + ikhrajMonthCombobox.Text + "-" + ikhrajDateCombobox.Text;

                newStudent.StudentFormDate.IkhrajDate = ikhrajDate;
                newStudent.StudentFormDate.TakmeelDakhlaDate = takmeelDate;

                newStudent.StudentDarjaRecord.Quraniadarja = quraniaDarjaStudentCombobox.Text;
                newStudent.StudentDarjaRecord.SchoolDarja = schoolDarjaStudentCombobox.Text;
                newStudent.StudentDarjaRecord.YearQurania = takmeelYearCombobox.Text;
                newStudent.StudentDarjaRecord.YearSchool = takmeelYearCombobox.Text;
                newStudent.StudentDarjaRecord.ActiveInd = true;

                StudentGuardianInfo studentGuardianInfo = new StudentGuardianInfo();

                studentGuardianInfo.DakhlaNumber = newStudent.StudentDakhlaNumber.DakhlaNumber;
                studentGuardianInfo.NameGuardian = nameGuardianTextbox.Text;
                studentGuardianInfo.RelationGuardian = relationGuardianTextbox.Text;
                studentGuardianInfo.CnicGuardian = cnicGuardianTextbox.Text;
                studentGuardianInfo.ContactGuardian = contactGuardianTextbox.Text;

                newStudent.StudentGuardianInfo.Add(studentGuardianInfo);

                newStudent.StudentPermanentAddress.Zila = zilaCombobox.Text;
                newStudent.StudentPermanentAddress.Tehseel = tehseelCombobox.Text;
                newStudent.StudentPermanentAddress.DakKhana = dakKhanaCombobox.Text;
                newStudent.StudentPermanentAddress.Village = villageCombobox.Text;

                newStudent.StudentKarachiAddress.HouseNumber = houseNumberTextbox.Text;
                newStudent.StudentKarachiAddress.SectorNumber = sectorNumberCombobox.Text;
                newStudent.StudentKarachiAddress.BlockNumber = blockNumberTextbox.Text;
                newStudent.StudentKarachiAddress.Area = areaCombobox.Text;

                newStudent.StudentImdadi.Imdadi = imdadiCheckbox.Checked;
                
                newStudent.StudentQawaif.Qurania = quraniaCombobox.Text;
                newStudent.StudentQawaif.LastQuraniaIdara = lastIdaraQuraniaTextbox.Text;
                newStudent.StudentQawaif.AsriTaleem = asriTaleemCombobox.Text;
                newStudent.StudentQawaif.LastAsriTaleemIdara = lastIdaraSchoolTextbox.Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return newStudent;
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileOpen = new OpenFileDialog();

            fileOpen.Title = "Open Image file";
            fileOpen.Filter = "JPG Files (*.jpg)| *.jpg";

            if (fileOpen.ShowDialog() == DialogResult.OK)
            {
                imageLocationLabel.Text = fileOpen.FileName.ToString();
                pictureStudentPicturebox.ImageLocation = fileOpen.FileName.ToString();
            }
            fileOpen.Dispose();
        }
        
        private void fillZilaComboBox()
        {
            List<string> zilaAll = new List<string>();
            for (int i = 0; i < activeStudentList.Length; i++)
            {
                zilaAll.Add(activeStudentList[i].StudentPermanentAddress.Zila);
            }
            for (int i = 0; i < inActiveStudentList.Length; i++)
            {
                zilaAll.Add(inActiveStudentList[i].StudentPermanentAddress.Zila);
            }
            var zilaDistinct = zilaAll.Distinct().ToArray();
            foreach (var item in zilaDistinct)
            {
                zilaCombobox.Items.Add(item);
            }
        }

        private void fillTehseelComboBox()
        {
            List<string> TehseelAll = new List<string>();
            for (int i = 0; i < activeStudentList.Length; i++)
            {
                TehseelAll.Add(activeStudentList[i].StudentPermanentAddress.Tehseel);
            }
            for (int i = 0; i < inActiveStudentList.Length; i++)
            {
                TehseelAll.Add(inActiveStudentList[i].StudentPermanentAddress.Tehseel);
            }
            var TehseelDistinct = TehseelAll.Distinct().ToArray();
            foreach (var item in TehseelDistinct)
            {
                tehseelCombobox.Items.Add(item);
            }
        }

        private void fillDakKhanaComboBox()
        {
            List<string> dakKhanaAll = new List<string>();
            for (int i = 0; i < activeStudentList.Length; i++)
            {
                dakKhanaAll.Add(activeStudentList[i].StudentPermanentAddress.DakKhana);
            }
            for (int i = 0; i < inActiveStudentList.Length; i++)
            {
                dakKhanaAll.Add(inActiveStudentList[i].StudentPermanentAddress.DakKhana);
            }
            var dakKhanaDistinct = dakKhanaAll.Distinct().ToArray();
            foreach (var item in dakKhanaDistinct)
            {
                dakKhanaCombobox.Items.Add(item);
            }
        }

        private void fillVillageComboBox()
        {
            List<string> villageAll = new List<string>();
            for (int i = 0; i < activeStudentList.Length; i++)
            {
                villageAll.Add(activeStudentList[i].StudentPermanentAddress.Village);
            }
            for (int i = 0; i < inActiveStudentList.Length; i++)
            {
                villageAll.Add(inActiveStudentList[i].StudentPermanentAddress.Village);
            }
            var villageDistinct = villageAll.Distinct().ToArray();
            foreach (var item in villageDistinct)
            {
                villageCombobox.Items.Add(item);
            }
        }

        private void fillSectorComboBox()
        {
            List<string> sectorAll = new List<string>();
            for (int i = 0; i < activeStudentList.Length; i++)
            {
                sectorAll.Add(activeStudentList[i].StudentKarachiAddress.SectorNumber);
            }
            for (int i = 0; i < inActiveStudentList.Length; i++)
            {
                sectorAll.Add(inActiveStudentList[i].StudentKarachiAddress.SectorNumber);
            }
            var sectorDistinct = sectorAll.Distinct().ToArray();
            foreach (var item in sectorDistinct)
            {
                sectorNumberCombobox.Items.Add(item);
            }
        }

        private void fillAreaComboBox()
        {
            List<string> areaAll = new List<string>();
            for (int i = 0; i < activeStudentList.Length; i++)
            {
                areaAll.Add(activeStudentList[i].StudentKarachiAddress.Area);
            }
            for (int i = 0; i < inActiveStudentList.Length; i++)
            {
                areaAll.Add(inActiveStudentList[i].StudentKarachiAddress.Area);
            }
            var areaDistinct = areaAll.Distinct().ToArray();
            foreach (var item in areaDistinct)
            {
                areaCombobox.Items.Add(item);
            }
        }

        //      Search Student Tab

        private void searchStudentButton_Click(object sender, EventArgs e)
        {
            editStudentButton.Enabled = true;
            deleteStudentButton.Enabled = true;
            printCardButton.Enabled = true;
            exportGridView.Enabled = true;
            try
            {
                string search = searchTextbox.Text;
                List<int> searchDakhlaNumbers = new List<int>();
                studentGridView.Rows.Clear();
                String classOfStudent = getClassOfStudent();

                if (searchCombobox.Text.Equals("رجسٹریشن نمبر"))
                {
                    searchDakhlaNumbers.Add(Convert.ToInt32(search));
                    if (!previousStudent.Checked)
                    {
                        fillGridView(searchDakhlaNumbers, true);
                    }
                    else
                    {
                        fillGridView(searchDakhlaNumbers, false);
                    }

                }
                else if (searchCombobox.Text.Equals("نام"))
                {
                    searchDakhlaNumbers = getDakhlaNumbersOfName(search, classOfStudent);
                    if (!previousStudent.Checked)
                    {
                        fillGridView(searchDakhlaNumbers, true);
                    }
                    else
                    {
                        fillGridView(searchDakhlaNumbers, false);
                    }

                }
                else if (searchCombobox.Text.Equals("والد کا نام"))
                {
                    searchDakhlaNumbers = getDakhlaNumbersOfStudentFatherName(search);
                    if (!previousStudent.Checked)
                    {
                        fillGridView(searchDakhlaNumbers, true);
                    }
                    else
                    {
                        fillGridView(searchDakhlaNumbers, false);
                    }
                }
                else if (searchCombobox.Text.Equals("امدادی") || searchCombobox.Text.Equals("غیر امدادی"))
                {
                    if (searchCombobox.Text.Equals("امدادی"))
                    {
                        searchDakhlaNumbers = getDakhlaNumbersOfImdadi(true, classOfStudent);
                        fileName = "امدادی.pdf";
                    }
                    else if (searchCombobox.Text.Equals("غیر امدادی"))
                    {
                        searchDakhlaNumbers = getDakhlaNumbersOfImdadi(false, classOfStudent);
                        fileName = "غیر امدادی.pdf";
                    }

                    if (!previousStudent.Checked)
                    {
                        fillGridView(searchDakhlaNumbers, true);
                    }
                    else
                    {
                        fillGridView(searchDakhlaNumbers, false);
                    }
                }
                else if (searchCombobox.Text.Equals("سال"))
                {
                    searchDakhlaNumbers = getDakhlaNumbersOfYear(search);
                    fileName = "سال.pdf";
                    if (!previousStudent.Checked)
                    {
                        fillGridView(searchDakhlaNumbers, true);
                    }
                    else
                    {
                        fillGridView(searchDakhlaNumbers, false);
                    }
                }
                else if (searchCombobox.SelectedItem == null && String.IsNullOrEmpty(classOfStudent))
                {
                    searchDakhlaNumbers = getDakhlaNumbersOfAllStudents();
                    if (!previousStudent.Checked)
                    {
                        fillGridView(searchDakhlaNumbers, true);
                    }
                    else
                    {
                        fillGridView(searchDakhlaNumbers, false);
                    }
                    fileName = "تمام طلبہ.pdf";
                }
                else if (!String.IsNullOrEmpty(classOfStudent))
                {
                    searchDakhlaNumbers = getDakhlaNumbersOfStudentsByClass(classOfStudent);
                    if (!previousStudent.Checked)
                    {
                        fillGridView(searchDakhlaNumbers, true);
                    }
                    else
                    {
                        fillGridView(searchDakhlaNumbers, false);
                    }
                    fileName = classOfStudent + ".pdf";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("درست ڈیٹا درج کیجئے۔");
            }
        }

        private void fillGridView(List<int> dakhlaNumber, Boolean active)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                List<Student> tempStudent = new List<Student>();
                if (active)
                {
                    for (int i = 0; i < dakhlaNumber.Count; i++)
                    {
                        for (int j = 0; j < activeStudentList.Length; j++)
                        {
                            if (dakhlaNumber[i] == activeStudentList[j].StudentDakhlaNumber.DakhlaNumber)
                            {
                                tempStudent.Add(activeStudentList[j]);
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < dakhlaNumber.Count; i++)
                    {
                        for (int j = 0; j < inActiveStudentList.Length; j++)
                        {
                            if (dakhlaNumber[i] == inActiveStudentList[j].StudentDakhlaNumber.DakhlaNumber)
                            {
                                tempStudent.Add(inActiveStudentList[j]);
                            }
                        }
                    }
                }


                studentGridView.Rows.Add(tempStudent.Count);

                for (int row = 0; row < tempStudent.Count; row++)
                {
                    Student fillStudent = tempStudent[row];
                    studentGridView.Rows[row].Cells[1].Value = fillStudent.StudentDakhlaNumber.DakhlaNumber;
                    studentGridView.Rows[row].Cells[2].Value = fillStudent.StudentBasicInfo.NameStudent.ToString();
                    studentGridView.Rows[row].Cells[3].Value = fillStudent.StudentBasicInfo.FatherNameStudent.ToString();
                    studentGridView.Rows[row].Cells[4].Value = fillStudent.StudentDarjaRecord.SchoolDarja;
                    studentGridView.Rows[row].Cells[5].Value = fillStudent.StudentDarjaRecord.Quraniadarja;
                    studentGridView.Rows[row].Cells[6].Value = fillStudent.StudentFormDate.TakmeelDakhlaDate.ToString();
                    foreach(StudentGuardianInfo studentGuardianInfo in fillStudent.StudentGuardianInfo){
                        if(studentGuardianInfo.IsPrimary == true)
                        {
                            studentGridView.Rows[row].Cells[7].Value = studentGuardianInfo.NameGuardian;
                            studentGridView.Rows[row].Cells[8].Value = studentGuardianInfo.ContactGuardian;
                        }
                    }
                    studentGridView.Rows[row].Cells[9].Value = fillStudent.StudentPermanentAddress.Village.ToString();
                    studentGridView.Rows[row].Cells[10].Value = fillStudent.StudentKarachiAddress.Area.ToString();
                    studentGridView.Rows[row].Cells[11].Value = fillStudent.StudentImdadi.Imdadi.ToString();
                }
                studentGridView.Sort(studentGridView.Columns["registrationNumber"], ListSortDirection.Ascending);

                for (int row = 0; row < studentGridView.RowCount; row++)
                {
                    studentGridView.Rows[row].Cells[0].Value = row + 1;
                }
                Cursor.Current = Cursors.Default;
            }
            catch
            {
                MessageBox.Show("ڈیٹا موجود نہیں۔");
                searchTextbox.Clear();
                Cursor.Current = Cursors.Default;
            }

        }

        private String getClassOfStudent()
        {
            String studentClass = "";

            if (class1Radio.Checked == true)
            {
                studentClass = "اول";
            }
            else if (class2Radio.Checked == true)
            {
                studentClass = "دوئم";
            }
            else if (class3Radio.Checked == true)
            {
                studentClass = "سوئم";
            }
            else if (class4Radio.Checked == true)
            {
                studentClass = "چہارم";
            }
            else if (class5Radio.Checked == true)
            {
                studentClass = "پنجم";
            }
            else if (class6Radio.Checked == true)
            {
                studentClass = "ششم";
            }
            else if (class7Radio.Checked == true)
            {
                studentClass = "ہفتم";
            }
            else if (class8Radio.Checked == true)
            {
                studentClass = "ہشتم";
            }
            else if (class9Radio.Checked == true)
            {
                studentClass = "نہم";
            }
            else if (class10Radio.Checked == true)
            {
                studentClass = "دہم";
            }
            else if (class11Radio.Checked == true)
            {
                studentClass = "روضہ ب";
            }
            else if (class12Radio.Checked == true)
            {
                studentClass = "روضہ ج";
            }
            else if (class13Radio.Checked == true)
            {
                studentClass = "نرسری";
            }
            else if (class14Radio.Checked == true)
            {
                studentClass = "کےجی ون";
            }
            else if (class15Radio.Checked == true)
            {
                studentClass = "کےجی ٹو";
            }
            else if (classQaidaRadio.Checked == true)
            {
                studentClass = "قاعدہ";
            }
            else if (classNaziraRadio.Checked == true)
            {
                studentClass = "ناظرہ";
            }
            else if (classHifzRadio.Checked == true)
            {
                studentClass = "حفظ";
            }

            return studentClass;
        }

        private List<int> getDakhlaNumbersOfName(string name, String classOfStudent)
        {
            List<int> dakhlaNumbers = new List<int>();
            if (!previousStudent.Checked)
            {
                for (int i = 0; i < activeStudentList.Length; i++)
                {
                    if (activeStudentList[i].StudentBasicInfo.NameStudent.Contains(name))
                    {
                        dakhlaNumbers.Add(activeStudentList[i].StudentDakhlaNumber.DakhlaNumber);
                    }
                }
            }
            else
            {
                for (int i = 0; i < inActiveStudentList.Length; i++)
                {
                    if (inActiveStudentList[i].StudentBasicInfo.NameStudent.Contains(name))
                    {
                        dakhlaNumbers.Add(inActiveStudentList[i].StudentDakhlaNumber.DakhlaNumber);
                    }
                }
            }
            return dakhlaNumbers;
        }

        private List<int> getDakhlaNumbersOfStudentFatherName(string fatherName)
        {
            List<int> dakhlaNumbers = new List<int>();
            if (!previousStudent.Checked)
            {
                for (int i = 0; i < activeStudentList.Length; i++)
                {
                    if (activeStudentList[i].StudentBasicInfo.FatherNameStudent.Contains(fatherName))
                    {
                        dakhlaNumbers.Add(activeStudentList[i].StudentDakhlaNumber.DakhlaNumber);
                    }
                }
            }
            else
            {
                for (int i = 0; i < inActiveStudentList.Length; i++)
                {
                    if (inActiveStudentList[i].StudentBasicInfo.FatherNameStudent.Contains(fatherName))
                    {
                        dakhlaNumbers.Add(inActiveStudentList[i].StudentDakhlaNumber.DakhlaNumber);
                    }
                }
            }

            return dakhlaNumbers;
        }

        private List<int> getDakhlaNumbersOfYear(string year)
        {
            List<int> dakhlaNumbers = new List<int>();
            if (!previousStudent.Checked)
            {
                for (int i = 0; i < activeStudentList.Length; i++)
                {
                    string[] date = activeStudentList[i].StudentFormDate.TakmeelDakhlaDate.Split('-');
                    if (date[0].Equals(year))
                    {
                        dakhlaNumbers.Add(activeStudentList[i].StudentDakhlaNumber.DakhlaNumber);
                    }
                }
            }
            else
            {
                for (int i = 0; i < inActiveStudentList.Length; i++)
                {
                    string[] date = activeStudentList[i].StudentFormDate.TakmeelDakhlaDate.Split('-');
                    if (date[2].Equals(year))
                    {
                        dakhlaNumbers.Add(inActiveStudentList[i].StudentDakhlaNumber.DakhlaNumber);
                    }
                }
            }
            return dakhlaNumbers;
        }

        private List<int> getDakhlaNumbersOfImdadi(Boolean imdadi, string classOfStudent)
        {
            List<int> regNumbers = new List<int>();
            if (imdadi)
            {
                if (!previousStudent.Checked)
                {
                    for (int i = 0; i < activeStudentList.Length; i++)
                    {
                        if (activeStudentList[i].StudentImdadi.Imdadi)
                        {
                            regNumbers.Add(activeStudentList[i].StudentDakhlaNumber.DakhlaNumber);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < inActiveStudentList.Length; i++)
                    {
                        if (inActiveStudentList[i].StudentImdadi.Imdadi)
                        {
                            regNumbers.Add(inActiveStudentList[i].StudentDakhlaNumber.DakhlaNumber);
                        }
                    }
                }

            }
            else if (!imdadi)
            {
                if (!previousStudent.Checked)
                {
                    for (int i = 0; i < activeStudentList.Length; i++)
                    {
                        if (!activeStudentList[i].StudentImdadi.Imdadi)
                        {
                            regNumbers.Add(activeStudentList[i].StudentDakhlaNumber.DakhlaNumber);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < inActiveStudentList.Length; i++)
                    {
                        if (!inActiveStudentList[i].StudentImdadi.Imdadi)
                        {
                            regNumbers.Add(inActiveStudentList[i].StudentDakhlaNumber.DakhlaNumber);
                        }
                    }
                }

            }
            return regNumbers;
        }

        private List<int> getDakhlaNumbersOfAllStudents()
        {
            List<int> dakhlaNumbers = new List<int>();
            if (!previousStudent.Checked)
            {
                for (int i = 0; i < activeStudentList.Length; i++)
                {
                    dakhlaNumbers.Add(activeStudentList[i].StudentDakhlaNumber.DakhlaNumber);
                }
            }
            else
            {
                for (int i = 0; i < inActiveStudentList.Length; i++)
                {
                    dakhlaNumbers.Add(inActiveStudentList[i].StudentDakhlaNumber.DakhlaNumber);
                }
            }

            return dakhlaNumbers;
        }

        private List<int> getDakhlaNumbersOfStudentsByClass(string classOfStudent)
        {
            List<int> dakhlaNumbers = new List<int>();
            if (!previousStudent.Checked)
            {
                for (int i = 0; i < activeStudentList.Length; i++)
                {
                    if (activeStudentList[i].StudentDarjaRecord.SchoolDarja.Equals(classOfStudent) ||
                        activeStudentList[i].StudentDarjaRecord.Quraniadarja.Equals(classOfStudent))
                    {
                        dakhlaNumbers.Add(activeStudentList[i].StudentDakhlaNumber.DakhlaNumber);
                    }
                }
            }
            else
            {
                for (int i = 0; i < inActiveStudentList.Length; i++)
                {
                    if (activeStudentList[i].StudentDarjaRecord.SchoolDarja.Equals(classOfStudent) ||
                        activeStudentList[i].StudentDarjaRecord.Quraniadarja.Equals(classOfStudent))
                    {
                        dakhlaNumbers.Add(inActiveStudentList[i].StudentDakhlaNumber.DakhlaNumber);
                    }
                }
            }

            return dakhlaNumbers;
        }

        private void editStudentButton_Click(object sender, EventArgs e)
        {
            if (studentGridView.SelectedRows.Count == 1)
            {
                Cursor.Current = Cursors.WaitCursor;
                int dakhlaNumber = Convert.ToInt32(studentGridView.SelectedRows[0].Cells[1].Value);
                foreach (var item in activeStudentList)
                {
                    if (item.StudentDakhlaNumber.DakhlaNumber == dakhlaNumber)
                    {
                        editStudentPage newPage = new editStudentPage();
                        newPage.UpdateStudent = item;
                        this.Hide();
                        this.Dispose();
                        newPage.Show();

                        break;
                    }
                }
                Cursor.Current = Cursors.Default;

            }
            else
            {
                MessageBox.Show("ایک طالبعلم کا ڈیٹا سلیکٹ کیجئے۔");
            }
        }

        private void deleteStudentButton_Click(object sender, EventArgs e)
        {
            List<string> dakhlaNumbers = new List<string>();
            foreach (DataGridViewRow row in studentGridView.SelectedRows)
            {
                dakhlaNumbers.Add(row.Cells[1].Value.ToString());
            }

            DialogResult confirm = MessageBox.Show("Are you sure, You want to delete students?", "Delete Student", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                DataManipulation.deleteStudent(dakhlaNumbers);
                LandingPage newPage = new LandingPage();
                this.Hide();
                newPage.Show();
                newPage.mainTab.SelectedIndex = 2;
                //searchStudentButton.PerformClick();
            }

        }

        private void searchCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchCombobox.Text.Equals("رجسٹریشن نمبر"))
            {
                searchLabel.Text = "رجسٹریشن نمبر";
                searchLabel.Enabled = true;
                searchTextbox.Enabled = true;
            }
            else if (searchCombobox.Text.Equals("نام"))
            {
                searchLabel.Text = "نام";
                searchLabel.Enabled = true;
                searchTextbox.Enabled = true;
            }
            else if (searchCombobox.Text.Equals("والد کا نام"))
            {
                searchLabel.Text = "والد کا نام";
                searchLabel.Enabled = true;
                searchTextbox.Enabled = true;
            }
            else if (searchCombobox.Text.Equals("سال"))
            {
                searchLabel.Text = "سال";
                searchLabel.Enabled = true;
                searchTextbox.Enabled = true;
            }
            else if (searchCombobox.Text.Equals("امدادی"))
            {
                searchLabel.Enabled = false;
                searchTextbox.Enabled = false;
            }
        }

        private void resetCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            class1Radio.Checked = false;
            class2Radio.Checked = false;
            class3Radio.Checked = false;
            class4Radio.Checked = false;
            class5Radio.Checked = false;
            class6Radio.Checked = false;
            class7Radio.Checked = false;
            class8Radio.Checked = false;
            class9Radio.Checked = false;
            class10Radio.Checked = false;
            class11Radio.Checked = false;
            class12Radio.Checked = false;
            class13Radio.Checked = false;
            class14Radio.Checked = false;
            class15Radio.Checked = false;

            classQaidaRadio.Checked = false;
            classNaziraRadio.Checked = false;
            classHifzRadio.Checked = false;
        }

        private void exportGridView_Click(object sender, EventArgs e)
        {

            string path = @"D:\reporting\" + fileName;

            //Original path
            /*
            string path = @"E:\" + fileName;
            */

            /*
            string pathImage = @"D:\Uni\Xtra\Program\DotNet\Imdad-ul-Uloom\logo\logo.png";

            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(pathImage);
            logo.ScaleAbsolute(200, 100);
            logo.Alignment = Element.ALIGN_CENTER;
            */
            Document document = new Document(PageSize.A4);
            try
            {
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));

                BaseFont basefont = BaseFont.CreateFont("C:\\Windows\\Fonts\\Arial.ttf", BaseFont.IDENTITY_H, true);

                iTextSharp.text.Font urduFont = new iTextSharp.text.Font(basefont, 8, iTextSharp.text.Font.DEFAULTSIZE);

                var el = new Chunk();
                iTextSharp.text.Font f2 = new iTextSharp.text.Font(basefont, 8);
                el.Font = f2;

                PdfPTable table = new PdfPTable(studentGridView.Columns.Count);
                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

                foreach (DataGridViewColumn item in studentGridView.Columns)
                {
                    var str = studentGridView.Columns[item.Index].HeaderText.ToString();
                    PdfPCell cell = new PdfPCell(new Phrase(10, str, el.Font));
                    cell.NoWrap = false;
                    table.AddCell(cell);
                }
                

                for (int row = 0; row < studentGridView.Rows.Count; row++)
                {
                    for (int column = 0; column < studentGridView.Columns.Count; column++)
                    {
                        var str = "";
                        if (studentGridView.Rows[row].Cells[column].Value == null)
                        {
                            str = "";
                        }
                        else
                        {
                            str = studentGridView.Rows[row].Cells[column].Value.ToString();
                        }
                        PdfPCell cell = new PdfPCell(new Phrase(10, str, el.Font));
                        table.AddCell(cell);
                    }
                }
                document.Open();
                //document.Add(logo);
                document.Add(table);
                document.Close();

            }
            catch (DocumentException de)
            {
                //              this.Message = de.Message;
            }
            catch (IOException ioe)
            {
                //                this.Message = ioe.Message;
            }

            // step 5: we close the document
            document.Close();

            MessageBox.Show("Print completed at Location : " + path);
        }

        private void formExportToPDButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Student student = getStudentFromForm();
            DakhlaFormReport f2 = new DakhlaFormReport();
            f2.Student = student;
            f2.Show();
            Cursor.Current = Cursors.Default;
        }

        //private void searchDakhlaNumbers_Click(object sender, EventArgs e)
        //{
        //    dakhlaNumbersList.Items.Clear();
        //    clearLabels();
        //    sameRegistrationNumberStudentsList.Clear();
        //    try
        //    {
        //        List<String> dakhlaNumbers = DataManipulation.getDakhlaNumbers(regNumTextbox.Text);
        //        if(dakhlaNumbers.Any())
        //        {
        //            foreach (var item in dakhlaNumbers)
        //            {
        //                dakhlaNumbersList.Items.Add(item);
        //            }

        //            foreach (String item in dakhlaNumbers)
        //            {
        //                foreach (Student student in inActiveStudentList)
        //                {
        //                    if (Convert.ToInt32(item) == student.StudentDakhlaNumber.DakhlaNumber)
        //                    {
        //                        sameRegistrationNumberStudentsList.Add(student.StudentDakhlaNumber.DakhlaNumber, student);
        //                    }
        //                }
        //            }

        //            StudentRegAndDakhlaNumber.RegistrationNumber = Convert.ToInt32(regNumTextbox.Text);
        //            newRegistratioNumberLabel.Text = StudentRegAndDakhlaNumber.RegistrationNumber.ToString();


        //        }
        //        else
        //        {
        //            MessageBox.Show("سابق طالبعلم نہیں ہے۔");
        //        }



        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }

        //}

        //private void dakhlaNumbersList_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int dakhlaNumber = Convert.ToInt32(dakhlaNumbersList.SelectedItem);
        //    Student item = sameRegistrationNumberStudentsList[dakhlaNumber];

        //    registrationNumberlbl.Text = item.StudentRegistrationNumber.RegistrationNumber.ToString();
        //    formNumberlbl.Text = item.StudentDakhlaNumber.FormNumber.ToString();
        //    dakhlaNumberlbl.Text = item.StudentDakhlaNumber.DakhlaNumber.ToString();
        //    namelbl.Text = item.StudentBasicInfo.NameStudent;
        //    fNamelbl.Text = item.StudentBasicInfo.FatherNameStudent;
        //    string dob = item.StudentBasicInfo.DobStudent.Day + "-" + item.StudentBasicInfo.DobStudent.Month + "-" + item.StudentBasicInfo.DobStudent.Year;
        //    doblbl.Text = dob;
        //    contactlbl.Text = item.StudentBasicInfo.ContactStudent;
        //    cniclbl.Text = item.StudentBasicInfo.CnicStudent;
        //    darjalbl.Text = item.StudentBasicInfo.RequiredDarjaStudent;
        //    zilalbl.Text = item.StudentPermanentAddress.Zila;
        //    tehseellbl.Text = item.StudentPermanentAddress.Tehseel;
        //    dakKhanalbl.Text = item.StudentPermanentAddress.DakKhana;
        //    villagelbl.Text = item.StudentPermanentAddress.Village;
        //    houselbl.Text = item.StudentKarachiAddress.HouseNumber;
        //    blocklbl.Text = item.StudentKarachiAddress.BlockNumber;
        //    sectorlbl.Text = item.StudentKarachiAddress.SectorNumber;
        //    ilaqalbl.Text = item.StudentKarachiAddress.Area;
        //    guardianNamelbl.Text = item.StudentGuardianInfo.NameGuardian;
        //    guardianContactlbl.Text = item.StudentGuardianInfo.ContactGuardian;
        //    guardiancniclbl.Text = item.StudentGuardianInfo.CnicGuardian;
        //    guardianRelatioblbl.Text = item.StudentGuardianInfo.RelationGuardian;
        //    darseNizamilbl.Text = item.StudentQawaif.DarseNizami;
        //    asriTaleemlbl.Text = item.StudentQawaif.AsriTaleem;
        //    lastIdaralbl.Text = item.StudentQawaif.LastIdara;
        //    hifzChckBox.Checked = item.StudentQawaif.Hifz;
        //    naziraChkbox.Checked = item.StudentQawaif.Nazira;
        //    imdadiChckBox.Checked = item.StudentRihaish.Imdadi;
        //    rihaishChckBox.Checked = item.StudentRihaish.Rihaish;
        //    takmeelDatelbl.Text = item.StudentFormDate.TakmeelDakhlaDate;
        //    ikhrajDatelbl.Text = item.StudentFormDate.IkhrajDate;
        //    try
        //    {
        //        if (item.StudentBasicInfo.ImageStudent != null)
        //        {
        //            MemoryStream ms = new MemoryStream(item.StudentBasicInfo.ImageStudent);
        //            picBox.Image = System.Drawing.Image.FromStream(ms);
        //        }
        //        else
        //        {
        //            MessageBox.Show("تصویر موجود نہیں ہے۔");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }

        //}

        //private void clearLabels()
        //{
        //    registrationNumberlbl.Text = "";
        //    formNumberlbl.Text = "";
        //    dakhlaNumberlbl.Text = "";
        //    namelbl.Text = "";
        //    fNamelbl.Text = "";
        //    doblbl.Text = "";
        //    contactlbl.Text = "";
        //    cniclbl.Text = "";
        //    darjalbl.Text = "";
        //    zilalbl.Text = "";
        //    tehseellbl.Text = "";
        //    dakKhanalbl.Text = "";
        //    villagelbl.Text = "";
        //    houselbl.Text = "";
        //    blocklbl.Text = "";
        //    sectorlbl.Text = "";
        //    ilaqalbl.Text = "";
        //    guardianNamelbl.Text = "";
        //    guardianContactlbl.Text = "";
        //    guardiancniclbl.Text = "";
        //    guardianRelatioblbl.Text = "";
        //    darseNizamilbl.Text = "";
        //    asriTaleemlbl.Text = "";
        //    lastIdaralbl.Text = "";
        //    hifzChckBox.Checked = false;
        //    naziraChkbox.Checked = false;
        //    imdadiChckBox.Checked = false;
        //    rihaishChckBox.Checked = false;
        //    takmeelDatelbl.Text = "";
        //    ikhrajDatelbl.Text = "";
        //    picBox.Image = null;

        //    newRegistratioNumberLabel.Text = "";

        //}

        //private void savePreiousStudentButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if(dakhlaNumbersList.SelectedItems.Count == 1)
        //        {
        //            Cursor.Current = Cursors.WaitCursor;
        //            Student student = sameRegistrationNumberStudentsList[Convert.ToInt32(dakhlaNumbersList.SelectedItem)];
        //            student.StudentDakhlaNumber.DakhlaNumber = Convert.ToInt32(newDakhlaNumberLabel.Text);
        //            student.StudentDakhlaNumber.FormNumber = Convert.ToInt32(newFormNumberLabel.Text);
        //            student.StudentDakhlaNumber.ActiveIndex = true;
        //            DataManipulation.addStudent(student, true);

        //            DakhlaCardReport rpt = new DakhlaCardReport();
        //            rpt.Student = student;

        //            LandingPage newPage = new LandingPage();
        //            this.Hide();
        //            newPage.Show();
        //            rpt.Show();
        //            Cursor.Current = Cursors.Default;

        //        }
        //        else
        //        {
        //            MessageBox.Show("داخلہ نمبر سلیکت کیجئے۔");
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        private void printCardButton_Click(object sender, EventArgs e)
        {
            if (studentGridView.SelectedRows.Count == 1)
            {
                Cursor.Current = Cursors.WaitCursor;
                int dakhlaNumber = Convert.ToInt32(studentGridView.SelectedRows[0].Cells[1].Value);
                foreach (var item in activeStudentList)
                {
                    if (item.StudentDakhlaNumber.DakhlaNumber == dakhlaNumber)
                    {
                        DakhlaCardReport rpt = new DakhlaCardReport();
                        rpt.Student = item;
                        rpt.Show();
                        break;
                    }
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mainTab.SelectedIndex = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainTab.SelectedIndex = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainTab.SelectedIndex = 3;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mainTab.SelectedIndex = 4;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataManipulation.backUpDatabase();
        }

        private void searchGuardianInfoButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(searchTextboxGuardianInfo.Text))
            {
                MessageBox.Show("رجسٹریشن نمبر لکھئے۔");
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                guardianInfoGridView.Rows.Clear();
                int regNum = Convert.ToInt32(searchTextboxGuardianInfo.Text);
                List<StudentGuardianInfo> guardianInfoList = new List<StudentGuardianInfo>();
                foreach(Student student in activeStudentList)
                {
                    if(student.StudentDakhlaNumber.DakhlaNumber == regNum)
                    {
                        guardianInfoList = student.StudentGuardianInfo;
                    }
                }

                if(guardianInfoList.Count > 0)
                {
                    guardianInfoGridView.Rows.Add(guardianInfoList.Count);

                    for (int row = 0; row < guardianInfoList.Count; row++)
                    {
                        StudentGuardianInfo fillStudent = guardianInfoList[row];
                        guardianInfoGridView.Rows[row].Cells[1].Value = fillStudent.GuardianInfoId;
                        guardianInfoGridView.Rows[row].Cells[2].Value = fillStudent.NameGuardian;
                        guardianInfoGridView.Rows[row].Cells[3].Value = fillStudent.ContactGuardian;
                        guardianInfoGridView.Rows[row].Cells[4].Value = fillStudent.RelationGuardian;
                        guardianInfoGridView.Rows[row].Cells[5].Value = fillStudent.CnicGuardian;

                    }

                    for (int row = 0; row < guardianInfoGridView.RowCount; row++)
                    {
                        guardianInfoGridView.Rows[row].Cells[0].Value = row + 1;
                    }
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("رجسٹریشن نمبر موجود نہیں");
                }

            }
        }
        
        private void saveGuardianInfoButton_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(guardianNameTB.Text) || String.IsNullOrEmpty(guardianCNICTB.Text) ||
                String.IsNullOrEmpty(guardianPhoneTB.Text) || String.IsNullOrEmpty(guardianRelationTB.Text))
            {
                MessageBox.Show("ڈیٹا خالئ نہ چھوڑیں۔");
            }
            else
            {
                if (String.IsNullOrEmpty(searchTextboxGuardianInfo.Text))
                {
                    MessageBox.Show("رجسٹریشن نمبر لکھئے۔");
                }
                else
                {
                    int regNum = Convert.ToInt32(searchTextboxGuardianInfo.Text);
                    foreach (Student student in activeStudentList)
                    {
                        if (student.StudentDakhlaNumber.DakhlaNumber == regNum)
                        {
                            StudentGuardianInfo guardianInfo = new StudentGuardianInfo();
                            guardianInfo.NameGuardian = guardianNameTB.Text;
                            guardianInfo.CnicGuardian = guardianCNICTB.Text;
                            guardianInfo.DakhlaNumber = regNum;
                            guardianInfo.ContactGuardian = guardianPhoneTB.Text;
                            guardianInfo.RelationGuardian = guardianRelationTB.Text;

                            DataManipulation.addStudentGuardianInfo(guardianInfo);
                            break;
                        }
                    }
                    LandingPage newPage = new LandingPage();
                    this.Hide();
                    newPage.Show();
                    newPage.mainTab.SelectedIndex = 3;

                }
            }
            
        }

        private void searchDarjaRecordButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(searchTextboxDarjaRecord.Text))
            {
                MessageBox.Show("رجسٹریشن نمبر لکھئے۔");
            }
            else
            {
                darjaGridView.Rows.Clear();
                int regNum = Convert.ToInt32(searchTextboxDarjaRecord.Text);
                List<StudentDarjaRecord> darjaRecords = DataManipulation.getDarjaOfStudent(regNum);
                if (darjaRecords.Count > 0)
                {
                    darjaGridView.Rows.Add(darjaRecords.Count);

                    for (int row = 0; row < darjaRecords.Count; row++)
                    {
                        StudentDarjaRecord fillStudent = darjaRecords[row];
                        darjaGridView.Rows[row].Cells[1].Value = fillStudent.SchoolDarja;
                        darjaGridView.Rows[row].Cells[2].Value = fillStudent.YearSchool;
                        darjaGridView.Rows[row].Cells[3].Value = fillStudent.Quraniadarja;
                        darjaGridView.Rows[row].Cells[4].Value = fillStudent.YearQurania;
                        darjaGridView.Rows[row].Cells[5].Value = (fillStudent.ActiveInd == true) ? "ہاں" : "نہیں";
                    }

                    for (int row = 0; row < darjaGridView.RowCount; row++)
                    {
                        darjaGridView.Rows[row].Cells[0].Value = row + 1;
                    }
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("رجسٹریشن نمبر موجود نہیں");
                }
                
            }
        }

        private void removeDarjaBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(searchTextboxDarjaRecord.Text))
            {
                MessageBox.Show("رجسٹریشن نمبر لکھئے۔");
            }
            else if(darjaGridView.SelectedRows.Count == 1)
            {
                DialogResult confirm = MessageBox.Show("Are you sure, You want to remove darja?", "Delete Darja", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    StudentDarjaRecord darjaRecord = new StudentDarjaRecord();
                    darjaRecord.DakhlaNumber = Convert.ToInt32(searchTextboxDarjaRecord.Text);

                    foreach (DataGridViewRow row in darjaGridView.SelectedRows)
                    {
                        darjaRecord.SchoolDarja = darjaGridView.SelectedRows[0].Cells[1].Value.ToString();
                        darjaRecord.YearSchool = darjaGridView.SelectedRows[0].Cells[2].Value.ToString();
                        darjaRecord.Quraniadarja = darjaGridView.SelectedRows[0].Cells[3].Value.ToString();
                        darjaRecord.YearQurania = darjaGridView.SelectedRows[0].Cells[4].Value.ToString();
                        break;
                    }

                    DataManipulation.deleteDarjaStudent(darjaRecord);
                    
                    LandingPage newPage = new LandingPage();
                    this.Hide();
                    newPage.Show();
                    newPage.mainTab.SelectedIndex = 4;
                }
            }
            else
            {

            }
        }

        private void saveNewDarjaBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(searchTextboxDarjaRecord.Text))
            {
                MessageBox.Show("رجسٹریشن نمبر لکھئے۔");
            }
            else
            {
                StudentDarjaRecord newDarjaRecord = new StudentDarjaRecord();
                newDarjaRecord.SchoolDarja = newDarjaSchoolCombobox.Text;
                newDarjaRecord.YearSchool = newDarjaYearSchoolCB.Text;
                newDarjaRecord.Quraniadarja = newDarjaQuraniaCombobox.Text;
                newDarjaRecord.YearQurania = newDarjaQuraniaYearCB.Text;
                newDarjaRecord.DakhlaNumber = Convert.ToInt32(searchTextboxDarjaRecord.Text);
                DataManipulation.addNewDarja(newDarjaRecord);

                LandingPage newPage = new LandingPage();
                this.Hide();
                newPage.Show();
                newPage.mainTab.SelectedIndex = 4;
 

            }
        }

        private void saveReceiptBookInfo_Click(object sender, EventArgs e)
        {
            int bookNumber = Convert.ToInt32(bookNumberTextbox.Text);
            int firstSlip = Convert.ToInt32(firstSlipTextbox.Text);
            int lastSlip = Convert.ToInt32(lastSlipTextbox.Text);
            try
            {
                DataManipulation.addNewBook(bookNumber, firstSlip, lastSlip);
                LandingPage newPage = new LandingPage();
                this.Hide();
                newPage.Show();
                newPage.mainTab.SelectedIndex = 5;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void bookLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            int bookNumber = Convert.ToInt32(bookLists.SelectedValue);
            List<string> bookInfo = DataManipulation.getSpecificBookInfo(bookNumber);
            specificBookFirstSlip.Text = bookInfo[0];
            specificBookLastSlip.Text = bookInfo[1];
        }

        private void updatereceiptBookInfo_Click(object sender, EventArgs e)
        {
            int bookNumber = Convert.ToInt32(updateBookNumber.Text);
            if(bookLists.Items.Contains(bookNumber))
            {
                int firstSlip = Convert.ToInt32(updateFirstSlip.Text);
                int lastSlip = Convert.ToInt32(updateLastSlip.Text);
                try
                {
                    DataManipulation.updateBook(bookNumber, firstSlip, lastSlip);
                    LandingPage newPage = new LandingPage();
                    this.Hide();
                    newPage.Show();
                    newPage.mainTab.SelectedIndex = 5;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("بک نمبر درست نہیں۔");
            }
        }
        
        private void searchBtnFeeEntryTab_Click(object sender, EventArgs e)
        {
            int dakhlaNumber = Convert.ToInt32(dakhlaNumberTextboxFeeEntryTab.Text);
            foreach(Student student in activeStudentList)
            {
                if(student.StudentDakhlaNumber.DakhlaNumber.Equals(dakhlaNumber))
                {
                    nameStudentTextboxFeeEntryTab.Text = student.StudentBasicInfo.NameStudent;
                    fnameTextboxFeeEntryTab.Text = student.StudentBasicInfo.FatherNameStudent;
                    sirNameTextboxFeeEntryTab.Text = student.StudentBasicInfo.SurName;
                    classSchoolTextboxFeeEntryTab.Text = student.StudentDarjaRecord.SchoolDarja;
                    classQuraniaTextboxFeeEntryTab.Text = student.StudentDarjaRecord.Quraniadarja;
                    try
                    {
                        if (student.StudentBasicInfo.ImageStudent != null)
                        {
                            MemoryStream ms = new MemoryStream(student.StudentBasicInfo.ImageStudent);
                            imageStudentFeeEntryTab.Image = System.Drawing.Image.FromStream(ms);
                        }
                        else
                        {
                            MessageBox.Show("تصویر موجود نہیں ہے۔");
                        }

                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    break;
                }
            }
            
        }

        private void newStudentCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if(newStudentCheckbox.Checked)
            {
                newStudentPanel.Visible = true;
            }
            else
            {
                newStudentPanel.Visible = false;
            }
        }

        private void otherFeeChkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (otherFeeChkbox.Checked)
            {
                otherFeePanel.Visible = true;
            }
            else
            {
                otherFeePanel.Visible = false;
            }
        }








        //private void cnicStudentTextbox_TextChanged(object sender, EventArgs e)
        //{
        //    if(cnicStudentTextbox.Text.Length > 13)
        //    {
        //        MessageBox.Show("شناختی کارڈ نمبر 13 ڈیجیٹ کا فل کیجئے۔");
        //        cnicStudentTextbox.Text = "";
        //        cnicStudentTextbox.Focus();
        //    }
        //}

        //private void contactStudentTextbox_TextChanged(object sender, EventArgs e)
        //{
        //    if (contactStudentTextbox.Text.Length > 11)
        //    {
        //        MessageBox.Show("موبائل نمبر 11 ڈیجیٹ کا فل کیجئے۔");
        //        contactStudentTextbox.Text = "";
        //        contactStudentTextbox.Focus();
        //    }
        //}

        //private void contactGuardianTextbox_TextChanged(object sender, EventArgs e)
        //{
        //    if (contactGuardianTextbox.Text.Length > 11)
        //    {
        //        MessageBox.Show("موبائل نمبر 11 ڈیجیٹ کا فل کیجئے۔");
        //        contactGuardianTextbox.Text = "";
        //        contactGuardianTextbox.Focus();
        //    }
        //}

        //private void cnicGuardianTextbox_TextChanged(object sender, EventArgs e)
        //{
        //    if (cnicGuardianTextbox.Text.Length > 13)
        //    {
        //        MessageBox.Show("شناختی کارڈ نمبر 13 ڈیجیٹ کا فل کیجئے۔");
        //        cnicGuardianTextbox.Text = "";
        //        cnicGuardianTextbox.Focus();
        //    }
        //}

        //private void nameStudentTextbox_TextChanged(object sender, EventArgs e)
        //{
        //    errorProvider.Clear();
        //}

        //private void fatherNameStudentTextbox_TextChanged(object sender, EventArgs e)
        //{
        //    errorProvider.Clear();
        //}

        //private void requiredDarjaStudentCombobox_TextChanged(object sender, EventArgs e)
        //{
        //    errorProvider.Clear();
        //}

        //private void takmeelDateCombobox_TextChanged(object sender, EventArgs e)
        //{
        //    errorProvider.Clear();
        //}

        //private void takmeelMonthCombobox_TextChanged(object sender, EventArgs e)
        //{
        //    errorProvider.Clear();
        //}

        //private void takmeelYearCombobox_TextChanged(object sender, EventArgs e)
        //{
        //    errorProvider.Clear();
        //}

        //private void cnicStudentTextbox_Leave(object sender, EventArgs e)
        //{
        //    if(cnicStudentTextbox.Text.Length == 13)
        //    {
        //        String cnicCurrent = cnicStudentTextbox.Text;
        //        Boolean contain = false;
        //        foreach(Student student in activeStudentList)
        //        {
        //            if (cnicCurrent.Equals(student.StudentBasicInfo.CnicStudent))
        //            {
        //                contain = true;
        //            }
        //        }
        //        foreach(Student student in inActiveStudentList)
        //        {
        //            if (cnicCurrent.Equals(student.StudentBasicInfo.CnicStudent))
        //            {
        //                contain = true;
        //            }
        //        }
        //        if (contain)
        //        {
        //            DialogResult result = MessageBox.Show("طالبعلم پہلے سے ڈیٹا بیس میں موجود ہے۔ دوبارہ داخلے کیلئے قدیم طالبعلم ٹیب استعمال کیجئے۔", "Duplicate Student", MessageBoxButtons.YesNo);

        //            if (result == DialogResult.Yes)
        //            {
        //                cnicStudentTextbox.Text = "";
        //                mainTab.SelectedIndex = 3;
        //            }
        //            else
        //            {
        //                cnicStudentTextbox.Text = "";
        //            }
        //        }
        //    }
        // }
    }
}