using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksOnLoan.Data;
using BooksOnLoan.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksOnLoan.MemberAPI.Controllers;

public class MemberController : Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Policy")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomUser>>> GetUsers()
        {
            return await _context.CustomUser.ToListAsync();
        }
        
        // GET: api/User/id
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomUser>> Edit(String? id)
        {
            var member = await _context.CustomUser.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
           
            return member; 
        }
    }
}