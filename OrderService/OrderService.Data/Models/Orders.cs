using System;
using System.Collections.Generic;

namespace OrderService.Data.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public long OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }
        public string SpecialNotes { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
