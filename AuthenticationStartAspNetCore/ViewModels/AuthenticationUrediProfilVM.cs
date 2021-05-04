using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AuthenticationStartAspNetCore.ViewModels
{
    public class AuthenticationUrediProfilVM
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Korisničko ime")]
        public string KorisnickoIme { get; set; }
        [Required]
        public string Lozinka { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
    }
}
