using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json.Serialization;

namespace PRSPretestLibrary.Model {
    public class RequestLine {

        public int Id { get; set; }
        public int RequestId { get; set; }
        public int ProductId { get; set; }
        [DefaultValue(1)]
        public int Quantity { get; set; }

        [JsonIgnore]//dont get request when get orderline
        public virtual Request Request { get; set; }
        
        public virtual Product Product { get; set; }

        

        public override string ToString() => $"{Id}/{RequestId}/ {ProductId}/ {Quantity}: order id {Request.Id}/ prod {Product.Name}";
    }
}


