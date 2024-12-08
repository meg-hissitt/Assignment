namespace Hospital_System2
{
    using Newtonsoft.Json;
    using System;

    class Program
    {
        public class Patient
        {
            //can rename classes by rightclicking them to rename them everywhere
            //create doctor/nurse/admin role and number(or other) them to select within them - made staff class + added role enum
            //if statements for what they can do 
            public string Username { get; set; }
            public string Password { get; set; }
            public string Name { get; set; }
            public string PatientID { get; set; }
            public string DoB { get; set; }

        }

        string usersFilePath = @"users.json";
        public static void Main(string[] args)
        {
            UserManager uman = new UserManager();

            uman.LoadUsers();

            bool running = true;
            while (running)
            {
                //Console.Clear();
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.Write("What would you like to do? ");
                //Console.WriteLine("Reset password"); - replace the register option with this 

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    uman.Login();
                }
                else if (choice == "2")
                {
                    uman.Register();
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            
            }
        }

        private static void userActions (Staff user)
        {
            switch (user.StaffRole)
            {
                case Role.Admin:
                    Console.WriteLine("1. View all patients");
                    Console.WriteLine("2. Search");
                    Console.WriteLine("3. Add new patient");
                    Console.WriteLine("4. Add new staff member");
                    Console.WriteLine("5. Update user");
                    Console.Write("Select a choice:");
                    string adminChoice = Console.ReadLine();
                    break;
                case Role.Doctor:
                    Console.WriteLine("1. View All patients");
                    Console.WriteLine("2. Search");
                    Console.WriteLine("3. Add appointment");
                    string doctorChoice = Console.ReadLine();
                    break;
                case Role.Nurse:
                    Console.WriteLine("1. Add new patient");
                    Console.WriteLine("2. View All patients");
                    Console.WriteLine("3. Search");
                    Console.WriteLine("4. Add appointment");
                    string nurseChoice = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Role not recognized.");
                    break;
            }
        }

    }


}




