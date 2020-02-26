using PRSPretestLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRSPretestLibrary {
    public class UserController {

        private AppDbContext context = new AppDbContext(); //create an instance of context or could be put in constructor

        public List<User> GetAllUsers() {
            var users = context.Users.ToList();//this uses linq to read data
            foreach (var u in users) {
                Console.WriteLine(u);//overidden the to string function in both class
            }
            return (users);
        }

        public User GetUserByPK(int userid) {
            var user = context.Users.Find(userid);
            if (user == null) throw new Exception("Order not found");
            Console.WriteLine(user);
            return (user);
        }
        
          public bool AddUser(User user){
            context.Users.Add(user);//modifies collection but not the db
            var rowsAffected = context.SaveChanges();//alters db
            if (rowsAffected == 0) {
                return false;
                throw new Exception("Add User failed!");
            }
            return true;
        }
        public bool DeleteUser(int userid) {
            var user = context.Users.Find(userid);
            if (user == null) {
                return false;
                throw new Exception("User not found");
            }
            context.Users.Remove(user);
            var rowsAffected = context.SaveChanges();
            return true;
            if (rowsAffected != 1) throw new Exception("Delete failed!");

        }
        public bool UpdateCustomer(int userPK) {
            //var userPK = 2;
            //read for data see if there before change
            var user = context.Users.Find(userPK);
            if (user == null) throw new Exception("Cust not found");
            user.Firstname = "Target";
            var rowsAffected = context.SaveChanges();
            if (rowsAffected != 1) {
                return false;
                throw new Exception("Failed to update user");
            }
            Console.WriteLine("update successfull");
            return true;
        }

        public UserController() { }
    }
}
