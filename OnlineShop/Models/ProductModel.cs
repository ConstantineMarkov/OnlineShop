using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OnlineShop.Models
{
    [Table("Products")]
    public class ProductModel
    {
        [Key]
        [Column("Id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required]
        [Column("Category")]
        public string Category { get; set; }

        [Required]
        [Column("Price")]
        public int Price { get; set; }

        [Required]
        [Column("Count")]
        public int Count { get; set; }

        [Column("Description")]
        public string Description { get; set; }
    }
}
