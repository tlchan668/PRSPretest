using Microsoft.EntityFrameworkCore;
using PRSPretestLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRSPretestLibrary.Controller {
    public class RequestController {

        public const string StatusNew = "NEW";
        public const string StatusEdit = "EDIT";
        public const string StatusReview = "REVIEW";
        public const string StatusApproved = "APPROVED";
        public const string StatusRejected = "REJECTED";

        private AppDbContext context = new AppDbContext();

        public IEnumerable<Request> GetRequeststoReviewNotOwn(int userId) {
            return context.Requests
                .Where(x => x.UserId != userId && x.Status == StatusReview).ToList();
        }

        public bool SetToReview(Request request) {
            if (request.Total <= 50) {
                request.Status = StatusApproved;
            } else {
                request.Status = StatusReview;
            }
            return Update(request.Id, request);
        }
        public bool SetToApproved(Request request) {
            request.Status = StatusApproved;
            return Update(request.Id, request);
        }
        public bool SetToRejected(Request request) {
            request.Status = StatusRejected;
            return Update(request.Id, request);
        }
         
            

        public List<Request> GetAllRequests() {
            var request = context.Requests.ToList();//this uses linq to read data
            foreach (var x in request) {
                Console.WriteLine(x);
            }
            return (request);
        }
        public Request GetRequestbyPK(int id) {
            if (id < 1) throw new Exception("Id must be greater than zero");
            return context.Requests.Find(id);
        }
        public Request Insert(Request request) {

            if (request == null) throw new Exception("request cannot be null");

            context.Requests.Add(request);
            try {
                context.SaveChanges();//trap exception for a dup code by doing a try catch
            } catch (DbUpdateException ex) {
                //if get it what will we do
                throw new Exception("Request incomplete", ex);
            } catch (Exception ex) {
                throw;
            }
            return request;//system has updated the Id that is now assigned so pass back user   
        }

        public bool Update(int id, Request  request) {
            //do so only updating the one you want
            if (request == null) throw new Exception("request cannot be null");
            if (id != request.Id) throw new Exception("Id and request.Id must match");

            context.Entry(request).State = EntityState.Modified;//tells state that it is an update not add

            try {
                context.SaveChanges();//trap exception for a dup vendor by doing a try catch
            } catch (DbUpdateException ex) {
                //if get it what will we do
                throw new Exception("request must be unique", ex);
                //give developer the origianl exception thrown by doing ex above
            } catch (Exception ex) {
                throw;
            }
            return true;
        }
        public bool Delete(int id) {
            if (id <= 0) throw new Exception("Id must be greater than zero");
            var request = context.Requests.Find(id);
            return Delete(request);
        }
        //overload delete
        public bool Delete(Request request) {
            context.Requests.Remove(request);
            context.SaveChanges();
            return true;
        }

        public RequestController() { }
    }

}
