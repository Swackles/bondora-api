using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using bondora_api.Models;

namespace bondora_api.Tests.Models
{
    [TestClass]
    public class InvoiceTest
    {
        #region UtilMethods
        public ItemInInvoice GetHeavyEquipment(int daysRented)
        {
            return new ItemInInvoice()
            {
                Equipment = new Equipment
                {
                    ID = 1,
                    Name = "Caterpillar bulldozer",
                    TypeID = EquipmentTypes.Heavy,
                    Type = new bondora_api.Models.EquipmentType.Heavy()
                },
                DaysRented = daysRented
            };
        }

        public ItemInInvoice GetRegularEquipment(int daysRented)
        {
            return new ItemInInvoice()
            {
                Equipment = new Equipment
                {
                    ID = 2,
                    Name = "KamAZ truck",
                    TypeID = EquipmentTypes.Regular,
                    Type = new bondora_api.Models.EquipmentType.Regular()
                },
                DaysRented = daysRented
            };
        }

        public ItemInInvoice GetSpecializedEquipment(int daysRented)
        {
            return new ItemInInvoice()
            {
                Equipment = new Equipment
                {
                    ID = 5,
                    Name = "Bosch jackhammer",
                    TypeID = EquipmentTypes.Specialized,
                    Type = new bondora_api.Models.EquipmentType.Specialized()
                },
                DaysRented = daysRented
            };
        }
        #endregion

        #region GetLoyaltyPoints
        [TestMethod]
        public void GetLoyaltyPoints_WithHeavyEquipment()
        {
            Invoice invoice = new Invoice();

            invoice.Items.Add(GetHeavyEquipment(1));

            Assert.AreEqual(2, invoice.LoyaltyPoints);
        }

        [TestMethod]
        public void GetLoyaltyPoints_WithRegularEquipment()
        {
            Invoice invoice = new Invoice();

            invoice.Items.Add(GetRegularEquipment(1));


            Assert.AreEqual(1, invoice.LoyaltyPoints);
        }

        [TestMethod]
        public void GetLoyaltyPoints_WithSpecializedEquipment()
        {
            Invoice invoice = new Invoice();

            invoice.Items.Add(GetSpecializedEquipment(1));

            Assert.AreEqual(1, invoice.LoyaltyPoints);
        }
        [TestMethod]
        public void GetLoyaltyPoints_WithMultipleEquipment()
        {
            Invoice invoice = new Invoice();

            invoice.Items.Add(GetRegularEquipment(1));
            invoice.Items.Add(GetHeavyEquipment(1));
            invoice.Items.Add(GetSpecializedEquipment(1));

            Assert.AreEqual(4, invoice.LoyaltyPoints);
        }
        #endregion

        [TestMethod]
        public void Print()
        {
            string expected = "Bondora developer home assignment\n" +
                "KamAZ truck - 420€\n" +
                "Caterpillar bulldozer - 220€\n" +
                "Bosch jackhammer - 280€\n" +
                "LoyaltyPoints: 4\n" +
                "Sum: 920€\n";
            Invoice invoice = new Invoice();

            invoice.Items.Add(GetRegularEquipment(4));
            invoice.Items.Add(GetHeavyEquipment(2));
            invoice.Items.Add(GetSpecializedEquipment(3));

            string result = invoice.Print();

            Assert.AreEqual(expected, result);
        }
    }
}
