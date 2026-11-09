using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Models;

[Index("UserId", Name = "UQ__Carts__1788CC4D6CF1B3E8", IsUnique = true)]
public partial class Cart
{
    [Key]
    public long Id { get; set; }

    public long? UserId { get; set; }

    public DateTime CreatedAtUtc { get; set; }

    public DateTime? UpdatedAtUtc { get; set; }

    [InverseProperty("Cart")]
    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    [ForeignKey("UserId")]
    [InverseProperty("Cart")]
    public virtual User? User { get; set; }
}
