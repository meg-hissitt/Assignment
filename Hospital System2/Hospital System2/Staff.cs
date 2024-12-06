using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_System2
{
    enum Role
    {
        Admin,
        Nurse,
        Doctor
    }
    internal class Staff
    {
        public string Name { get; set; }
        public string StaffNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role StaffRole { get; set; }
    }
}

