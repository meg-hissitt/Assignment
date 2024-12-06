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


    }
}



