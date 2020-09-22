using System;
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
        public string NazivModela { get; set; }
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
}
