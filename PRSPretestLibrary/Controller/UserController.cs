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
            return users;
        }

        public User GetUserByPK(int userid) {
            var user = context.Users.Find(userid);
            if (user == null) throw new Exception("User not found");
            Console.WriteLine(user);
            return user;
        }
        
        public bool AddUser(User user){
            //null check for username, password,firstname,lastname
            if ((user.Username ==null) || (user.Password == null) || (user.Firstname== null)  || (user.Lastname == null)) {
                return false;
            }
            //check to make sure no other username
            List<User> checkUsers = GetAllUsers();
            foreach(var u in checkUsers) {
                if(u.Username == user.Username) {
                    //already used
                    return false;
                }
            }
            context.Users.Add(user);//modifies collection but not the db
            var rowsAffected = context.SaveChanges();//alters db
            if (rowsAffected == 0) {
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
        public bool UpdateUser(User updateduser) {
            
            //read for data see if there before change
            var user = context.Users.Find(updateduser.Id);
            if (user == null) throw new Exception("Cust not found");
            user.Password = updateduser.Password;
            user.Firstname = updateduser.Firstname;
            user.Lastname = updateduser.Lastname;
            user.Phone = updateduser.Phone;
            user.Email = updateduser.Email;
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
