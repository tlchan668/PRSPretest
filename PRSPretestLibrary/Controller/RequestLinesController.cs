using Microsoft.EntityFrameworkCore;
using PRSPretestLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PRSPretestLibrary.Controller {
    public class RequestLinesController {

        private AppDbContext context = new AppDbContext();

        private void RecalcRequestTotal(int requestId) {
            //go through each line with request id 
            //to display the number of lines in collect == count 
            //needs to be in the maintenace functions add, changing or deleting line

            var req =  context.Requests.Find(requestId);
            req.Total= req.RequestLines.Sum(x=>x.Quantity*x.Product.Price);
            Console.WriteLine(req.Total);
            //another way
            /*var total = context.Requestlines.where(rl => rl.requestId == request.Id)
             *                                .sum(rl=>rl.quantity * rl.Product.price);*/
           context.SaveChanges();

        }
        

        public List<RequestLine> GetAllRequestslinees() {
            var rl = context.Requestlines.ToList();
            foreach (var x in rl) {
                Console.WriteLine(x);
            }
            return (rl);
        }
        public RequestLine GetRequestbyPK(int id) {
            if (id < 1) throw new Exception("Id must be greater than zero");
            return context.Requestlines.Find(id);
        }
        public RequestLine Insert(RequestLine rl) {

            if (rl == null) throw new Exception("requestline cannot be null");

            context.Requestlines.Add(rl);
            try {
                context.SaveChanges();//trap exception for a dup code by doing a try catch
                RecalcRequestTotal(rl.RequestId);
            } catch (DbUpdateException ex) {
                //if get it what will we do
                throw new Exception("Requestline incomplete", ex);
            } catch (Exception ex) {
                throw;
            }
            return rl;//system has updated the Id that is now assigned so pass back user   
        }

        public bool Update(int id, RequestLine rl) {
            //do so only updating the one you want
            if (rl == null) throw new Exception("requestline cannot be null");
            if (id != rl.Id) throw new Exception("Id and requestline.Id must match");

            context.Entry(rl).State = EntityState.Modified;//tells state that it is an update not add

            try {
                context.SaveChanges();//trap exception for a dup vendor by doing a try catch
                RecalcRequestTotal(rl.RequestId);
            } catch (DbUpdateException ex) {
                //if get it what will we do
                throw new Exception("requestline must be unique", ex);
                //give developer the origianl exception thrown by doing ex above
            } catch (Exception ex) {
                throw;
            }
            return true;
        }
        public bool Delete(int id) {
            if (id <= 0) throw new Exception("Id must be greater than zero");
            var rl = context.Requestlines.Find(id);
            return Delete(rl);
        }
        //overload delete
        public bool Delete(RequestLine rl) {
            context.Requestlines.Remove(rl);
            context.SaveChanges();
            RecalcRequestTotal(rl.RequestId);
            return true;
        }


        public RequestLinesController() { }
    }
}
