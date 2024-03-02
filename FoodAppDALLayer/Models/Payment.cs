using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppDALLayer.Models
{
    public class Payment
    {
        [Key,Required] 
        public int PaymentId { get; set; }
        [Required]
        public string PaymentType { get; set; }
        [Required]
        public int RestId { get; set; }
        [ForeignKey("RestId")]
        public virtual Restaurant Restaurant { get; set; }
        [Required]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
        [Required, DataType(DataType.Currency)]
        public decimal TotalAmount { get; set; }
        [Required]
        public int PaymentStatus { get; set; }
        

    }
}
