using System;

namespace Domain
{
    public class User
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }
    }
}
