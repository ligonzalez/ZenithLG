using Microsoft.AspNetCore.Identity;

namespace BooksOnLoan.Models;

public class CustomUser : IdentityUser
{
    public CustomUser() : base() { }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Province { get; set; }
    public string? Country { get; set; }
    public string? PostalCode { get; set; }
    public string? MobileNumber {get; set;}
    public Boolean? isMember{get;set;}
    public Boolean? isAdmin{get;set;}
    public string? Status {get;set;}
}