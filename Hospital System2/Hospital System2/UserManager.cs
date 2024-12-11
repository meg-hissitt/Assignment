using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using static Hospital_System2.Program;

namespace Hospital_System2
{
    class UserManager
    {
        private List<Staff> _staffs;
        public List<Staff> StaffMembers
        {
            get
            {
                if (_staffs == null)
                {
                    _staffs = LoadStaffMembers();
                }
                return _staffs;
            }
            set
            {

            }
        }
        private List<Patient> _patients;
        public List<Patient> Patients
        {
            get
            {
                if (_patients == null) { _patients = LoadPatients(); }
                return _patients;
            }
            set
            {
            }

        }
        public List<Staff> LoadStaffMembers()
        {
            List<Staff> staffList = new List<Staff>();
            if (File.Exists(@"users.json"))
            {
                string json = File.ReadAllText(@"users.json");
                staffList = JsonConvert.DeserializeObject<List<Staff>>(json);
            }

            return staffList;
        }

        public List<Patient> LoadPatients()
        {
            List<Patient> patientList = new List<Patient>();
            if (File.Exists(@"patients.json"))
            {
                string json = File.ReadAllText(@"patients.json");
                patientList = JsonConvert.DeserializeObject<List<Patient>>(json);
            }

            return patientList;
        }

        public Staff Login()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            foreach (var user in StaffMembers)
            {
                if (user.Email == username && user.Password == password)
                {
                    return user;
                }
            }
            return null;

        }
        void SavePatients(List<Patient> users)
        {
            string json = JsonConvert.SerializeObject(users);
            File.WriteAllText(@"patients.json", json);
        }
        public void PatientRegister()
        {
            Console.Write("Enter patients first and last name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the Date of Birth: ");
            string DoB = Console.ReadLine();

            Console.Write("Enter the patient number: ");
            string patientID = Console.ReadLine();

            Console.WriteLine("Select role:");
            Console.WriteLine("1. Patient");
            Console.Write("Choice: ");
            int roleChoice = int.Parse(Console.ReadLine());

            Patient newUser = new Patient { Name = name, DoB = DoB, PatientID = patientID };
            Patients.Add(newUser);
            SavePatients(Patients);

        }
        void SaveStaff(List<Staff> users)
        {
            string json = JsonConvert.SerializeObject(users);
            File.WriteAllText(@"users.json", json);
        }
        public void RegisterStaff()
        {
            Console.Write("Enter staff name: ");
            string staffName = Console.ReadLine();

            Console.Write("Enter staff number: ");
            string staffNumber = Console.ReadLine();

            Console.Write("Enter staff email: ");
            string staffEmail = Console.ReadLine();

            Console.Write("Create a password: ");
            string staffPassword = Console.ReadLine();

            Console.WriteLine("Select role:");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Nurse");
            Console.WriteLine("3. Doctor");
            Console.Write("Choice: ");
            int roleChoice = int.Parse(Console.ReadLine());
            Role staffRole = roleChoice switch
            {
                1 => Role.Admin,
                2 => Role.Nurse,
                3 => Role.Doctor,
            };

            Staff newStaff = new Staff { Name = staffName, StaffNumber = staffNumber, Email = staffEmail, Password = staffPassword, StaffRole = staffRole };
            StaffMembers.Add(newStaff);
            SaveStaff(StaffMembers);
        }
        public void PatientSearch(String search)
        {

            foreach (var patient in Patients)
            {
                if (patient.Name == search || patient.DoB == search || patient.PatientID == search)
                {
                    Console.WriteLine(patient.Name);
                }
            }
        }
    }
}
