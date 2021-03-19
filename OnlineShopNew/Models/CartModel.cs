using OnlineShop.Data;
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
        public CartModel() { }

        [Key]
        [Column("Id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("FK_User_Id")]
        [Column("UserId")]
        [Required]
        public string UserId { get; set; }

        public OnlineShopUser User { get; set; }

        [ForeignKey("FK_Product_Id")]
        [Column("ProductId")]
        [Required]
        public int ProductId { get; set; }
        
        public ProductModel Product { get; set; }
        
        [Column("Count")]
        [Range(1, 99)]
        public int Count { get; set; }
    }
}
