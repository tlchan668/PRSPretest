﻿using Microsoft.EntityFrameworkCore;
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
        public  Vendor GetVendorbyPK(int id) {
            if (id < 1) throw new Exception("Id must be greater than zero");
            return context.Vendors.Find(id);
        }

        public Vendor Insert( Vendor vendor) {
            //if vendor is null will give an error if try to check
            if (vendor == null) throw new Exception("vendor cannot be null");
            if (vendor.Code.Length > 30 || vendor.Name.Length > 30)
            context.Vendors.Add(vendor);
            try {
                context.SaveChanges();//trap exception for a dup code by doing a try catch
            } catch (DbUpdateException ex) {
                //if get it what will we do
                throw new Exception("code must be unique", ex);
            } catch (Exception ex) {
                throw;
            }
            return vendor;//system has updated the Id that is now assigned so pass back user   
        }
        public bool Update(int id, Vendor vendor) {
            //do so only updating the one you want
            if (vendor == null) throw new Exception("vendor cannot be null");
            if (id != vendor.Id) throw new Exception("Id and User.Id must match");
   
            context.Entry(vendor).State = EntityState.Modified;//tells state that it is an update not add
       
            try {
                context.SaveChanges();//trap exception for a dup vendor by doing a try catch
            } catch (DbUpdateException ex) {
                //if get it what will we do
                throw new Exception("Vendor must be unique", ex);
                //give developer the origianl exception thrown by doing ex above
            } catch (Exception ex) {
                throw;
            }
            return true;
        }
        public bool Delete(int id) {
            if (id <= 0) throw new Exception("Id must be greater than zero");
            var vendor = context.Vendors.Find(id);
            return Delete(vendor);
        }
        //overload delete
        public bool Delete(Vendor vendor) {
            context.Vendors.Remove(vendor);
            context.SaveChanges();
            return true;
        }


        public VendorController() { }
    }
}
