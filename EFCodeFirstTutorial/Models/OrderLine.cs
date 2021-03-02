using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCodeFirstTutorial.Models {
    public class OrderLine {

        public int Id { get; set; }
        
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
        
        public int Quantity { get; set; }

        public OrderLine() { }
    }
}
