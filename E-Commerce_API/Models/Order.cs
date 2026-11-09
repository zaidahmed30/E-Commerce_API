using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Models;

[Index("UserId", Name = "IX_Orders_UserId")]
[Index("OrderNumber", Name = "UQ__Orders__CAC5E7431A6CE10D", IsUnique = true)]
public partial class Order
{
    [Key]
    public long Id { get; set; }

    [StringLength(50)]
    public string OrderNumber { get; set; } = null!;

    public long UserId { get; set; }

    public long AddressId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal TotalAmount { get; set; }

    [StringLength(50)]
    public string Status { get; set; } = null!;

    public DateTime CreatedAtUtc { get; set; }

    [ForeignKey("AddressId")]
    [InverseProperty("Orders")]
    public virtual Address Address { get; set; } = null!;

    [InverseProperty("Order")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    [ForeignKey("UserId")]
    [InverseProperty("Orders")]
    public virtual User User { get; set; } = null!;
}
