using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Budjoni.DAL.Models
{
    public class Narudzbina
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ime je obavezno")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Prezime je obavezno")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Mesto je obavezno")]
        public int? IdMesta { get; set; }
        [Required(ErrorMessage = "Ulica je obavezna")]
        public int? IdUlice{ get; set; }
        [Required(ErrorMessage = "Kucni broj je obavezan")]
        public string KucniBroj{ get; set; }
        public string UlazIliStan{ get; set; }
        public string AdresaZaPrikaz { get; set; }
        [Required(ErrorMessage = "Kontakt telefon je obavezan")]
        public string KontaktTelefon{ get; set; }
        [Required(ErrorMessage = "Datum slanja je obavezan")]
        public DateTime? DatumSlanja { get; set; }
        public DateTime DatumKreiranja { get; set; }
        [Required(ErrorMessage = "Otkup je obavezan")]
        public int? Otkup { get; set; }
        [Required(ErrorMessage = "Vrsta robe je obavezna")]
        public int IdVrsteRobe { get; set; }
        public int ShipmentCategory { get; set; }

        

        public int IdNalogaSaKogSeSalje { get; set; }
        public string NalogSaKogSeSalje { get; set; }
        public string NapomenaZaAdresnicu { get; set; }

        public int IdAdresnice { get; set; }
        [DefaultValue(false)]
        public bool KreiranPapiric { get; set; }
        [DefaultValue(false)]
        public bool KreiranaAdresnica { get; set; }
        public virtual List<DetaljiNarudzbine> DetaljiNarudzbine { get; set; }
        
    }

    public class DetaljiNarudzbine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Kolicina{ get; set; }

        [ForeignKey("Narudzbina")]
        public int IdNarudzbine { get; set; }
        public virtual Narudzbina Narudzbina { get; set; }

        [ForeignKey("VelicinaModela")]
        public int IdVelicineModela{ get; set; }
        public virtual VelicinaModela VelicinaModela { get; set; }
    }
}
