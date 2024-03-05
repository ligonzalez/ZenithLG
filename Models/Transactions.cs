using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace BooksOnLoan.Models;

public class Transactions
{
    [Key]
    [Column(Order = 1)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    public string AspNetUserId { get; set; }
    public int Quantity { get; set; }
    public DateTime CheckoutDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public int CodeNumber { get; set; }

    // Foreing Keys
    [ForeignKey("CodeNumber")]
    public Book? Book { get; set; }
}
