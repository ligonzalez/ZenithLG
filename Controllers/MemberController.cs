using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BooksOnLoan.Data;
using BooksOnLoan.Models;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;
using System.Net;

namespace BooksOnLoan.Controllers;

public class MemberController : Controller
{
     private readonly ApplicationDbContext _context;

        public MemberController(ApplicationDbContext context)
        {
            _context = context;
        }

    public IActionResult Index()
    {
        return View();
    }


    // GET: Member/Confirm/id
    public async Task<IActionResult> Confirm(string? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var user = await _context.CustomUser
            .FirstOrDefaultAsync(m => m.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }


    [HttpPost, ActionName("Confirm")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> MemberConfirmed(string? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var user = await _context.CustomUser
            .FirstOrDefaultAsync(m => m.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        
        var role = _context.IdentityRole
            .FirstOrDefault(u=> u.Name == "Member");

        if (role == null)
        {
            return NotFound();
        }
    
        IdentityUserRole<string> userRole = new IdentityUserRole<string>();
        userRole.UserId = user.Id;
        userRole.RoleId = role.Id;

        _context.IdentityUserRole.Add(userRole);
        user.isMember = true;
        _context.Update(user);
        
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
        
        
    }

  // GET: Member/Edit/id
    public async Task<IActionResult> Edit(string? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var user = await _context.CustomUser
            .FirstOrDefaultAsync(m => m.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }

    
    // POST: Member/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, [Bind("Id,FirstName,LastName,Address,Email,PostalCode,City,Country,PhoneNumber,MobileNumber,Province")] CustomUser user)
    {
        if (id != user.Id)
        {
            return NotFound();
        }
        //To Update we need to pass the user updated values to an async user 
        //so only the fielsa exposed gets updated.
        //Found it in google
        if (ModelState.IsValid)
        {
            try
            {
                var userAsync = await _context.CustomUser
                .FirstOrDefaultAsync(m => m.Id == id);
                if (userAsync == null)
                {
                    return NotFound();
                }else{
                    userAsync.FirstName = user.FirstName;
                    userAsync.LastName = user.LastName;
                    userAsync.Email = user.Email;
                    userAsync.Address = user.Address;
                    userAsync.City = user.City;
                    userAsync.Province = user.Province;
                    userAsync.Country = user.Country;
                    userAsync.PostalCode = user.PostalCode;
                    userAsync.PhoneNumber = user.PhoneNumber;
                    userAsync.MobileNumber = user.MobileNumber;
                }
                _context.Update(userAsync);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.Id))
                 {
                    return NotFound();
                 }
                 else
                 {
                     throw;
                 }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(user);
    }
    private bool UserExists(string id)    
    {
        return _context.CustomUser.Any(e => e.Id == id);
    }
}
