using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PRSPretestLibrary.Model {
    public class Request {

        public int Id { get; set; }
        public string Description { get; set; }
        public string Justification { get; set; }
        public string RejectionReason { get; set; }
        [DefaultValue("Pickup")]
        public string DeliveryMode { get; set; }
        [DefaultValue("NEW")]
        public string Status { get; set; }
        [DefaultValue (0)]
        public decimal Total { get; set; }
        public int UserId { get; set; }
      
        public virtual User User { get; set; }

        public virtual List<RequestLine> RequestLines { get; set; } //tells ef not to create a column in table but return info of requestlines

        public override string ToString() => $"{Id}/{Description}/{Justification}/{RejectionReason}/{DeliveryMode}/{Status}/{Total}/{UserId}";

        public  Request() { }

    }
}
