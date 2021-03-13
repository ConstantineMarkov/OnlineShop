using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{

    [Table("Cart")]
    public class CartModel
    {
        [Key]
        [Column("Id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("FK_Product_Id")]
        [Column("ProductId")]
        [Required]
        public ProductModel ProductId { get; set; }

        [Column("Count")]
        [Range(1, 99)]
        public int Count { get; set; }
    }
}
