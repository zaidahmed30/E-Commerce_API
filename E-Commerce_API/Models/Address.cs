using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Models;

[Index("UserId", Name = "IX_Addresses_UserId")]
public partial class Address
{
    [Key]
    public long Id { get; set; }

    public long UserId { get; set; }

    [StringLength(255)]
    public string AddressLine { get; set; } = null!;

    [StringLength(100)]
    public string City { get; set; } = null!;

    [StringLength(100)]
    public string State { get; set; } = null!;

    [StringLength(20)]
    public string PostalCode { get; set; } = null!;

    [StringLength(20)]
    public string Phone { get; set; } = null!;

    [InverseProperty("Address")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [ForeignKey("UserId")]
    [InverseProperty("Addresses")]
    public virtual User User { get; set; } = null!;
}
