using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budjoni.Data
{
    public class Nalog
    {
        public string DisplayName { get; set; } 
        public int UserId { get; set; }
        public int UgovorId{ get; set; }
        public int SubId { get; set; }
        
    }

    public static class Nalozi
    {
        public static List<Nalog> All()
        {
            return new List<Nalog>()
            {
                new Nalog{DisplayName = "Balubdžić Bogiša",UserId = 25814,UgovorId = 11295,SubId = 238949},
                new Nalog{DisplayName = "Ružić Dalibor",UserId = 25816,UgovorId = 9832,SubId = 224788},

            };
        }
    }
}
