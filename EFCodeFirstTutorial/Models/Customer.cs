﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCodeFirstTutorial.Models {
    public class Customer { 
        
        public int Id { get; set; } //primarykey
        [StringLength(10), Required]
        public string Code { get; set; } //Must be unique value
        [StringLength(50), Required]
        public string Name { get; set; }
        public bool Isnational { get; set; }
        [Column(TypeName = "decimal(9,2)")]
        public decimal Sales { get; set; }
        public DateTime Created { get; set; }

        public Customer() { }



    }
}


