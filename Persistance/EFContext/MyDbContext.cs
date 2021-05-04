using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistance.Entities;

namespace Persistance.EFContext
{
    public class MyDbContext : IdentityDbContext<Korisnik, IdentityRole<int>, int>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
    }
}
