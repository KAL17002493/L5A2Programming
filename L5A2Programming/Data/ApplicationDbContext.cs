using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using L5A2Programming.Models;

namespace L5A2Programming.Data
{
    public class ApplicationDbContext : IdentityDbContext<CustomUserModel>
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

    }
}