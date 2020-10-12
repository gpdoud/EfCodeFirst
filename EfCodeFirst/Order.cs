using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Tracing;
using System.Text;

namespace EfCodeFirst {
    
    public class Order {

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(11,2)")]
        public decimal Total { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public Order() { }
    }
}
