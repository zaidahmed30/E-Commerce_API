using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Models;

[Index("Email", Name = "UQ__Users__A9D105347A553767", IsUnique = true)]
public partial class User
{
    [Key]
    public long Id { get; set; }

    [StringLength(256)]
    public string Email { get; set; } = null!;

    [StringLength(500)]
    public string PasswordHash { get; set; } = null!;

    [StringLength(150)]
    public string FullName { get; set; } = null!;

    [StringLength(50)]
    public string Role { get; set; } = null!;

    public DateTime CreatedAtUtc { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    [InverseProperty("User")]
    public virtual Cart? Cart { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
