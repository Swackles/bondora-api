using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bondora_api.Models
{
    public class ItemInInvoice
    {
        public Equipment Equipment { get; set; }
        public int DaysRented { get; set; }
        public int LoyaltyPoints { get { return Equipment.Type.LoyaltyPoints; } }
        public float Price { get { return Equipment.Type.CalculatePrice(DaysRented); } }
    }
}