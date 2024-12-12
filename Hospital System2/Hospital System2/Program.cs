namespace Hospital_System2
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.Design;
    using System.Runtime.CompilerServices;
    using static Hospital_System2.UserManager;
    // login for testing - username = admin@patientsystem.com & password = Hello1234
    class Program
    {
        private static Staff CurrentUser = null;

        string usersFilePath = @"users.json";
        public static void Main(string[] args)
        {
            UserManager uman = new UserManager();

            

            bool running = true;
            while (running)
            {
                
                Console.Clear();
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Exit");
                Console.Write("Select a menu option:  ");
             
                string choice = Console.ReadLine();



                if (choice == "1")
                {
                    CurrentUser = uman.Login();
                    if (CurrentUser != null)
                    {
                        Console.WriteLine("Login success.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid username or password.");
                    }
                }
                else if (choice == "2")
                {
                    running = false;
                    CurrentUser = null;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }

                while(CurrentUser != null)
                {
                    UserActions(CurrentUser);
                }
            }
        }

        private static void UserActions (Staff user)
             
        {
            UserManager uman = new UserManager();

            switch (user.StaffRole)
            {
                case Role.Admin:
                    Console.WriteLine("1. View all patients");
                    Console.WriteLine("2. Search");
                    Console.WriteLine("3. Add new patient");
                    Console.WriteLine("4. Add new staff member");
                    Console.WriteLine("5. View all staff members");
                    Console.Write("Select a choice:");
                    
                    string adminChoice = Console.ReadLine();

                    if (adminChoice == "1")
                    {
                        if (File.Exists("patients.json"))
                        {
                            string jsonString = File.ReadAllText("patients.json");
                            List<Patient> patients = JsonConvert.DeserializeObject<List<Patient>>(jsonString).ToList();

                            foreach (Patient patient in patients)
                            {
                                Console.WriteLine($"Patient name: {patient.Name}");
                            }
                        }
                    }
                    else if (adminChoice == "2")
                    {
                        Console.WriteLine("Enter a name, date of birth or patient number");
                        string search = Console.ReadLine();
                        uman.PatientSearch(search);
                    }
                    else if (adminChoice == "3")
                    {
                        uman.PatientRegister();
                    }
                    else if (adminChoice == "4")
                    {
                        uman.StaffRegister();
                    }
                    else if (adminChoice == "5")
                    {
                        if (File.Exists("users.json"))
                        {
                            string jsonString = File.ReadAllText("users.json");
                            List<Staff> staffs = JsonConvert.DeserializeObject<List<Staff>>(jsonString).ToList();

                            foreach (Staff staff in staffs)
                            {
                                Console.WriteLine($"Patient name: {staff.Name}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid option");
                    }

                    break;
                case Role.Doctor:
                    Console.WriteLine("1. View All patients");
                    Console.WriteLine("2. Search");
                    Console.WriteLine("3. Add appointment");
                    Console.WriteLine("4. View patient records");

                    string doctorChoice = Console.ReadLine();

                    if (doctorChoice == "1")
                    {
                        if (File.Exists("patients.json"))
                        {
                            string jsonString = File.ReadAllText("patients.json");
                            List<Patient> patients = JsonConvert.DeserializeObject<List<Patient>>(jsonString).ToList();

                            foreach (Patient patient in patients)
                            {
                                Console.WriteLine($"Patient name: {patient.Name}");
                            }
                        }
                    }
                    else if (doctorChoice == "2")
                    {
                        Console.WriteLine("Enter a name, date of birth or patient number");
                        string search = Console.ReadLine();
                        uman.PatientSearch(search);
                    }
                    else if (doctorChoice == "3")
                    {
                        Console.Write("");
                    }
                    else if (doctorChoice == "4")
                    {
                        if (File.Exists("patients.json"))
                        {
                            string jsonString = File.ReadAllText("patients.json");
                            List<Patient> patients = JsonConvert.DeserializeObject<List<Patient>>(jsonString).ToList();

                            foreach (Patient patient in patients)
                            {
                                Console.WriteLine($"Patient name: {patient.Name}");
                                Console.WriteLine($"Patient number:{patient.PatientID}");
                                Console.WriteLine($"Patient date of birth: {patient.DoB}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid option");
                    }
                        break;
                case Role.Nurse:
                    Console.WriteLine("1. Add new patient");
                    Console.WriteLine("2. View All patients");
                    Console.WriteLine("3. Search");
                    Console.WriteLine("4. Add appointment");
                    Console.WriteLine("5. View patient records");

                    string nurseChoice = Console.ReadLine();

                    if (nurseChoice == "1")
                    {
                        uman.PatientRegister();
                    }
                    else if (nurseChoice == "2")
                    {
                        if (File.Exists("patients.json"))
                        {
                            string jsonString = File.ReadAllText("patients.json");
                            List<Patient> patients = JsonConvert.DeserializeObject<List<Patient>>(jsonString).ToList();

                            foreach (Patient patient in patients)
                            {
                                Console.WriteLine($"Patient name: {patient.Name}");
                            }
                        }
                    }
                    else if (nurseChoice == "3")
                    {
                        Console.WriteLine("Enter a name, date of birth or patient number");
                        string search = Console.ReadLine();
                        uman.PatientSearch(search);
                    }
                    else if (nurseChoice == "4")
                    {
                        Console.Write("");
                    }
                    else if (nurseChoice == "5")
                    {
                        if (File.Exists("patients.json"))
                        {
                            string jsonString = File.ReadAllText("patients.json");
                            List<Patient> patients = JsonConvert.DeserializeObject<List<Patient>>(jsonString).ToList();

                            foreach (Patient patient in patients)
                            {
                                Console.WriteLine($"Patient name: {patient.Name}");
                                Console.WriteLine($"Patient number:{patient.PatientID}");
                                Console.WriteLine($"Patient date of birth: {patient.DoB}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid option");
                    }

                    break;
                default:
                    Console.WriteLine("Role not recognized.");
                    break;
            }
        }

    }


}




