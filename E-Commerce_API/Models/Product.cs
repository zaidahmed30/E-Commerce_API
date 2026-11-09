using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Models;

[Index("CategoryId", Name = "IX_Products_CategoryId")]
[Index("Slug", Name = "UQ__Products__BC7B5FB60983B1AC", IsUnique = true)]
public partial class Product
{
    [Key]
    public long Id { get; set; }

    public int CategoryId { get; set; }

    [StringLength(200)]
    public string Name { get; set; } = null!;

    [StringLength(250)]
    public string Slug { get; set; } = null!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    [StringLength(500)]
    public string? ImageUrl { get; set; }

    public bool IsActive { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category Category { get; set; } = null!;

    [InverseProperty("Product")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
