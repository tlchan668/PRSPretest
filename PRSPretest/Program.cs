using PRSPretestLibrary.Model;
using PRSPretestLibrary;
using System;
using System.Linq;
using System.Collections.Generic;

namespace PRSPretest {
    class Program {
        static void Main(string[] args) {

            var UserCtrl = new UserController();

            var newVendor = new Vendor {

                Code = "1", Name = "Amazon", Address = "123 here", City = "Mason", State = "OH", Zip = "45111", Phone = "123", Email = "amazonamzon"

            };

            var newUser = new User {
                Username = "user1", Password = "password", Firstname = "firstname", Lastname = "lastname", Phone = "phone", Email = "email", IsReviewer = true, IsAdmin = false
            };
           var success = UserCtrl.AddUser(newUser);
            if (success) Console.WriteLine("yes");
            List<User> users = UserCtrl.GetAllUsers();
            var user6 = UserCtrl.GetUserByPK(6);
            user6.Firstname = "Leia";
            success = UserCtrl.UpdateUser(user6);
            //if (success) 
              //  Console.WriteLine("yes update");
            //success = UserCtrl.DeleteUser(8);
            //if (success) Console.WriteLine("yes");
        }
        
        
    }
}
