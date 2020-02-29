using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace OrderService.Data.Models
{
    public partial class OrderDetails
    {
        public long OrderDetailId { get; set; }
        public long OrderId { get; set; }
        public Guid ItemId { get; set; }

        [JsonIgnore]
        public virtual Orders Order { get; set; }
    }
}
