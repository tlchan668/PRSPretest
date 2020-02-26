using PRSPretestLibrary.Model;
using PRSPretestLibrary;
using System;
using System.Linq;

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
           // var success = UserCtrl.AddUser(newUser);
            //if (success) Console.WriteLine("yes");
            var users = UserCtrl.GetAllUsers();
            var user = UserCtrl.GetUserByPK(6);
            newUser.Firstname = "Leia";
            var success = UserCtrl.UpdateCustomer(6);
            if (success) Console.WriteLine("yes update");
            //success = UserCtrl.DeleteUser(8);
            //if (success) Console.WriteLine("yes");
        }
        static void test() { 
            var context = new AppDbContext();



            // AddUser(context);
            // AddVendor(context);
            GetAllUsers(context);;
            GetUserByPK(context, 2);
            UpdateCustomer(context);
            GetAllUsers(context);
            DeleteUser(context, 2);
            AddUser(context);
            GetAllUsers(context);

        }
        static void GetAllUsers(AppDbContext context) {
            var users = context.Users.ToList();//this uses linq to read data
            foreach (var u in users) {
                Console.WriteLine(u);//overidden the to string function in both class
            }
        }
        static void GetUserByPK(AppDbContext context, int userid) {
            var user = context.Users.Find(userid);
            if (user == null) throw new Exception("User not found");
            Console.WriteLine(user);
        }
        static void AddUser(AppDbContext context) {
            var user = new User {
                Id = 0, Username = "Superuser", Password = "password", Firstname = "Traci", Lastname = "Chan", Phone = "123", Email = "tchan", IsReviewer = true, IsAdmin = true
            };

            context.Users.Add(user);//modifies collection but not the db
            var rowsAffected = context.SaveChanges();//alters db
            if (rowsAffected == 0) throw new Exception("Add User failed!");
            return;
        }
        static void DeleteUser(AppDbContext context, int userid) {
            var user = context.Users.Find(userid);
            if (user == null) throw new Exception("User not found");
            context.Users.Remove(user);
            var rowsAffected = context.SaveChanges();
            if (rowsAffected != 1) throw new Exception("Delete failed!");

        }
        static void UpdateCustomer(AppDbContext context) {
            var userPK = 2;
            //read for data see if there before change
            var user = context.Users.Find(userPK);
            if (user == null) throw new Exception("Cust not found");
            user.Firstname = "Target";
            var rowsAffected = context.SaveChanges();
            if (rowsAffected != 1) throw new Exception("Failed to update user");
            Console.WriteLine("update successfull");
        }

        static void AddVendor(AppDbContext context) {
            var vendor = new Vendor {
                Id = 0, Code = "1", Name = "Amazon", Address = "123 here", City = "Mason", State = "OH", Zip = "45111", Phone = "123", Email = "amazonamzon"
            };
            context.Vendors.Add(vendor);
            var rowsAffected = context.SaveChanges();//alters db
            if (rowsAffected == 0) throw new Exception("Add User failed!");
            return;
        }
    }
}
