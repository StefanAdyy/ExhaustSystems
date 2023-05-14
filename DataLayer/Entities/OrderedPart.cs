using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class OrderedPart
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int PartID { get; set; }

        [ForeignKey(nameof(OrderID))]
        public Order Order { get; set; }

        [ForeignKey(nameof(PartID))]
        public Part Part { get; set; }
    }
}
