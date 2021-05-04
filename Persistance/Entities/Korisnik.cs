using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Persistance.Entities
{
    public class Korisnik : IdentityUser<int>
    {
        [StringLength(80)]
        public string Ime { get; set; }
        [StringLength(80)]
        public string Prezime { get; set; }
    }
}
