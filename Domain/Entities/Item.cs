using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        public string ItemName { get; set; } = "";
        public string ItemDescription { get; set; } = "";
        public string ItemType { get; set; } = "";
        public DateTime ItemDate { get; set; }

    }
}
