// <copyright file="BuyingHistory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OnlineShop.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("BuyingHistory")]
    public class BuyingHistory
    {

        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}
