using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase
{
    public static class Constraints
    {
        public class Patient
        {
            public const int PatientFirstName = 50;
            public const int PatientLastName = 50;
            public const int Address = 250;
            public const int Email = 80;
        }
        public class Visitation
        {
            public const int Comments = 250;
        }
        public class Diagnose
        {
            public const int Name = 50;
            public const int Comments = 250;
        }
        public class Medicament
        {
            public const int Name = 50;
        }
    }
}
