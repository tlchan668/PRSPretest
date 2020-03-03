using PRSPretestLibrary.Model;
using PRSPretestLibrary;
using System;
using System.Linq;
using System.Collections.Generic;
using PRSPretestLibrary.Controller;

namespace PRSPretest {
    class Program {
        static void Main(string[] args) {
            //login
            var UserCtrl = new UserController();
            var RequestCtrl = new RequestController();
           /* 
            var user = UserCtrl.Login("user1", "password");
            Console.WriteLine(  user);
            Request r4 = RequestCtrl.GetRequestbyPK(4);
            var success = RequestCtrl.SetToReview(r4);
            Request r6 = RequestCtrl.GetRequestbyPK(6);
            success = RequestCtrl.SetToReview(r6);
            success = RequestCtrl.SetToApproved(r6);
            Request r7 = RequestCtrl.GetRequestbyPK(7);
            success = RequestCtrl.SetToRejected(r7);
            */
            //List<Request> requests = RequestCtrl.GetRequeststoReviewNotOwn(4).ToList();
            //

        




            //bool success = RequestCtrl.SetToApproved()

            /*
            var rlctrl = new RequestLinesController();
            List<RequestLine> rl = rlctrl.GetAllRequestslinees();
            var rl1 = rlctrl.GetRequestbyPK(3);
            Console.WriteLine(rl1);
            var newrl= new RequestLine {
                 RequestId =7, ProductId = 3, Quantity=3
            };
            var rl2 = rlctrl.Insert(newrl);
            rl1.Quantity = 21;
            var s = rlctrl.Update(3, rl1);
            rl = rlctrl.GetAllRequestslinees();
            s = rlctrl.Delete(3);
            rl= rlctrl.GetAllRequestslinees();
            */
            //var RequestCtrl = new RequestController();
            //List<Request> Requests = RequestCtrl.GetAllRequests();
            //var req1 = RequestCtrl.GetRequestbyPK(4);
            //Console.WriteLine(req1);
            //var newReq = new Request {
            //    Description = "fffff", Justification = "justification", DeliveryMode="mail", Status="new",Total=0, UserId=3
            //};
            //var req2 = RequestCtrl.Insert(newReq);
            //Requests = RequestCtrl.GetAllRequests();
            //req2.Description = "ooooo";
            //var s = RequestCtrl.Update(8,req2);
            //Requests = RequestCtrl.GetAllRequests();
            //s = RequestCtrl.Delete(8);
            //Requests = RequestCtrl.GetAllRequests();


            /*
            var ProdCtrl = new ProductController();

            var newProd = new Product {
                Id = 4, PartNbr = "12Egg", Name = "Eggs", Price = 2, Unit = "Dozen", VendorId = 4
            };
            List<Product> products = ProdCtrl.GetAllProducts();
            var prod1 = ProdCtrl.GetProductbyPK(1);
            Console.WriteLine(prod1);
            //var prod2 = ProdCtrl.Insert(newProd);
            //List<Product> products2 = ProdCtrl.GetAllProducts();
            var prod2 = ProdCtrl.GetProductbyPK(4);
            prod2.Name = "Pancakes";
            var success = ProdCtrl.Update(4, prod2);
            if (success)
                ProdCtrl.GetAllProducts();
            success = ProdCtrl.Delete(4);
            if (success)
                ProdCtrl.GetAllProducts();

            */

            /*var VendorCtrl = new VendorController();

            var newVendor = new Vendor {

                Code = "7", Name = "Target", Address = "123 here", City = "Mason", State = "OH", Zip = "45111", Phone = "123", Email = "Targggget"

            };

            List<Vendor> vendors = VendorCtrl.GetAllVendors();
            var vendor1 = VendorCtrl.GetVendorbyPK(3);
            Console.WriteLine(vendor1);
            vendor1 = VendorCtrl.Insert(newVendor);
            vendors = VendorCtrl.GetAllVendors();
            vendor1.Name = "Kmart";
            var success = VendorCtrl.Update(10, newVendor);
            if (success)
                vendors = VendorCtrl.GetAllVendors();
            success = VendorCtrl.Delete(10);
            if (success)
                vendors = VendorCtrl.GetAllVendors();
*/
            /*
             
             var UserCtrl = new UserController();

            var newUser = new User {
                Username = "user1", Password = "password", Firstname = "firstname", Lastname = "lastname", Phone = "phone", Email = "email", IsReviewer = true, IsAdmin = false
            };
           var success = UserCtrl.AddUser(newUser);
            if (success) Console.WriteLine("yes");
            List<User> users = UserCtrl.GetAllUsers();
            var user6 = UserCtrl.GetUserByPK(6);
            user6.Firstname = "Leia";
            success = UserCtrl.UpdateUser(user6);
            if (success) 
              Console.WriteLine("yes update");
            success = UserCtrl.DeleteUser(8);
            if (success) Console.WriteLine("yes");
            */
        }


    }
}
