using System;
using System.Collections.Generic;
using System.Linq;

namespace RWA_MI1_IvanKozul_2RP1
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string City { get; set; }
        public string Role { get; set; }

        public override string ToString()
        {
            return $"{ID}, {Name}, {Surname}, {Password}, {Phone}, {Email}, {Email2}, {Email3}, {City}, {Role}";
        }

        public string GetPersonAsFileString()
        {
            return $"{ID}|{Name}|{Surname}|{Password}|{Phone}|{Email}|{Email2}|{Email3}|{City}|{Role}";
        }
    }
}