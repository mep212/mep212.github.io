using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Antiforgery;

namespace novypokusicek.Models
{
    public class Denik
    {
        [Required(ErrorMessage = "Vyplňte obsah")]
        public int Id {  get; set; }
        [Required(ErrorMessage = "Vyplňte jméno")]
        public string Jmeno { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte příjmení")]
        public string Prijmeni { get; set; } = "";
        [Required(ErrorMessage = "Vyplňte název")]
        [StringLength(100, ErrorMessage = "Název je příliš dlouhý")]
        public string Nazev { get; set; } = "";
        public string Popis { get; set; } = "";
        [Required]
        [RegularExpression(@"^(1[4-9][0-9]{2}|2[0-9]{3}|3000)$", ErrorMessage = "Rok vydání musí být v rozsahu 1440-3000")]
        public int RokVydani { get; set;}
        public string Nakladatelstvi {  get; set; } = "";
        [Range(1, 5000, ErrorMessage = "Počet stran musí být v rozsahu 1-5000")]
        public int PocetStran {get; set;}


        public Denik(int id, string jmeno, string prijmeni, string nazev, string popis, int rokVydani, string nakladatelstvi, int pocetStran)
        {
            Id = id;
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            Nazev = nazev;
            Popis = popis;
            RokVydani = rokVydani;
            Nakladatelstvi = nakladatelstvi;
            PocetStran = pocetStran;
        }
        public Denik() 
        {
        }
    }
}
