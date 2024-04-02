using BooksOnLoan.Models;
using Microsoft.AspNetCore.Identity;

namespace BooksOnLoan.Data;
public class SeedUsersRoles {
    private readonly List<IdentityRole> _roles;
    private readonly List<CustomUser> _users;
    private readonly List<IdentityUserRole<string>> _userRoles; 
 
    public SeedUsersRoles() {
      _roles = GetRoles();
      _users = GetUsers();
      _userRoles = GetUserRoles(_users, _roles);
    } 
    public List<IdentityRole> Roles { get { return _roles; } }
    public List<CustomUser> Users { get { return _users; } }
    public List<IdentityUserRole<string>> UserRoles { get { return _userRoles; } }
    private List<IdentityRole> GetRoles() {
      // Seed Roles
      var adminRole = new IdentityRole("Admin");
      adminRole.NormalizedName = adminRole.Name!.ToUpper();
      var memberRole = new IdentityRole("Member");
      memberRole.NormalizedName = memberRole.Name!.ToUpper();
      List<IdentityRole> roles = new List<IdentityRole>() {
        adminRole,
        memberRole
      };
      return roles;
    }
    private List<CustomUser> GetUsers() {
      string pwd = "P@$$w0rd";
      var passwordHasher = new PasswordHasher<CustomUser>();
      // Seed Users
      var adminUser = new CustomUser {
        UserName = "aa@aa.aa",
        Email = "aa@aa.aa",
        FirstName = "Mr. Elmasri",
        LastName = "Medhat",
        PhoneNumber = "(604)677-8899",
        MobileNumber = "(605)528-6688",
        Address = "12 West Street",
        City = "Vancouver",
        Province = "BC",
        PostalCode = "V5T 6Y7",
        Country = "Canada",
        PhoneNumberConfirmed=true,
        EmailConfirmed = true,
        isMember = false,
        isAdmin = true,  
      };

      adminUser.NormalizedUserName = adminUser.UserName.ToUpper();
      adminUser.NormalizedEmail = adminUser.Email.ToUpper();
      adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, pwd);
      var memberUser = new CustomUser {
        UserName = "mm@mm.mm",
        Email = "mm@mm.mm",
        EmailConfirmed = true,
        FirstName = "Laura",
        LastName = "Gonzalez",
        PhoneNumber = "(604)58-7866",
        MobileNumber = "(728)345-4548",
        Address = "9 Eastwood Street",
        City = "Coquitlam",
        Province = "BC",
        PostalCode = "V4B 7P9",
        Country = "Canada",
        PhoneNumberConfirmed=true,
        isMember=true,
        isAdmin=false,
      };
      memberUser.NormalizedUserName = memberUser.UserName.ToUpper();
      memberUser.NormalizedEmail = memberUser.Email.ToUpper();
      memberUser.PasswordHash = passwordHasher.HashPassword(memberUser, pwd);
      List<CustomUser> users = new List<CustomUser>() {
          adminUser,
          memberUser,
      };
      return users;
    }
    private List<IdentityUserRole<string>> GetUserRoles(List<CustomUser> users, List<IdentityRole> roles) {
      // Seed UserRoles
      List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();
      userRoles.Add(new IdentityUserRole<string> {
        UserId = users[0].Id,
        RoleId = roles.First(q => q.Name == "Admin").Id
      });
      userRoles.Add(new IdentityUserRole<string> {
        UserId = users[1].Id,
        RoleId = roles.First(q => q.Name == "Member").Id
      });
      return userRoles;
    }
}