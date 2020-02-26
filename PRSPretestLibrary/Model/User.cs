using System;
using System.Collections.Generic;
using System.Text;

namespace PRSPretestLibrary.Model {
    public class User {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsReviewer { get; set; }
        public bool IsAdmin { get; set; }

        public User() { }

        public override string ToString() => $"{Id}/{Username}/{Firstname} {Lastname}/{Phone}/{Email}/{IsReviewer}/{IsAdmin}";
    }
}
