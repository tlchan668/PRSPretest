using Microsoft.EntityFrameworkCore;
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
        public IEnumerable<User> GetAll() {//Gregs way
            //ienumerable encompases list --ienumerable can do a for each allows you to iterate through and can be an array or list but don't have to change more flexible
            return context.Users.ToList();
        }
        public User GetUserByPK(int userid) {
            var user = context.Users.Find(userid);
            if (user == null) throw new Exception("User not found");
            Console.WriteLine(user);
            return user;
        }
        public User GetByPk(int id) {//gregs way
            if (id < 1) throw new Exception("Id must be greater than zero");
            return context.Users.Find(id);
            
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
        #region gregs insert
        public User Insert(User user) {//gregs way
            //if user is null will give an error if try to check
            if (user == null) throw new Exception("User cannot be null");
            //need to check for null and make sure not more than characters
            context.Users.Add(user);
            try {
                context.SaveChanges();//trap exception for a dup username by doing a try catch
            }catch(DbUpdateException ex) {
                //if get it what will we do
                throw new Exception("Username must be unique", ex);
                //give developer the origianl exception thrown by doing ex above
            }catch (Exception ex) {
                throw;
            }
            return user;//system has updated the Id that is now assigned so pass back user   
        }
        #endregion
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
        public bool Delete(int id) {//gregs way
            if (id <= 0) throw new Exception("Id must be greater than zero");
            var user = context.Users.Find(id);
            return Delete(user);
        }
        //overload delete
        public bool Delete (User user) {
            context.Users.Remove(user);
            context.SaveChanges();
            return true;
        }
        public bool UpdateUser(User updateduser) {
            
            //read for data see if there before change
            var user = context.Users.Find(updateduser.Id);
            if (user == null) throw new Exception("User not found");
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
        public bool Update(int id, User user) {//gregs way pass user instance and primary key
            //do so only updating the one you want
            if (user == null) throw new Exception("User cannot be null");
            if (id != user.Id) throw new Exception("Id and User.Id must match");
            
            //see it this way when generated
            //want to add to collection but want EF to know it is an update not an add
            context.Entry(user).State = EntityState.Modified;//tells state that it is an update not add
            //alternative is to do what did above by reading from the db and setting the values
            try {
                context.SaveChanges();//trap exception for a dup username by doing a try catch
            } catch (DbUpdateException ex) {
                //if get it what will we do
                throw new Exception("Username must be unique", ex);
                //give developer the origianl exception thrown by doing ex above
            } catch (Exception ex) {
                throw;
            }
            return true;
        }

        public UserController() { }
    }
}
