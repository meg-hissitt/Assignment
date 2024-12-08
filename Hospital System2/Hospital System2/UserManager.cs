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
        public string json { get; set; }
        public void LoadUsers()
        {
            if (File.Exists(@"users.json"))
            {
                json = File.ReadAllText(@"users.json");
            }
            else
            {
                File.Create(@"users.json").Close();
                json = File.ReadAllText(@"users.json");
            }

        }
        public bool Login()
        {
            LoadUsers();
            List<Patient> userList = JsonConvert.DeserializeObject<List<Patient>>(this.json);
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            foreach (var user in userList)
            {
                if (user.Username == username && user.Password == password)
                {
                    Console.WriteLine("Login successfull.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Login unsuccesfull");
                    return false; 
                }
            }
            return false;

        }
        void SaveUsers(List<Patient> users)
        {
            string json = JsonConvert.SerializeObject(users);
            File.WriteAllText(@"users.json", json);
        }
        public void Register()
        {
            Console.Write("Enter your first and last name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your Date of Birth: ");
            string DoB = Console.ReadLine();

            Console.Write("Enter your patient number: ");
            string patientID = Console.ReadLine();

            Console.Write("Create a username: ");
            string username = Console.ReadLine();

            Console.Write("Create a password: ");
            string password = Console.ReadLine();

            Console.WriteLine("Select role:");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Doctor");
            Console.WriteLine("3. Nurse");
            Console.WriteLine("4. Patient");
            Console.Write("Choice: ");
            int roleChoice = int.Parse(Console.ReadLine());

            List<Patient> userList = JsonConvert.DeserializeObject<List<Patient>>(this.json);
            Patient newUser = new Patient {Name = name, DoB = DoB, PatientID = patientID, Username = username, Password = password };
            userList.Add(newUser);
            SaveUsers(userList);

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
            Console.WriteLine("2. Doctor");
            Console.WriteLine("3. Nurse");
            Console.WriteLine("4. Patient");
            Console.Write("Choice: ");
            int roleChoice = int.Parse(Console.ReadLine());

            List<Staff> staffList = JsonConvert.DeserializeObject<List<Staff>>(this.json);
            Staff newStaff = new Staff { Name = staffName,StaffNumber = staffNumber, Email = staffEmail, Password = staffPassword };
            staffList.Add(newStaff);
            SaveStaff(staffList);
        }
    }
}
