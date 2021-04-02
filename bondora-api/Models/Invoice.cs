using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace bondora_api.Models
{
    public class Invoice
    {
        public List<ItemInInvoice> Items { get; } = new List<ItemInInvoice>();
        public int LoyaltyPoints { get { return GetLoyaltyPoints(); } }
        public float Sum {  get { return GetSum();  } }

        public string Print()
        {
            string printString = "Bondora developer home assignment\n";

            foreach(ItemInInvoice item in Items)
            {
                printString += item.Equipment.Name + " - " + item.Price + "€\n";
            }

            printString += "LoyaltyPoints: " + LoyaltyPoints +"\n";
            printString += "Sum: " + Sum + "€\n";

            return printString;
        }

        private float GetSum()
        {
            float sum = 0;

            foreach (ItemInInvoice item in Items)
                sum += item.Price;

            return sum;
        }

        private int GetLoyaltyPoints()
        {
            int lp = 0;
            foreach (ItemInInvoice item in Items)
                lp += item.LoyaltyPoints;

            return lp;
        }
    }
}