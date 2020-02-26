using PRSPretestLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRSPretestLibrary.Controller {
    public class VendorController {

        private AppDbContext context = new AppDbContext();

        public List<Vendor> GetAllVendors() {
            var vendors = context.Vendors.ToList();//this uses linq to read data
            foreach (var u in vendors) {
                Console.WriteLine(u);//overidden the to string function in both class
            }
            return (vendors);
        }

        public bool AddVendor(Vendor vendor) {
          
            context.Vendors.Add(vendor);
            var rowsAffected = context.SaveChanges();//alters db
            if (rowsAffected == 0) throw new Exception("Add User failed!");
            return true;
        }

        public VendorController() { }
    }
}
