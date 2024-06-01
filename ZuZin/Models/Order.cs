﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ZuZin.Models
{
    [Table("Order")]
    public class Order
    {
        public int? OrderId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }

    }
}

