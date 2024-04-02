using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BooksOnLoan.Data;
using BooksOnLoan.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using SQLitePCL;


namespace BooksOnLoan.Controllers;


[Route("api/[controller]")]
[ApiController]
[EnableCors("Policy")]
public class UserController : ControllerBase
{
        private readonly RoleManager<IdentityRole> _roleManager;
         private readonly UserManager<CustomUser> _userManager;
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<CustomUser> userManager
            )
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        
        //Get: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomUser>>> GetMembersAsync()
        {
            var role = _context.IdentityRole
            .FirstOrDefault(u=> u.Name == "Member");

            if (role == null)
            {
                return NotFound();
            }

            var userInMember = _context.IdentityUserRole
            .Where(w=> w.RoleId == role.Id);
           
            var usersNoAdmin =   _context.CustomUser
            .Where(w=> w.isAdmin == false);

            return await usersNoAdmin.ToListAsync();
        }
        // GET: api/user/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<CustomUser>> GetUser(string id)
        // {
        //     var user = await _context.CustomUser.FindAsync(id);

        //     if (user == null)
        //     {
        //         return NotFound();
        //     }

        //     return user;
        // }

        // PUT: api/user/confirm/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("confirm/{id}")]
        public async Task<IActionResult> PutCustUser(string id, CustomUser user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
//IList<string> userRoles = await UserManager.GetRolesAsync(userId);


                var defaultrole = _roleManager.FindByNameAsync("Member").Result;  

                    if (defaultrole != null)  
                    {  
                       IdentityResult roleresult = await  _userManager.AddToRoleAsync(user, defaultrole.Name);  
                    }  

            // var memberRole = new IdentityRole("Member");
            // memberRole.NormalizedName = memberRole.Name!.ToUpper();
            //  List<IdentityRole<string>> identityRoles = new List<IdentityRole<string>>();
            //  var defaultrole = identityRoles.Where(w=> w.Name == "Member").FirstOrDefault();  
            
            //  List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();
            //     userRoles.Add(new IdentityUserRole<string> {
            //     UserId = user.Id,
            //     RoleId = "2ef11eff-8e54-40a1-b860-327b18892b02"
            // });
           
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool UserExists(string id)
        {
            return _context.CustomUser.Any(e => e.Id == id);
        }
        
}
