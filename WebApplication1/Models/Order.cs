using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models;

public class Order
{
    [Column("orderdate")]
    public DateTime OrderDate { get; set; } // Map to `orderdate`

    public int Id { get; set; }

    [Required]
    public string UserId { get; set; }

    public DateTime CreateDate { get; set; } = DateTime.UtcNow;


    [Column("OrderPrice")]
    public decimal? OrderPrice { get; set; } // Map to `OrderPrice`

    public bool? IsDeleted { get; set; } = false;

    [Required]
    [EmailAddress]
    [MaxLength(30)]
    public string? Email { get; set; }

    [Required]
    public string? MobileNumber { get; set; }

    [Required]
    [MaxLength(200)]
    public string? Address { get; set; }

    [Required]
    [MaxLength(30)]
    public string? PaymentMethod { get; set; }

    public bool? IsPaid { get; set; }

    [Column("orderstate")]
    public string? OrderState { get; set; } // Map to `orderstate`

    public IEnumerable<OrderItem> Items { get; set; }
}
