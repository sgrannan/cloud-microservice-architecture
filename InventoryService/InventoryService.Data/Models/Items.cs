using System;
using System.Collections.Generic;

namespace InventoryService.Data.Models
{
    public partial class Items
    {
        public Guid ItemId { get; set; }
        public long CategoryTypeId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public bool? InStock { get; set; }

        public virtual Categories CategoryType { get; set; }
    }
}
