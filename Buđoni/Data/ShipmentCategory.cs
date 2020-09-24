using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budjoni.Data
{
    public class ShipmentCategory
    {
        public int IdKategorije { get; set; }
        public string NazivKategorije { get; set; }

    }

    public static class ShipmentCategories
    {
        public static List<ShipmentCategory> All()
        {
            return new List<ShipmentCategory>()
            {
                new ShipmentCategory {IdKategorije= 3, NazivKategorije= "do 2 kg"},
                new ShipmentCategory {IdKategorije= 4, NazivKategorije= "do 5 kg"},

            };
        }
    }
}
