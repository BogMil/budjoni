using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Budjoni.DAL.Models;

namespace Budjoni.DAL.Models
{
    public class Model
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NazivModela { get; set; }
        public string Sifra { get; set; }
        public virtual ICollection<BojaModela> BojeModela { get; set; }

        
    }

    public class BojaModela
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NazivBoje { get; set; }
        public byte[] SlikaByteArray { get; set; }
        public virtual ICollection<VelicinaModela> VelicineModela { get; set; }

        [ForeignKey("Model")]
        public int IdModela{ get; set; }
        public virtual Model Model{ get; set; }

        public string GetImageSrc()
        {
            if (SlikaByteArray == null)
                return "";
            var base64 = Convert.ToBase64String(SlikaByteArray);
            return $"data:image/gif;base64,{base64}";
        }
    }

    public class VelicinaModela
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Velicina { get; set; }
        public int KolicinaNaStanju { get; set; }

        [ForeignKey("BojaModela")]
        public int IdModelaObuce { get; set; }
        public virtual BojaModela BojaModela { get; set; }
    }
}
