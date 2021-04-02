using bondora_api.Models.EquipmentType;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bondora_api.Tests.Models.EquipmentType
{
    [TestClass]
    public class RegularTest
    {
        [TestMethod]
        public void CalculatePrice_WithDaysLessThenZero()
        {
            Regular regular = new Regular();

            float result = regular.CalculatePrice(0);

            Assert.AreEqual(0, result);

            result = regular.CalculatePrice(-3212);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CalculatePrice_WithOnlyPremiumPrice()
        {
            Regular regular = new Regular();

            float result = regular.CalculatePrice(1);

            Assert.AreEqual(160, result);

            result = regular.CalculatePrice(2);

            Assert.AreEqual(220, result);
        }

        [TestMethod]
        public void CalculatePrice_WithMoreThenTwoDays()
        {
            Regular regular = new Regular();

            float result = regular.CalculatePrice(3);

            Assert.AreEqual(320, result);

            result = regular.CalculatePrice(15);

            Assert.AreEqual(1520, result);
        }
    }
}
