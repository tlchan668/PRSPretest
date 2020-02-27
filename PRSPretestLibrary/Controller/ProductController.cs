using Microsoft.EntityFrameworkCore;
using PRSPretestLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRSPretestLibrary.Controller {
    public class ProductController {

        private AppDbContext context = new AppDbContext();

        public List<Product> GetAllProducts() {
            var products = context.Products.ToList();//this uses linq to read data
            foreach (var u in products) {
                Console.WriteLine(u);//overidden the to string function in both class
            }
            return (products);
        }
        public Product GetProductbyPK(int id) {
            if (id < 1) throw new Exception("Id must be greater than zero");
            return context.Products.Find(id);
        }
        public Product Insert(Product product) {
            
            if (product == null) throw new Exception("product cannot be null");
            
            context.Products.Add(product);
            try {
                context.SaveChanges();//trap exception for a dup code by doing a try catch
            } catch (DbUpdateException ex) {
                //if get it what will we do
                throw new Exception("Product incomplete", ex);
            } catch (Exception ex) {
                throw;
            }
            return product;//system has updated the Id that is now assigned so pass back user   
        }

        public bool Update(int id, Product product) {
            //do so only updating the one you want
            if (product == null) throw new Exception("product cannot be null");
            if (id != product.Id) throw new Exception("Id and product.Id must match");

            context.Entry(product).State = EntityState.Modified;//tells state that it is an update not add

            try {
                context.SaveChanges();//trap exception for a dup vendor by doing a try catch
            } catch (DbUpdateException ex) {
                //if get it what will we do
                throw new Exception("product must be unique", ex);
                //give developer the origianl exception thrown by doing ex above
            } catch (Exception ex) {
                throw;
            }
            return true;
        }
        public bool Delete(int id) {
            if (id <= 0) throw new Exception("Id must be greater than zero");
            var product = context.Products.Find(id);
            return Delete(product);
        }
        //overload delete
        public bool Delete(Product product) {
            context.Products.Remove(product);
            context.SaveChanges();
            return true;
        }

        public ProductController() { }
    }
}
