using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Models;

[Index("CartId", Name = "IX_CartItems_CartId")]
[Index("CartId", "ProductId", Name = "UQ_Cart_Product", IsUnique = true)]
public partial class CartItem
{
    [Key]
    public long Id { get; set; }

    public long CartId { get; set; }

    public long ProductId { get; set; }

    public int Quantity { get; set; }

    [ForeignKey("CartId")]
    [InverseProperty("CartItems")]
    public virtual Cart Cart { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("CartItems")]
    public virtual Product Product { get; set; } = null!;
}
