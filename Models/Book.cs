using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BooksOnLoan.Models;

public class Book
{
    [Key]
    public int CodeNumber { get; set; }

    public string Author { get; set; } = null!;

    public string Title { get; set; } = null!;

    public int YearPublished { get; set; }

    public int Quantity { get; set; }
}
