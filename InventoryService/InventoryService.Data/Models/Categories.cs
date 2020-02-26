using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace InventoryService.Data.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Items = new HashSet<Items>();
        }

        public long CategoryId { get; set; }
        public string CategoryName { get; set; }

        [JsonIgnore]
        public ICollection<Items> Items { get; set; }
    }
}
