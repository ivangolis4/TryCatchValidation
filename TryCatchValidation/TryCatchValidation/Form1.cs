using System.Text.RegularExpressions;

namespace TryCatchValidation
{
    public partial class FrmRegistration : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo, _StudentNo;
        bool isValid = true;
        public FrmRegistration()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void FrmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]
            {
                "BS Information Technology",
                "BS Computer Science",
                "BS Information System",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };

            for (int i = 0; i < 6; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i].ToString());
            }

            string[] ListOfGender = new string[]
            {
                "Male",
                "Female",
                "Other",
            };

            for (int i = 0; i < 3; i++)
            {
                cbGender.Items.Add(ListOfGender[i].ToString());
            }
        }

        public long StudentNumber(string studNum)
        {
            try
            {
                _StudentNo = long.Parse(studNum);
            }
            catch (FormatException ex)
            {
                isValid = false;
                MessageBox.Show("Invalid Student Number format: " + ex.Message);
                Console.WriteLine("Invalid Student Number format: " + ex.Message);
            }
            catch (OverflowException ex)
            {
                isValid = false;
                MessageBox.Show("Student Number is too large: " + ex.Message);
                Console.WriteLine("Student Number is too large: " + ex.Message);
            }
            finally
            {
               
            }

            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            try
            {
                if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
                {
                    _ContactNo = long.Parse(Contact);
                }
                else
                {
                    throw new FormatException("Invalid contact number format.");
                    
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                Console.WriteLine("Error: " + ex.Message);
                isValid = false;
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Contact number is too large: " + ex.Message);
                Console.WriteLine("Contact number is too large: " + ex.Message);
                isValid = false;
            }
            finally
            {
                
                Console.WriteLine("ContactNo method execution completed.");
                
            }

            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            try
            {
                if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") &&
                    Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") &&
                    Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
                {
                    _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
                }
                else
                {
                    throw new FormatException("Invalid format in one or more name fields.");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                Console.WriteLine("Error: " + ex.Message);
                isValid = false;
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Null value provided: " + ex.Message);
                Console.WriteLine("Null value provided: " + ex.Message);
                isValid = false;
            }
            finally
            {
                
                Console.WriteLine("FullName method execution completed.");
            }

            return _FullName;
        }

        public int Age(string age)
        {
            try
            {
                if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
                {
                    _Age = int.Parse(age);
                }
                else
                {
                    throw new ArgumentException("Invalid age format");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Age format is incorrect: " + ex.Message);
                Console.WriteLine("Age format is incorrect: " + ex.Message);
                isValid = false;
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Age value is too large: " + ex.Message);
                Console.WriteLine("Age value is too large: " + ex.Message);
                isValid = false;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
                isValid = false;
            }
            finally
            {
               
            }

            return _Age;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            

            try
            {
                StudentInformationClass.SetFullname = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
                StudentInformationClass.SetStudentNo = (int)StudentNumber(txtStudentNumber.Text);
                StudentInformationClass.SetProgram = cbPrograms.Text;
                StudentInformationClass.SetGender = cbGender.Text;
                StudentInformationClass.SetContactNo = (int)ContactNo(txtContactNo.Text);
                StudentInformationClass.SetBirthday = datePickerBirthday.Value.ToString("yyyy-MM-dd");
                StudentInformationClass.SetAge = Age(txtAge.Text);

            }
            catch (FormatException ex)
            {
                isValid = false;
                MessageBox.Show("Error: " + ex.Message);
                Console.WriteLine("Error: " + ex.Message);
            }
            finally 
            {
                Console.WriteLine("btnRegister_Click execution completed.");
            }

            if (isValid)
            {
                frmConfirmation f = new frmConfirmation();
                f.ShowDialog();
            }
            
        }
    }
}
