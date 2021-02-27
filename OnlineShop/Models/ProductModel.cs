using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

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
        [Column("Name")]
        public string Name { get; set; }

        [Required]
        [Column("Price", TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }

        [Required]
        [Column("Count")]
        public int Count { get; set; }

        [Column("Description")]
        public string Description { get; set; }

    }
}