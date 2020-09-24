using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Budjoni.DAL.Models;

namespace Budjoni.DAL.Models
{
    public class ModelObuce
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NazivModela{ get; set; }
        public string Sifra{ get; set; }
        public byte[] SlikaByteArray { get; set; }
        public virtual ICollection<VelicinaModela> VelicineModela { get; set; }

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

        [ForeignKey("ModelObuce")]
        public int IdModelaObuce { get; set; }
        public virtual ModelObuce ModelObuce { get; set; }
    }
}
