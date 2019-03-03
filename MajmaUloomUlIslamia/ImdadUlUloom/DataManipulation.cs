using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MajmaUloomUlIslamia
{
    class DataManipulation
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        public static SqlConnection sqlConnection;
        public static SqlTransaction sqlTransaction;
        public static Hashtable monthNumber = new Hashtable()
        {
            {"JANUARY", 1 },
            {"FEBRUARY", 2 },
            {"MARCH", 3 },
            {"APRIL", 4 },
            {"MAY", 5 },
            {"JUNE", 6 },
            {"JULY", 7 },
            {"AUGUST", 8 },
            {"SEPTEMBER", 9 },
            {"OCTOBER", 10 },
            {"NOVEMBER", 11 },
            {"DECEMBER", 12 },
        };
        
        public static void getFormAndDakhlaNumber()
        {
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    string queryGetFormAndDakhlaNumber = "select max(formNumber), max(dakhlaNumber) from StudentDakhlaNumber";
                    try
                    {
                        sqlConnection.Open();
                        SqlCommand getFormNumberCommand = new SqlCommand(queryGetFormAndDakhlaNumber, sqlConnection);
                        SqlDataReader reader2 = getFormNumberCommand.ExecuteReader();
                        while (reader2.Read())
                        {
                            StudentDakhlaAndFormNumber.FormNumber = Convert.ToInt32(reader2[0]) + 1;
                            StudentDakhlaAndFormNumber.DakhlaNumber = Convert.ToInt32(reader2[1]) + 1;
                        }
                        reader2.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private static int getDarjaRecordId()
        {
            int darjaRecordId = Int32.MaxValue;
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    string queryGetDarjaRecordId = "select max(darjaRecordId) from StudentDarjaRecord";
                    try
                    {
                        sqlConnection.Open();
                        SqlCommand getDarjaRecordIdCommand = new SqlCommand(queryGetDarjaRecordId, sqlConnection);
                        SqlDataReader reader2 = getDarjaRecordIdCommand.ExecuteReader();
                        while (reader2.Read())
                        {
                            darjaRecordId = Convert.ToInt32(reader2[0]) + 1;
                        }
                        reader2.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return darjaRecordId;
        }

        private static int getBookNumberId()
        {
            int bookNumberId = Int32.MaxValue;
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    string queryGetBookNumberId = "select max(receiptBookId) from ReceiptBook";
                    try
                    {
                        sqlConnection.Open();
                        SqlCommand getBookNumberIdCommand = new SqlCommand(queryGetBookNumberId, sqlConnection);
                        SqlDataReader reader2 = getBookNumberIdCommand.ExecuteReader();
                        while (reader2.Read())
                        {
                            bookNumberId = Convert.ToInt32(reader2[0]) + 1;
                        }
                        reader2.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return bookNumberId;
        }

        private static int getNextBookSequence()
        {
            int bookNumber = Int32.MaxValue;
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    string getBookLastSequence = "select max(bookSequence) from ReceiptBook";
                    try
                    {
                        sqlConnection.Open();
                        SqlCommand getBookLastSequenceCommand = new SqlCommand(getBookLastSequence, sqlConnection);
                        SqlDataReader reader2 = getBookLastSequenceCommand.ExecuteReader();
                        while (reader2.Read())
                        {
                            bookNumber = Convert.ToInt32(reader2[0]) + 1;
                        }
                        reader2.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return bookNumber;
        }

        private static int getTransactionId()
        {
            int transactionId = Int32.MaxValue;
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    string getTransactionId = "select max(transactionId) from MajmaTransaction";
                    try
                    {
                        sqlConnection.Open();
                        SqlCommand getTransactionIdCommand = new SqlCommand(getTransactionId, sqlConnection);
                        SqlDataReader reader2 = getTransactionIdCommand.ExecuteReader();
                        while (reader2.Read())
                        {
                            transactionId = Convert.ToInt32(reader2[0]) + 1;
                        }
                        reader2.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return transactionId;
        }

        private static int getStudentFeeId()
        {
            int studentFeeId = Int32.MaxValue;
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    string getStudentFeeId = "select max(studentFeeId) from StudentFee";
                    try
                    {
                        sqlConnection.Open();
                        SqlCommand getStudentFeeIdCommand = new SqlCommand(getStudentFeeId, sqlConnection);
                        SqlDataReader reader2 = getStudentFeeIdCommand.ExecuteReader();
                        while (reader2.Read())
                        {
                            studentFeeId = Convert.ToInt32(reader2[0]) + 1;
                        }
                        reader2.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return studentFeeId;
        }

        private static int getGuardianInfoId()
        {
            int guardianInfoId = Int32.MaxValue;
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    string queryGetGuardianId = "select max(guardianInfoId) from StudentGuardianInfo";
                    try
                    {
                        sqlConnection.Open();
                        SqlCommand getGuardianIdCommand = new SqlCommand(queryGetGuardianId, sqlConnection);
                        SqlDataReader reader2 = getGuardianIdCommand.ExecuteReader();
                        while (reader2.Read())
                        {
                            guardianInfoId = Convert.ToInt32(reader2[0]) + 1;
                        }
                        reader2.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return guardianInfoId;
        }

        
        public static void addStudent(Student newStudent, Boolean existing)
        {
            int darjaRecordId = getDarjaRecordId();
            int guardianId = getGuardianInfoId();

            using(sqlConnection = new SqlConnection(connectionString))
            {
                string querydakhlaNumber = "insert into StudentDakhlaNumber(dakhlaNumber, formNumber, activeIndex) values(@dakhlaNumber, @formNumber, @activeIndex)";
                string queryBasicInfo = "insert into StudentBasicInfo(dakhlaNumber, nameStudent, fatherNameStudent, surNameStudent, dobStudent, imageStudent) values(@dakhlaNumber, @nameStudent, @fatherNameStudent, @surNameStudent, @dobStudent, @imageStudent)";
                string queryFormDate = "insert into StudentFormDate(dakhlaNumber, takmeelDakhlaDate, ikhrajDate) values(@dakhlaNumber, @takmeelDakhlaDate, @ikhrajDate)";
                string queryStudentDarjaRecord = "insert into StudentDarjaRecord(darjaRecordId, dakhlaNumber, schoolDarja, quraniaDarja, yearSchool, activeInd, yearQurania) values(@darjaRecordId, @dakhlaNumber, @schoolDarja, @quraniaDarja, @yearSchool, @activeInd, @yearQurania)";
                string queryGuardianInfo = "insert into StudentGuardianInfo(guardianInfoId, dakhlaNumber, nameGuardian, contactGuardian, relationGuardian, cnicGuardian, isPrimary) values(@guardianInfoId, @dakhlaNumber, @nameGuardian, @contactGuardian, @relationGuardian, @cnicGuardian, @isPrimary)";
                string queryPermanentAddress = "insert into StudentPermanentAddress(dakhlaNumber, zila, tehseel, dakKhana, village) values (@dakhlaNumber, @zila, @tehseel, @dakKhana, @village)";
                string queryKarachiAddress = "insert into StudentKarachiAddress(dakhlaNumber, houseNumber, blockNumber, sectorNumber, area) values(@dakhlaNumber, @houseNumber, @blockNumber, @sectorNumber, @area)";
                string queryQawaif = "insert into StudentQawaif(dakhlaNumber, qurania, lastQuraniaIdara, lastAsriTaleemIdara, asriTaleem) values(@dakhlaNumber, @qurania, @lastQuraniaIdara, @lastAsriTaleemIdara, @asriTaleem)";
                string queryRihaish = "insert into StudentRihaish(dakhlaNumber, imdadi) values(@dakhlaNumber, @imdadi)";
                try
                {
                    sqlConnection.Open();
                    sqlTransaction = sqlConnection.BeginTransaction();
                    /* 
                    if (!existing)
                    {
                        sqlcommand insertregnumber = new sqlcommand(queryregnumber, sqlconnection, sqltransaction);
                        insertregnumber.parameters.addwithvalue("@registrationnumber", newstudent.studentregistrationnumber.registrationnumber);
                        insertregnumber.executenonquery();
                    }
                    */
                    SqlCommand insertDakhlaNumberCommand = new SqlCommand(querydakhlaNumber, sqlConnection, sqlTransaction);
                    insertDakhlaNumberCommand.Parameters.AddWithValue("@dakhlaNumber", newStudent.StudentDakhlaNumber.DakhlaNumber);
                    insertDakhlaNumberCommand.Parameters.AddWithValue("@formNumber", newStudent.StudentDakhlaNumber.FormNumber);
                    insertDakhlaNumberCommand.Parameters.AddWithValue("@activeIndex", newStudent.StudentDakhlaNumber.ActiveIndex);
                    insertDakhlaNumberCommand.ExecuteNonQuery();

                    SqlCommand insertBasicInfoCommand = new SqlCommand(queryBasicInfo, sqlConnection, sqlTransaction);
                    insertBasicInfoCommand.Parameters.AddWithValue("@dakhlaNumber", newStudent.StudentDakhlaNumber.DakhlaNumber);
                    insertBasicInfoCommand.Parameters.AddWithValue("@nameStudent", newStudent.StudentBasicInfo.NameStudent);
                    insertBasicInfoCommand.Parameters.AddWithValue("@fatherNameStudent", newStudent.StudentBasicInfo.FatherNameStudent);
                    insertBasicInfoCommand.Parameters.AddWithValue("@dobStudent", newStudent.StudentBasicInfo.DobStudent);
                    insertBasicInfoCommand.Parameters.AddWithValue("@surNameStudent", newStudent.StudentBasicInfo.SurName);
                    insertBasicInfoCommand.Parameters.Add("@imageStudent", SqlDbType.Image);
                    if (newStudent.StudentBasicInfo.ImageStudent != null)
                    {
                        insertBasicInfoCommand.Parameters["@imageStudent"].Value = newStudent.StudentBasicInfo.ImageStudent;
                    }
                    else
                    {
                        insertBasicInfoCommand.Parameters["@imageStudent"].Value = DBNull.Value;
                    }
                    insertBasicInfoCommand.ExecuteNonQuery();

                    SqlCommand insertDarjaRecord = new SqlCommand(queryStudentDarjaRecord, sqlConnection, sqlTransaction);
                    insertDarjaRecord.Parameters.AddWithValue("@darjaRecordId", darjaRecordId);
                    insertDarjaRecord.Parameters.AddWithValue("@dakhlaNumber", newStudent.StudentDakhlaNumber.DakhlaNumber);
                    insertDarjaRecord.Parameters.AddWithValue("@schoolDarja", newStudent.StudentDarjaRecord.SchoolDarja);
                    insertDarjaRecord.Parameters.AddWithValue("@quraniaDarja", newStudent.StudentDarjaRecord.Quraniadarja);
                    insertDarjaRecord.Parameters.AddWithValue("@yearSchool", newStudent.StudentDarjaRecord.YearSchool);
                    insertDarjaRecord.Parameters.AddWithValue("@activeInd", 1);
                    insertDarjaRecord.Parameters.AddWithValue("@yearQurania", newStudent.StudentDarjaRecord.YearQurania);
                    insertDarjaRecord.ExecuteNonQuery();

                    StudentGuardianInfo studentGuardianInfo = newStudent.StudentGuardianInfo[0];

                    SqlCommand insertGuardianInfoCommand = new SqlCommand(queryGuardianInfo, sqlConnection, sqlTransaction);
                    insertGuardianInfoCommand.Parameters.AddWithValue("@guardianInfoId", guardianId);
                    insertGuardianInfoCommand.Parameters.AddWithValue("@dakhlaNumber", studentGuardianInfo.DakhlaNumber);
                    insertGuardianInfoCommand.Parameters.AddWithValue("@nameGuardian", studentGuardianInfo.NameGuardian);
                    insertGuardianInfoCommand.Parameters.AddWithValue("@contactGuardian", studentGuardianInfo.ContactGuardian);
                    insertGuardianInfoCommand.Parameters.AddWithValue("@relationGuardian", studentGuardianInfo.RelationGuardian);
                    insertGuardianInfoCommand.Parameters.AddWithValue("@cnicGuardian", studentGuardianInfo.CnicGuardian);
                    insertGuardianInfoCommand.Parameters.AddWithValue("@isPrimary", 1);
                    insertGuardianInfoCommand.ExecuteNonQuery();

                    SqlCommand insertKarachiAddressCommand = new SqlCommand(queryKarachiAddress, sqlConnection, sqlTransaction);
                    insertKarachiAddressCommand.Parameters.AddWithValue("@dakhlaNumber", newStudent.StudentDakhlaNumber.DakhlaNumber);
                    insertKarachiAddressCommand.Parameters.AddWithValue("@houseNumber", newStudent.StudentKarachiAddress.HouseNumber);
                    insertKarachiAddressCommand.Parameters.AddWithValue("@blockNumber", newStudent.StudentKarachiAddress.BlockNumber);
                    insertKarachiAddressCommand.Parameters.AddWithValue("@sectorNumber", newStudent.StudentKarachiAddress.SectorNumber);
                    insertKarachiAddressCommand.Parameters.AddWithValue("@area", newStudent.StudentKarachiAddress.Area);
                    insertKarachiAddressCommand.ExecuteNonQuery();

                    SqlCommand insertPermenantAddressCommand = new SqlCommand(queryPermanentAddress, sqlConnection, sqlTransaction);
                    insertPermenantAddressCommand.Parameters.AddWithValue("@dakhlaNumber", newStudent.StudentDakhlaNumber.DakhlaNumber);
                    insertPermenantAddressCommand.Parameters.AddWithValue("@zila", newStudent.StudentPermanentAddress.Zila);
                    insertPermenantAddressCommand.Parameters.AddWithValue("@tehseel", newStudent.StudentPermanentAddress.Tehseel);
                    insertPermenantAddressCommand.Parameters.AddWithValue("@dakKhana", newStudent.StudentPermanentAddress.DakKhana);
                    insertPermenantAddressCommand.Parameters.AddWithValue("@village", newStudent.StudentPermanentAddress.Village);
                    insertPermenantAddressCommand.ExecuteNonQuery();

                    SqlCommand insertQawaifCommand = new SqlCommand(queryQawaif, sqlConnection, sqlTransaction);
                    insertQawaifCommand.Parameters.AddWithValue("@dakhlaNumber", newStudent.StudentDakhlaNumber.DakhlaNumber);
                    insertQawaifCommand.Parameters.AddWithValue("@qurania", newStudent.StudentQawaif.Qurania);
                    insertQawaifCommand.Parameters.AddWithValue("@lastQuraniaIdara", newStudent.StudentQawaif.LastQuraniaIdara);
                    insertQawaifCommand.Parameters.AddWithValue("@lastAsriTaleemIdara", newStudent.StudentQawaif.LastAsriTaleemIdara);
                    insertQawaifCommand.Parameters.AddWithValue("@asriTaleem", newStudent.StudentQawaif.AsriTaleem);
                    insertQawaifCommand.ExecuteNonQuery();

                    SqlCommand insertRihaishCommand = new SqlCommand(queryRihaish, sqlConnection, sqlTransaction);
                    insertRihaishCommand.Parameters.AddWithValue("@dakhlaNumber", newStudent.StudentDakhlaNumber.DakhlaNumber);
                    insertRihaishCommand.Parameters.AddWithValue("@imdadi", newStudent.StudentImdadi.Imdadi);
                    insertRihaishCommand.ExecuteNonQuery();
                    
                    SqlCommand insertFormDateCommand = new SqlCommand(queryFormDate, sqlConnection, sqlTransaction);
                    insertFormDateCommand.Parameters.AddWithValue("@dakhlaNumber", newStudent.StudentDakhlaNumber.DakhlaNumber);
                    insertFormDateCommand.Parameters.AddWithValue("@takmeelDakhlaDate", newStudent.StudentFormDate.TakmeelDakhlaDate);
                    insertFormDateCommand.Parameters.AddWithValue("@ikhrajDate", newStudent.StudentFormDate.IkhrajDate);
                    insertFormDateCommand.ExecuteNonQuery();
                   
                    sqlTransaction.Commit();

                    sqlConnection.Close();

                    MessageBox.Show("Data inserted");
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    MessageBox.Show("No rows inserted. Insertion Rollbacked.");
                    sqlTransaction.Rollback();
                }
            }

        }

        public static void editStudent(Student newStudent)
        {
            String[] year = newStudent.StudentFormDate.TakmeelDakhlaDate.Split('-');

            //string queryStudentDarjaRecord = "insert into StudentDarjaRecord(darjaRecordId, dakhlaNumber, schoolDarja, quraniaDarja, yearSchool, activeInd, yearQurania) values(@darjaRecordId, @dakhlaNumber, @schoolDarja, @quraniaDarja, @yearSchool, @activeInd, @yearQurania)";
            //string queryRihaish = "insert into StudentRihaish(dakhlaNumber, imdadi) values(@dakhlaNumber, @imdadi)";


            using (sqlConnection = new SqlConnection(connectionString))
            {
                string queryBasicInfo = "UPDATE StudentBasicInfo SET nameStudent = @nameStudent, fatherNameStudent = @fatherNameStudent, surNameStudent = @surNameStudent, dobStudent = @dobStudent, imageStudent = @imageStudent WHERE dakhlaNumber = @dakhlaNumber";
                string queryFormDate = "UPDATE StudentFormDate SET takmeelDakhlaDate = @takmeelDakhlaDate, ikhrajDate = @ikhrajDate WHERE dakhlaNumber = @dakhlaNumber";
                string queryGuardianInfo = "UPDATE StudentGuardianInfo SET nameGuardian = @nameGuardian, contactGuardian = @contactGuardian, relationGuardian = @relationGuardian, cnicGuardian = @cnicGuardian WHERE dakhlaNumber = @dakhlaNumber AND isPrimary = @isPrimary";
                string queryStudentDarjaRecord = "UPDATE StudentDarjaRecord SET schoolDarja = @schoolDarja, quraniaDarja = @quraniaDarja, yearSchool = @yearSchool, yearQurania = @yearQurania WHERE dakhlaNumber = @dakhlaNumber AND activeInd = @activeInd";
                string queryPermanentAddress = "UPDATE StudentPermanentAddress SET zila = @zila, tehseel = @tehseel, dakKhana = @dakKhana, village = @village WHERE dakhlaNumber = @dakhlaNumber";
                string queryKarachiAddress = "UPDATE StudentKarachiAddress SET houseNumber = @houseNumber, blockNumber = @blockNumber, sectorNumber = @sectorNumber, area = @area WHERE dakhlaNumber = @dakhlaNumber";
                string queryQawaif = "UPDATE StudentQawaif SET qurania = @qurania, lastQuraniaIdara = @lastQuraniaIdara, lastAsriTaleemIdara = @lastAsriTaleemIdara, asriTaleem = @asriTaleem WHERE dakhlaNumber = @dakhlaNumber";
                string queryRihaish = "UPDATE StudentRihaish SET imdadi = @imdadi WHERE dakhlaNumber = @dakhlaNumber";
                try
                {
                    sqlConnection.Open();

                    sqlTransaction = sqlConnection.BeginTransaction();
                    
                    SqlCommand insertBasicInfoCommand = new SqlCommand(queryBasicInfo, sqlConnection, sqlTransaction);
                    insertBasicInfoCommand.Parameters.AddWithValue("@nameStudent", newStudent.StudentBasicInfo.NameStudent);
                    insertBasicInfoCommand.Parameters.AddWithValue("@fatherNameStudent", newStudent.StudentBasicInfo.FatherNameStudent);
                    insertBasicInfoCommand.Parameters.AddWithValue("@surNameStudent", newStudent.StudentBasicInfo.SurName);
                    insertBasicInfoCommand.Parameters.AddWithValue("@dobStudent", newStudent.StudentBasicInfo.DobStudent);
                    insertBasicInfoCommand.Parameters.Add("@imageStudent", SqlDbType.Image);
                    if (newStudent.StudentBasicInfo.ImageStudent != null)
                    {
                        insertBasicInfoCommand.Parameters["@imageStudent"].Value = newStudent.StudentBasicInfo.ImageStudent;
                    }
                    else
                    {
                        insertBasicInfoCommand.Parameters["@imageStudent"].Value = DBNull.Value;
                    }
                    insertBasicInfoCommand.Parameters.AddWithValue("@dakhlaNumber", newStudent.StudentDakhlaNumber.DakhlaNumber);
                    insertBasicInfoCommand.ExecuteNonQuery();
                    
                    SqlCommand insertFormDateCommand = new SqlCommand(queryFormDate, sqlConnection, sqlTransaction);
                    insertFormDateCommand.Parameters.AddWithValue("@takmeelDakhlaDate", newStudent.StudentFormDate.TakmeelDakhlaDate);
                    insertFormDateCommand.Parameters.AddWithValue("@ikhrajDate", newStudent.StudentFormDate.IkhrajDate);
                    insertFormDateCommand.Parameters.AddWithValue("@dakhlaNumber", newStudent.StudentDakhlaNumber.DakhlaNumber);
                    insertFormDateCommand.ExecuteNonQuery();
                    
                    StudentGuardianInfo studentGuardianInfo = newStudent.StudentGuardianInfo[0];

                    SqlCommand insertGuardianInfoCommand = new SqlCommand(queryGuardianInfo, sqlConnection, sqlTransaction);
                    insertGuardianInfoCommand.Parameters.AddWithValue("@nameGuardian", studentGuardianInfo.NameGuardian);
                    insertGuardianInfoCommand.Parameters.AddWithValue("@contactGuardian", studentGuardianInfo.ContactGuardian);
                    insertGuardianInfoCommand.Parameters.AddWithValue("@relationGuardian", studentGuardianInfo.RelationGuardian);
                    insertGuardianInfoCommand.Parameters.AddWithValue("@cnicGuardian", studentGuardianInfo.CnicGuardian);
                    insertGuardianInfoCommand.Parameters.AddWithValue("@dakhlaNumber", newStudent.StudentDakhlaNumber.DakhlaNumber);
                    insertGuardianInfoCommand.Parameters.AddWithValue("@isPrimary", 1);
                    insertGuardianInfoCommand.ExecuteNonQuery();

                    SqlCommand insertKarachiAddressCommand = new SqlCommand(queryKarachiAddress, sqlConnection, sqlTransaction);
                    insertKarachiAddressCommand.Parameters.AddWithValue("@houseNumber", newStudent.StudentKarachiAddress.HouseNumber);
                    insertKarachiAddressCommand.Parameters.AddWithValue("@blockNumber", newStudent.StudentKarachiAddress.BlockNumber);
                    insertKarachiAddressCommand.Parameters.AddWithValue("@sectorNumber", newStudent.StudentKarachiAddress.SectorNumber);
                    insertKarachiAddressCommand.Parameters.AddWithValue("@area", newStudent.StudentKarachiAddress.Area);
                    insertKarachiAddressCommand.Parameters.AddWithValue("@dakhlaNumber", newStudent.StudentDakhlaNumber.DakhlaNumber);
                    insertKarachiAddressCommand.ExecuteNonQuery();

                    SqlCommand insertPermenantAddressCommand = new SqlCommand(queryPermanentAddress, sqlConnection, sqlTransaction);
                    insertPermenantAddressCommand.Parameters.AddWithValue("@zila", newStudent.StudentPermanentAddress.Zila);
                    insertPermenantAddressCommand.Parameters.AddWithValue("@tehseel", newStudent.StudentPermanentAddress.Tehseel);
                    insertPermenantAddressCommand.Parameters.AddWithValue("@dakKhana", newStudent.StudentPermanentAddress.DakKhana);
                    insertPermenantAddressCommand.Parameters.AddWithValue("@village", newStudent.StudentPermanentAddress.Village);
                    insertPermenantAddressCommand.Parameters.AddWithValue("@dakhlaNumber", newStudent.StudentDakhlaNumber.DakhlaNumber);
                    insertPermenantAddressCommand.ExecuteNonQuery();

                    //string queryStudentDarjaRecord = "UPDATE StudentDarjaRecord SET schoolDarja = @schoolDarja, quraniaDarja = @quraniaDarja, yearSchool = @yearSchool, yearQurania = @yearQurania WHERE dakhlaNumber = @dakhlaNumber AND activeInd = @activeInd";

                    SqlCommand insertDarjaRecordCommand = new SqlCommand(queryStudentDarjaRecord, sqlConnection, sqlTransaction);
                    insertDarjaRecordCommand.Parameters.AddWithValue("@schoolDarja", newStudent.StudentQawaif.Qurania);
                    insertDarjaRecordCommand.Parameters.AddWithValue("@quraniaDarja", newStudent.StudentQawaif.LastQuraniaIdara);
                    insertDarjaRecordCommand.Parameters.AddWithValue("@yearSchool", newStudent.StudentQawaif.LastAsriTaleemIdara);
                    insertDarjaRecordCommand.Parameters.AddWithValue("@yearQurania", newStudent.StudentQawaif.AsriTaleem);
                    insertDarjaRecordCommand.Parameters.AddWithValue("@dakhlaNumber", newStudent.StudentDakhlaNumber.DakhlaNumber);
                    insertDarjaRecordCommand.Parameters.AddWithValue("@activeInd", 1);
                    insertDarjaRecordCommand.ExecuteNonQuery();


                    SqlCommand insertQawaifCommand = new SqlCommand(queryQawaif, sqlConnection, sqlTransaction);
                    insertQawaifCommand.Parameters.AddWithValue("@qurania", newStudent.StudentQawaif.Qurania);
                    insertQawaifCommand.Parameters.AddWithValue("@lastQuraniaIdara", newStudent.StudentQawaif.LastQuraniaIdara);
                    insertQawaifCommand.Parameters.AddWithValue("@lastAsriTaleemIdara", newStudent.StudentQawaif.LastAsriTaleemIdara);
                    insertQawaifCommand.Parameters.AddWithValue("@asriTaleem", newStudent.StudentQawaif.AsriTaleem);
                    insertQawaifCommand.Parameters.AddWithValue("@dakhlaNumber", newStudent.StudentDakhlaNumber.DakhlaNumber);
                    insertQawaifCommand.ExecuteNonQuery();

                    SqlCommand insertRihaishCommand = new SqlCommand(queryRihaish, sqlConnection, sqlTransaction);
                    insertRihaishCommand.Parameters.AddWithValue("@imdadi", newStudent.StudentImdadi.Imdadi);
                    insertRihaishCommand.Parameters.AddWithValue("@dakhlaNumber", newStudent.StudentDakhlaNumber.DakhlaNumber);
                    insertRihaishCommand.ExecuteNonQuery();

                    sqlTransaction.Commit();

                    sqlConnection.Close();

                    MessageBox.Show("Data updated");


                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    MessageBox.Show(ex.ToString());
                    MessageBox.Show("No rows Updated. Transsaction Rollbacked.");

                }
            }
        }

        public static List<Student> getAllStudents(Boolean active)
        {
            string getAllActiveQuery;
            if (active)
            {
                getAllActiveQuery = string.Format(@"select * from StudentDakhlaNumber sd, StudentBasicInfo sb, StudentFormDate fd, StudentDarjaRecord dr,
                                    StudentKarachiAddress sk, StudentPermanentAddress sp, StudentQawaif sq, StudentRihaish srh 
                                    where sd.activeIndex = 1 AND
                                    (sd.dakhlaNumber = sb.dakhlaNumber AND sd.dakhlaNumber = fd.dakhlaNumber
                                    AND(sd.dakhlaNumber = dr.dakhlaNumber AND dr.activeInd = 1)
                                    AND sd.dakhlaNumber = sk.dakhlaNumber
                                    AND sd.dakhlaNumber = sp.dakhlaNumber AND sd.dakhlaNumber = sq.dakhlaNumber
                                    AND sd.dakhlaNumber = srh.dakhlaNumber) ORDER BY sd.dakhlaNumber;");
            }
            else
            {
                getAllActiveQuery = string.Format(@"select * from StudentDakhlaNumber sd, StudentBasicInfo sb, StudentFormDate fd, StudentDarjaRecord dr,
                                    StudentKarachiAddress sk, StudentPermanentAddress sp, StudentQawaif sq, StudentRihaish srh 
                                    where sd.activeIndex = 0 AND
                                    (sd.dakhlaNumber = sb.dakhlaNumber AND sd.dakhlaNumber = fd.dakhlaNumber
                                    AND(sd.dakhlaNumber = dr.dakhlaNumber AND dr.activeInd = 1)
                                    AND sd.dakhlaNumber = sk.dakhlaNumber
                                    AND sd.dakhlaNumber = sp.dakhlaNumber AND sd.dakhlaNumber = sq.dakhlaNumber
                                    AND sd.dakhlaNumber = srh.dakhlaNumber) ORDER BY sd.dakhlaNumber;");
            }
            List<Student> studentList = new List<Student>();
            using (sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand getAllCommand = new SqlCommand(getAllActiveQuery, sqlConnection);
                    var reader = getAllCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Student student = new Student();

                        student.StudentDakhlaNumber.DakhlaNumber = reader.GetInt32(0);
                        student.StudentDakhlaNumber.FormNumber = reader.GetInt32(1);
                        student.StudentDakhlaNumber.ActiveIndex = reader.GetBoolean(2);

                        student.StudentBasicInfo.NameStudent = reader.GetString(4);
                        student.StudentBasicInfo.FatherNameStudent = reader.GetString(5);
                        student.StudentBasicInfo.SurName = reader.GetString(6);
                        student.StudentBasicInfo.DobStudent = reader.GetDateTime(7).Date;
                        if (reader[8] != System.DBNull.Value)
                        {
                            student.StudentBasicInfo.ImageStudent = (Byte[])(reader[8]);
                        }
                        else
                        {
                            student.StudentBasicInfo.ImageStudent = null;
                        }

                        student.StudentFormDate.TakmeelDakhlaDate = reader.GetString(10);
                        student.StudentFormDate.IkhrajDate = reader.GetString(11);


                        student.StudentDarjaRecord.SchoolDarja = reader.GetString(14);
                        student.StudentDarjaRecord.Quraniadarja = reader.GetString(15);
                        student.StudentDarjaRecord.YearSchool = reader.GetString(16);
                        student.StudentDarjaRecord.ActiveInd = reader.GetBoolean(17);
                        student.StudentDarjaRecord.YearQurania = reader.GetString(18);

                        student.StudentKarachiAddress.HouseNumber = reader.GetString(20);
                        student.StudentKarachiAddress.SectorNumber = reader.GetString(21);
                        student.StudentKarachiAddress.BlockNumber = reader.GetString(22);
                        student.StudentKarachiAddress.Area = reader.GetString(23);

                        student.StudentPermanentAddress.Zila = reader.GetString(25);
                        student.StudentPermanentAddress.Tehseel = reader.GetString(26);
                        student.StudentPermanentAddress.DakKhana = reader.GetString(27);
                        student.StudentPermanentAddress.Village = reader.GetString(28);

                        student.StudentQawaif.Qurania = reader.GetString(30);
                        student.StudentQawaif.LastQuraniaIdara = reader.GetString(31);
                        student.StudentQawaif.LastAsriTaleemIdara = reader.GetString(32);
                        student.StudentQawaif.AsriTaleem = reader.GetString(33);

                        student.StudentImdadi.Imdadi = reader.GetBoolean(35);

                        string getGuardianInfo = "select guardianInfoId, nameGuardian, contactGuardian, relationGuardian, cnicGuardian, isPrimary from StudentGuardianInfo where dakhlaNumber = @dakhlaNumber";

                        SqlCommand getGuardianInfoCommand = new SqlCommand(getGuardianInfo, sqlConnection);
                        getGuardianInfoCommand.Parameters.AddWithValue("@dakhlaNumber", student.StudentDakhlaNumber.DakhlaNumber);
                        var reader1 = getGuardianInfoCommand.ExecuteReader();

                        while (reader1.Read())
                        {
                            StudentGuardianInfo studentGuardianInfo = new StudentGuardianInfo();
                            studentGuardianInfo.GuardianInfoId = reader1.GetInt32(0);
                            studentGuardianInfo.NameGuardian = reader1.GetString(1);
                            studentGuardianInfo.ContactGuardian = reader1.GetString(2);
                            studentGuardianInfo.RelationGuardian = reader1.GetString(3);
                            studentGuardianInfo.CnicGuardian = reader1.GetString(4);
                            studentGuardianInfo.IsPrimary = reader1.GetBoolean(5);

                            student.StudentGuardianInfo.Add(studentGuardianInfo);

                        }
                        
                        studentList.Add(student);
                    }
                    return studentList;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                return studentList;
            }
        }

        public static Boolean deleteStudent(List<string> dakhlaNumbers)
        {
            bool result = false;
            string queryDelete = "update StudentDakhlaNumber set activeIndex = 0 where dakhlaNumber in ( ";
            foreach (string dakhlaNumber in dakhlaNumbers)
            {
                queryDelete += dakhlaNumber + ", ";
            }
            queryDelete = queryDelete.Remove(queryDelete.Length - 2);
            queryDelete += ")";

            using (sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand deleteCommand = new SqlCommand(queryDelete, sqlConnection);
                    deleteCommand.ExecuteNonQuery();
                    MessageBox.Show("Students deleted Successfully");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString() + "\n Students not deleted successfully");
                }
            }
            return result;
        }

        public static void addStudentGuardianInfo(StudentGuardianInfo guardianInfo)
        {
            try
            {
                int guardianId = getGuardianInfoId();
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    string queryInsertGuardianInfo = "insert into StudentGuardianInfo(guardianInfoId, dakhlaNumber, cnicGuardian, nameGuardian, relationGuardian, contactGuardian, isPrimary) values(@guardianInfoId, @dakhlaNumber, @cnicGuardian, @nameGuardian, @relationGuardian, @contactGuardian, @isPrimary)";
                    try
                    {
                        sqlConnection.Open();
                        SqlCommand getGuardianInfoCommand = new SqlCommand(queryInsertGuardianInfo, sqlConnection);
                        getGuardianInfoCommand.Parameters.AddWithValue("@guardianInfoId", guardianId);
                        getGuardianInfoCommand.Parameters.AddWithValue("@dakhlaNumber", guardianInfo.DakhlaNumber);
                        getGuardianInfoCommand.Parameters.AddWithValue("@cnicGuardian", guardianInfo.CnicGuardian);
                        getGuardianInfoCommand.Parameters.AddWithValue("@nameGuardian", guardianInfo.NameGuardian);
                        getGuardianInfoCommand.Parameters.AddWithValue("@relationGuardian", guardianInfo.RelationGuardian);
                        getGuardianInfoCommand.Parameters.AddWithValue("@contactGuardian", guardianInfo.ContactGuardian);
                        getGuardianInfoCommand.Parameters.AddWithValue("@isPrimary", 0);

                        getGuardianInfoCommand.ExecuteNonQuery();

                        MessageBox.Show("Data inserted");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Data failed to insert");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public static List<StudentDarjaRecord> getDarjaOfStudent(int regNum)
        {
            List<StudentDarjaRecord> studentDarjaRecords = new List<StudentDarjaRecord>();
            using (sqlConnection = new SqlConnection(connectionString))
            {
                string queryGetDarjaRecord = "select schoolDarja, quraniaDarja, yearSchool, yearQurania, activeInd from StudentDarjaRecord where dakhlaNumber = @dakhlaNumber";
                try
                {
                    sqlConnection.Open();
                    SqlCommand getDarjaRecordCommand = new SqlCommand(queryGetDarjaRecord, sqlConnection);
                    getDarjaRecordCommand.Parameters.AddWithValue("@dakhlaNumber", regNum);
                    SqlDataReader reader2 = getDarjaRecordCommand.ExecuteReader();
                    while (reader2.Read())
                    {
                        StudentDarjaRecord darjaRecord = new StudentDarjaRecord();
                        darjaRecord.SchoolDarja = reader2.GetString(0);
                        darjaRecord.Quraniadarja = reader2.GetString(1);
                        darjaRecord.YearSchool = reader2.GetString(2);
                        darjaRecord.YearQurania = reader2.GetString(3);
                        darjaRecord.ActiveInd = reader2.GetBoolean(4);
                        studentDarjaRecords.Add(darjaRecord);
                    }
                    reader2.Close();
                        
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return studentDarjaRecords;
        }


        public static void deleteDarjaStudent(StudentDarjaRecord darjaRecord)
        {
            string queryDelete = "update StudentDarjaRecord set activeInd = 0 where dakhlaNumber = @dakhlaNumber AND schoolDarja = @schoolDarja AND quraniaDarja = @quraniaDarja AND yearSchool = @yearSchool AND yearQurania = @yearQurania";
            
            using (sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand deleteCommand = new SqlCommand(queryDelete, sqlConnection);
                    deleteCommand.Parameters.AddWithValue("@dakhlaNumber",darjaRecord.DakhlaNumber);
                    deleteCommand.Parameters.AddWithValue("@schoolDarja",darjaRecord.SchoolDarja);
                    deleteCommand.Parameters.AddWithValue("@quraniaDarja",darjaRecord.Quraniadarja);
                    deleteCommand.Parameters.AddWithValue("@yearSchool",darjaRecord.YearSchool);
                    deleteCommand.Parameters.AddWithValue("@yearQurania",darjaRecord.YearQurania);

                    deleteCommand.ExecuteNonQuery();
                    MessageBox.Show("Students Darja Successfully");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString() + "\n Student Darja not deleted successfully");
                }
            }
        }

        public static void addNewDarja(StudentDarjaRecord newDarjaRecord)
        {
            try
            {
                int darjaId = getDarjaRecordId();
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    string queryStudentDarjaRecord = "insert into StudentDarjaRecord(darjaRecordId, dakhlaNumber, schoolDarja, quraniaDarja, yearSchool, activeInd, yearQurania) values(@darjaRecordId, @dakhlaNumber, @schoolDarja, @quraniaDarja, @yearSchool, @activeInd, @yearQurania)";

                    try
                    {
                        sqlConnection.Open();
                        SqlCommand insertDarjaRecord = new SqlCommand(queryStudentDarjaRecord, sqlConnection);
                        insertDarjaRecord.Parameters.AddWithValue("@darjaRecordId", darjaId);
                        insertDarjaRecord.Parameters.AddWithValue("@dakhlaNumber", newDarjaRecord.DakhlaNumber);
                        insertDarjaRecord.Parameters.AddWithValue("@schoolDarja", newDarjaRecord.SchoolDarja);
                        insertDarjaRecord.Parameters.AddWithValue("@quraniaDarja", newDarjaRecord.Quraniadarja);
                        insertDarjaRecord.Parameters.AddWithValue("@yearSchool", newDarjaRecord.YearSchool);
                        insertDarjaRecord.Parameters.AddWithValue("@activeInd", 1);
                        insertDarjaRecord.Parameters.AddWithValue("@yearQurania", newDarjaRecord.YearQurania);
                        insertDarjaRecord.ExecuteNonQuery();

                        MessageBox.Show("Darja Record inserted");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Darja Record failed to insert");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void addNewBook(int bookNumber, int firstSlip, int lastSlip)
        {
            try
            {
                int receiptBookId = getBookNumberId();
                int bookSequence = getNextBookSequence();
                int lastSlipOfPreviousBook = getLastSlipOfBookUsingBookSequence(bookSequence - 1);
                if((firstSlip-lastSlipOfPreviousBook) == 1)
                {
                    using (sqlConnection = new SqlConnection(connectionString))
                    {
                        string queryBookNumberRecord = "insert into ReceiptBook(receiptBookId, bookNumber, firstSlip, lastSlip, lastUsedSlip, activeInd, isDone, bookSequence) values(@receiptBookId, @bookNumber, @firstSlip, @lastSlip, @lastUsedSlip, @activeInd, @isDone, @bookSequence)";
                        int lastUsedSlip = firstSlip - 1;
                        try
                        {
                            sqlConnection.Open();
                            SqlCommand insertBookRecord = new SqlCommand(queryBookNumberRecord, sqlConnection);
                            insertBookRecord.Parameters.AddWithValue("@receiptBookId", receiptBookId);
                            insertBookRecord.Parameters.AddWithValue("@bookNumber", bookNumber);
                            insertBookRecord.Parameters.AddWithValue("@firstSlip", firstSlip);
                            insertBookRecord.Parameters.AddWithValue("@lastSlip", lastSlip);
                            insertBookRecord.Parameters.AddWithValue("@lastUsedSlip", lastUsedSlip);
                            insertBookRecord.Parameters.AddWithValue("@activeInd", 0);
                            insertBookRecord.Parameters.AddWithValue("@isDone", 0);
                            insertBookRecord.Parameters.AddWithValue("@bookSequence", bookSequence);
                            insertBookRecord.ExecuteNonQuery();

                            MessageBox.Show("Receipt Book inserted");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Receipt Book failed to insert");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Sequence didnot match. Insertion failed.");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        public static List<String> getAllReceiptBooks()
        {
            List<String> allReceiptBooks = new List<string>();
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    string queryGetAllBookNumber = "select bookNumber from ReceiptBook where bookNumber <> 0 ORDER BY bookSequence";
                    try
                    {
                        sqlConnection.Open();
                        SqlCommand getFormNumberCommand = new SqlCommand(queryGetAllBookNumber, sqlConnection);
                        SqlDataReader reader = getFormNumberCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            allReceiptBooks.Add(reader[0].ToString());
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return allReceiptBooks;
        }

        public static List<string> getActiveReceiptBook()
        {
            List<string> activeReceiptBookInfo = new List<string>();
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    string queryGetAllBookNumber = "select top 1 bookNumber, firstSlip, lastSlip, lastUsedSlip from ReceiptBook where activeInd = 1";
                    try
                    {
                        sqlConnection.Open();
                        SqlCommand getFormNumberCommand = new SqlCommand(queryGetAllBookNumber, sqlConnection);
                        SqlDataReader reader = getFormNumberCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            activeReceiptBookInfo.Add(reader[0].ToString());
                            activeReceiptBookInfo.Add(reader[1].ToString());
                            activeReceiptBookInfo.Add(reader[2].ToString());
                            activeReceiptBookInfo.Add(reader[3].ToString());

                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return activeReceiptBookInfo;
        }

        public static List<string> getSpecificBookInfoUsingBookNumber(int bookNumber)
        {
            List<string> getBookInfo = new List<string>();
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    string queryGetBookInfo = "select firstSlip, lastSlip from ReceiptBook where bookNumber = @bookNumber";
                    try
                    {
                        sqlConnection.Open();
                        SqlCommand getBookInfoCommand = new SqlCommand(queryGetBookInfo, sqlConnection);
                        getBookInfoCommand.Parameters.AddWithValue("@bookNumber", bookNumber);
                        SqlDataReader reader = getBookInfoCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            getBookInfo.Add(reader[0].ToString());
                            getBookInfo.Add(reader[1].ToString());

                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return getBookInfo;
        }

        public static List<string> getOtherTypeReceiptRecord(string slipNumber)
        {
            List<string> otherTypeRecord = new List<string>();
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    string queryGetOtherTypeReceiptInfo = "select transactionId, slipNumber, 'otherTransaction', transactionDate, transactionAmount, transactionYear from MajmaTransaction where slipNumber = @slipNumber";
                    try
                    {
                        sqlConnection.Open();
                        SqlCommand getOtherTypeInfoCommand = new SqlCommand(queryGetOtherTypeReceiptInfo, sqlConnection);
                        getOtherTypeInfoCommand.Parameters.AddWithValue("@slipNumber", slipNumber);
                        SqlDataReader reader = getOtherTypeInfoCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            otherTypeRecord.Add(reader[0].ToString());
                            otherTypeRecord.Add(reader[1].ToString());
                            otherTypeRecord.Add(reader[2].ToString());
                            otherTypeRecord.Add(reader[3].ToString());
                            otherTypeRecord.Add(reader[4].ToString());
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return otherTypeRecord;
        }

        public static List<List<string>> getStudentTypeReceiptRecord(string slipNumber)
        {
            List<List<string>> studentTypeRecords = new List<List<string>>();
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    string queryGetStudentTypeReceiptInfo = "select studentFeeId, slipNumber, 'studentFee' , studentFeeDate, studentFee, studentFeeYear, studentFeeType, studentFeeMonth from StudentFee where slipNumber = @slipNumber";
                    try
                    {
                        sqlConnection.Open();
                        SqlCommand getStudentTypeInfoCommand = new SqlCommand(queryGetStudentTypeReceiptInfo, sqlConnection);
                        getStudentTypeInfoCommand.Parameters.AddWithValue("@slipNumber", slipNumber);
                        SqlDataReader reader = getStudentTypeInfoCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            List<string> studentTypeRecord = new List<string>();
                            studentTypeRecord.Add(reader[0].ToString());
                            studentTypeRecord.Add(reader[1].ToString());
                            studentTypeRecord.Add(reader[2].ToString());
                            studentTypeRecord.Add(reader[3].ToString());
                            studentTypeRecord.Add(reader[4].ToString());
                            studentTypeRecord.Add(reader[5].ToString());
                            studentTypeRecord.Add(reader[6].ToString());
                            studentTypeRecord.Add(reader[7].ToString());

                            studentTypeRecords.Add(studentTypeRecord);
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return studentTypeRecords;
        }

        public static void updateOtherTypeReceiptRecord(double transactionAmount, string transactionYear, string slipNumber)
        {
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    string updateOtherTypeRecord = "Update MajmaTransaction SET transactionAmount = @transactionAmount, transactionYear = @transactionYear WHERE slipNumber = @slipNumber";
                    try
                    {
                        sqlConnection.Open();
                        SqlCommand updateOtherTypeRecordCommand = new SqlCommand(updateOtherTypeRecord, sqlConnection);
                        updateOtherTypeRecordCommand.Parameters.AddWithValue("@slipNumber", slipNumber);
                        updateOtherTypeRecordCommand.Parameters.AddWithValue("@transactionAmount", transactionAmount);
                        updateOtherTypeRecordCommand.Parameters.AddWithValue("@transactionYear", transactionYear);
                        updateOtherTypeRecordCommand.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void updateFeeRecord(double amount, string month, string type, int id, string year)
        {
            try
            {
                string updateRecord;
                DateTime studentFeeMonthDate = new DateTime(Int32.Parse(year), (int)monthNumber[month], 1);
                if (type.Equals("OTHER"))
                {
                    updateRecord = "Update MajmaTransaction SET transactionAmount = @transactionAmount WHERE transactionId = @transactionId";
                }
                else
                {
                    updateRecord = "Update StudentFee SET studentFee = @studentFee, studentFeeMonth = @studentFeeMonth, studentFeeMonthDate = @studentFeeMonthDate WHERE studentFeeId = @studentFeeId";
                }

                using (sqlConnection = new SqlConnection(connectionString))
                {
                    try
                    {
                        sqlConnection.Open();
                        SqlCommand updateRecordCommand = new SqlCommand(updateRecord, sqlConnection);
                        if(type.Equals("OTHER"))
                        {
                            updateRecordCommand.Parameters.AddWithValue("@transactionId", id);
                            updateRecordCommand.Parameters.AddWithValue("@transactionAmount", amount);
                        }
                        else
                        {
                            updateRecordCommand.Parameters.AddWithValue("@studentFeeId", id);
                            updateRecordCommand.Parameters.AddWithValue("@studentFee", amount);
                            updateRecordCommand.Parameters.AddWithValue("@studentFeeMonth", month);
                            updateRecordCommand.Parameters.AddWithValue("@studentFeeMonthDate", studentFeeMonthDate);
                        }
                        updateRecordCommand.ExecuteNonQuery();

                        MessageBox.Show("فیس اپڈیٹ ہو گئی ہے۔");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void updateTransaction(string slipNumber)
        {
            try
            {
                string updateRecord = "UPDATE MajmaTransaction SET transactionAmount = (SELECT SUM(studentFee) from StudentFee where slipNumber = @slipNumber) where slipNumber = @slipNumber";
                

                using (sqlConnection = new SqlConnection(connectionString))
                {
                    try
                    {
                        sqlConnection.Open();
                        SqlCommand updateRecordCommand = new SqlCommand(updateRecord, sqlConnection);
                        updateRecordCommand.Parameters.AddWithValue("@slipNumber", slipNumber);
                       
                        updateRecordCommand.ExecuteNonQuery();
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static int getLastSlipOfBookUsingBookSequence(int bookSequence)
        {
            int lastSlip = Int32.MaxValue;
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    string queryGetLastSlip = "select lastSlip from ReceiptBook where bookSequence = @bookSequence";
                    try
                    {
                        sqlConnection.Open();
                        SqlCommand getGetLastSlipCommand = new SqlCommand(queryGetLastSlip, sqlConnection);
                        getGetLastSlipCommand.Parameters.AddWithValue("@bookSequence", bookSequence);
                        SqlDataReader reader = getGetLastSlipCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            lastSlip = Convert.ToInt32(reader[0]);
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return lastSlip;
        }

        public static void updateBook(int bookNumber, int firstSlip, int lastSlip)
        {
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    string queryUpdateBook = "update ReceiptBook set firstSlip = @firstSlip, lastSlip = @lastSlip, lastUsedSlip = @lastUsedSlip where bookNumber = @bookNumber AND activeInd = 0";
                    int lastUsedSlip = firstSlip - 1;
                    try
                    {
                        sqlConnection.Open();
                        SqlCommand updateBookRecord = new SqlCommand(queryUpdateBook, sqlConnection);
                        updateBookRecord.Parameters.AddWithValue("@bookNumber", bookNumber);
                        updateBookRecord.Parameters.AddWithValue("@firstSlip", firstSlip);
                        updateBookRecord.Parameters.AddWithValue("@lastSlip", lastSlip);
                        updateBookRecord.Parameters.AddWithValue("@lastUsedSlip", lastUsedSlip);
                        updateBookRecord.ExecuteNonQuery();

                        MessageBox.Show("Receipt book updated");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Receipt book failed to update");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void checkReceiptBook()
        {
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    try
                    {
                        sqlConnection.Open();
                        SqlCommand checkReceiptBookProd = new SqlCommand("checkReceiptRecord", sqlConnection);
                        checkReceiptBookProd.CommandType = CommandType.StoredProcedure;
                        checkReceiptBookProd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static int getReceiptNumber()
        {
            int receiptNumber = Int32.MaxValue;
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    string queryGetReceiptNumber = "select lastUsedSlip+1 from ReceiptBook where activeInd = 1";
                    try
                    {
                        sqlConnection.Open();
                        SqlCommand getReceiptNumberCommand = new SqlCommand(queryGetReceiptNumber, sqlConnection);
                        SqlDataReader reader2 = getReceiptNumberCommand.ExecuteReader();
                        while (reader2.Read())
                        {
                            receiptNumber = Convert.ToInt32(reader2[0]);
                        }
                        reader2.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return receiptNumber;
        }

        public static List<List<string>> getFeeRecord(int dakhlaNumber)
        {
            List<List<string>> feeRecords = new List<List<string>>();
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    string queryGetFeeRecord = "select slipNumber, studentFeeDate, studentFeeMonth, studentFee, studentFeeYear, studentFeeType from StudentFee where dakhlaNumber = @dakhlaNumber";
                    try
                    {
                        sqlConnection.Open();
                        SqlCommand getFeeRecordCommand = new SqlCommand(queryGetFeeRecord, sqlConnection);
                        getFeeRecordCommand.Parameters.AddWithValue("@dakhlaNumber", dakhlaNumber);
                        SqlDataReader reader2 = getFeeRecordCommand.ExecuteReader();
                        while (reader2.Read())
                        {
                            List<string> feeRecord = new List<string>();
                            feeRecord.Add(reader2[0].ToString());
                            feeRecord.Add(reader2[1].ToString());
                            feeRecord.Add(reader2[2].ToString());
                            feeRecord.Add(reader2[3].ToString());
                            feeRecord.Add(reader2[4].ToString());
                            feeRecord.Add(reader2[5].ToString());

                            feeRecords.Add(feeRecord);
                        }
                        reader2.Close();
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return feeRecords;
        }

        public static void doTransaction(string transactionYear, 
            double transactionAmount, 
            string slipNumber, 
            string transactionType, 
            string transactionDate)
        {
            int transactionId = getTransactionId();
            DateTime transactionDateTemp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            string queryTransaction = "insert into MajmaTransaction(transactionId, slipNumber, transactionType, transactionDate, transactionAmount, transactionYear, transactionDateTemp) values(@transactionId, @slipNumber, @transactionType, @transactionDate, @transactionAmount, @transactionYear, @transactionDateTemp)";
            string queryUpdateSlip = "update ReceiptBook set lastUsedSlip = lastUsedSlip+1 where activeInd = 1";
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    try
                    {
                        sqlConnection.Open();

                        sqlTransaction = sqlConnection.BeginTransaction();

                        SqlCommand insertTransaction = new SqlCommand(queryTransaction, sqlConnection, sqlTransaction);
                        insertTransaction.Parameters.AddWithValue("@transactionId", transactionId);
                        insertTransaction.Parameters.AddWithValue("@slipNumber", slipNumber);
                        insertTransaction.Parameters.AddWithValue("@transactionType", transactionType);
                        insertTransaction.Parameters.AddWithValue("@transactionDate", transactionDate);
                        insertTransaction.Parameters.AddWithValue("@transactionAmount", transactionAmount);
                        insertTransaction.Parameters.AddWithValue("@transactionYear", transactionYear);
                        insertTransaction.Parameters.AddWithValue("@transactionDateTemp", transactionDateTemp);
                        insertTransaction.ExecuteNonQuery();

                        SqlCommand updateReceipt = new SqlCommand(queryUpdateSlip, sqlConnection, sqlTransaction);
                        updateReceipt.ExecuteNonQuery();

                        sqlTransaction.Commit();

                        sqlConnection.Close();

                        MessageBox.Show("Transaction done");
                    }
                    catch (Exception ex)
                    {
                        sqlTransaction.Rollback();
                        MessageBox.Show("Transaction failed");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //public static void updateReceipt()
        //{
        //    string queryUpdateSlip = "update ReceiptBook set lastUsedSlip = lastUsedSlip+1 where activeInd = 1";
        //    try
        //    {
        //        using (sqlConnection = new SqlConnection(connectionString))
        //        {
        //            try
        //            {
        //                sqlConnection.Open();
        //                SqlCommand updateReceiptCommand = new SqlCommand(queryUpdateSlip, sqlConnection);
        //                updateReceiptCommand.ExecuteNonQuery();
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.ToString());
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        public static Boolean submitMonthlyfee(string studentFeeMonth, 
            double monthlyFee,
            string studentFeeYear,
            string slipNumber,
            string studentFeeType,
            string studentFeeDate,
            int dakhlaNumber)
        {
            Boolean status = false;
            int studentFeeId = getStudentFeeId();
            int transactionId = getTransactionId();
            DateTime monthDate = new DateTime(Int32.Parse(studentFeeYear), (int)monthNumber[studentFeeMonth], 1);
            string queryStudentFeeId = "insert into StudentFee(studentFeeId, studentFeeType, studentFeeYear, studentFeeMonth, dakhlaNumber, studentFeeDate, slipNumber, studentFee, studentFeeMonthDate) values(@studentFeeId, @studentFeeType, @studentFeeYear, @studentFeeMonth, @dakhlaNumber, @studentFeeDate, @slipNumber, @studentFee, @studentFeeMonthDate)";
            //string queryTransaction = "insert into MajmaTransaction(transactionId, slipNumber, transactionType, transactionDate, transactionAmount, transactionYear) values(@transactionId, @slipNumber, @transactionType, @transactionDate, @transactionAmount, @transactionYear)";
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    try
                    {
                        sqlConnection.Open();

                        //sqlTransaction = sqlConnection.BeginTransaction();

                        SqlCommand insertStudentFee = new SqlCommand(queryStudentFeeId, sqlConnection);
                        insertStudentFee.Parameters.AddWithValue("@studentFeeId", studentFeeId);
                        insertStudentFee.Parameters.AddWithValue("@studentFeeType", studentFeeType);
                        insertStudentFee.Parameters.AddWithValue("@studentFeeYear", studentFeeYear);
                        insertStudentFee.Parameters.AddWithValue("@studentFeeMonth", studentFeeMonth);
                        insertStudentFee.Parameters.AddWithValue("@dakhlaNumber", dakhlaNumber);
                        insertStudentFee.Parameters.AddWithValue("@studentFeeDate", studentFeeDate);
                        insertStudentFee.Parameters.AddWithValue("@slipNumber", slipNumber);
                        insertStudentFee.Parameters.AddWithValue("@studentFee", monthlyFee);
                        insertStudentFee.Parameters.AddWithValue("@studentFeeMonthDate", monthDate);
                        insertStudentFee.ExecuteNonQuery();

                        //SqlCommand insertTransaction = new SqlCommand(queryTransaction, sqlConnection, sqlTransaction);
                        //insertTransaction.Parameters.AddWithValue("@transactionId", transactionId);
                        //insertTransaction.Parameters.AddWithValue("@slipNumber", slipNumber);
                        //insertTransaction.Parameters.AddWithValue("@transactionType", studentFeeType);
                        //insertTransaction.Parameters.AddWithValue("@transactionDate", studentFeeDate);
                        //insertTransaction.Parameters.AddWithValue("@transactionAmount", monthlyFee);
                        //insertTransaction.Parameters.AddWithValue("@transactionYear", studentFeeYear);
                        //insertTransaction.ExecuteNonQuery();

                        //sqlTransaction.Commit();

                        sqlConnection.Close();

                        status = true;
                    }
                    catch (Exception ex)
                    {
                        status = false;
                        //sqlTransaction.Rollback();
                        MessageBox.Show(ex.ToString());
                        //MessageBox.Show("Transaction failed");
                    }
                }
            }
            catch (Exception ex)
            {
                status = false;
                MessageBox.Show(ex.ToString());
            }
            return status;
        }

        public static List<List<string>> getBookRecords(int bookNumber)
        {
            List<List<string>> bookRecords = new List<List<string>>();
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    StringBuilder queryGetBookRecord = new StringBuilder("SELECT distinct mt.* , sf.dakhlaNumber, " +
                        "STUFF((SELECT distinct ',' + sf1.[StudentFeeType] FROM StudentFee sf1 where sf.slipNumber = sf1.slipNumber " +
                        "FOR XML PATH(''), TYPE).value ('.', 'NVARCHAR(MAX)'), 1, 1,'') feeType, " +
                        "STUFF((SELECT distinct ',' + sf2.[studentFeeMonth] FROM StudentFee sf2 where sf.slipNumber = sf2.slipNumber " +
                        "FOR XML PATH(''), TYPE).value ('.', 'NVARCHAR(MAX)'), 1, 1,'') feeMonth " +
                        "FROM MajmaTransaction mt LEFT JOIN StudentFee sf " +
                        "ON mt.slipNumber = sf.slipNumber " +
                        "WHERE mt.slipNumber between " +
                        "( SELECT firstSlip from ReceiptBook WHERE bookNumber = @bookNumber) " +
                        "AND ( SELECT lastSlip from ReceiptBook WHERE bookNumber = @bookNumber) "
                        );
                    try
                    {
                        sqlConnection.Open();
                        SqlCommand getFeeBookCommand = new SqlCommand(queryGetBookRecord.ToString(), sqlConnection);
                        getFeeBookCommand.Parameters.AddWithValue("@bookNumber", bookNumber);
                        SqlDataReader reader2 = getFeeBookCommand.ExecuteReader();
                        while (reader2.Read())
                        {
                            List<string> BookRecord = new List<string>();
                            BookRecord.Add(reader2[1].ToString());
                            BookRecord.Add(reader2[2].ToString());
                            BookRecord.Add(reader2[3].ToString());
                            BookRecord.Add(reader2[4].ToString());
                            BookRecord.Add(reader2[5].ToString());
                            BookRecord.Add(reader2[7].ToString());
                            BookRecord.Add(reader2[8].ToString());
                            BookRecord.Add(reader2[9].ToString());

                            bookRecords.Add(BookRecord);
                        }
                        reader2.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return bookRecords;
        }

        //public static List<String> getDakhlaNumbers(string regNumber)
        //{
        //    List<String> dakhlaNumbers = new List<String>();
        //    try
        //    {
        //        using (sqlConnection = new SqlConnection(connectionString))
        //        {
        //            string queryGetDakhlaNumber = "select dakhlaNumber from StudentDakhlaNumber where registrationNumber = @regNumber AND activeIndex = 0";
        //            sqlConnection.Open();
        //            SqlCommand getDakhlaNumberCommand = new SqlCommand(queryGetDakhlaNumber, sqlConnection);
        //            getDakhlaNumberCommand.Parameters.AddWithValue("@regNumber", regNumber);
        //            SqlDataReader reader2 = getDakhlaNumberCommand.ExecuteReader();
        //            while (reader2.Read())
        //            {
        //                dakhlaNumbers.Add(reader2[0].ToString());
        //            }
        //            reader2.Close();
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    return dakhlaNumbers;
        //}

        public static void backUpDatabase()
        {
            try
            {
                var backUpDatabasePath = ConfigurationManager.AppSettings["BackUpDatabasePath"];
                var backupFileName = String.Format("{0}-{1}.bak", backUpDatabasePath, DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss"));
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    var backupQuery = String.Format("BACKUP DATABASE MajmaUloomUlIslamia TO DISK='{0}'", backupFileName);
                    sqlConnection.Open();
                    SqlCommand backupQueryCommand = new SqlCommand(backupQuery, sqlConnection);
                    backupQueryCommand.ExecuteNonQuery();
                    MessageBox.Show("Backup Completed Successfully");
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
