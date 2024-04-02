using BooksOnLoan.Models;
using BooksOnLoan.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
namespace BooksOnLoan.Data;
public class BookService
{
    private ApplicationDbContext _context;
    public BookService(ApplicationDbContext context)
    {
        _context = context;
    }

    //Get Books
    public async Task<List<Book>> GetBooksAsync()
    {
        return await _context.Book.ToListAsync();
    }

    //Get Members
    public async Task<List<CustomUser>> GetMembersAsync()
    {
         var usersNoAdmin =   _context.CustomUser
            .Where(w=> w.isAdmin == false);

        return await usersNoAdmin.ToListAsync();

    }
}