﻿using System;
using System.Collections.Generic;
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

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int IdMesta { get; set; }
        public int IdUlice{ get; set; }
        public string KucniBroj{ get; set; }
        public string UlazIliStan{ get; set; }
        public string AdresaZaPrikaz { get; set; }
        public string KontaktTelefon{ get; set; }
        public DateTime TimestampKreiranja{ get; set; }
        public DateTime DatumSlanja { get; set; }
        public int Otkup { get; set; }
        public int IdVrsteRobe { get; set; }
        public int ShipmentCategory { get; set; }

        public int IdNalogaSaKogSeSalje { get; set; }
        public string NalogSaKogSeSalje { get; set; }
        public virtual ICollection<DetaljiNarudzbine> DetaljiNarudzbine { get; set; }
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

        [ForeignKey("ModelObuce")]
        public int IdModelaObuce{ get; set; }
        public virtual ModelObuce ModelObuce { get; set; }
    }
}
