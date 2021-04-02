using bondora_api.Models.EquipmentType;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bondora_api.Tests.Models.EquipmentType
{
    [TestClass]
    public class SpecializedTest
    {
        [TestMethod]
        public void CalculatePrice_WithDaysLessThenZero()
        {
            Specialized specialized = new Specialized();

            float result = specialized.CalculatePrice(0);

            Assert.AreEqual(0, result);

            result = specialized.CalculatePrice(-3212);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CalculatePrice_WithOnlyPremiumPrice()
        {
            Specialized specialized = new Specialized();

            float result = specialized.CalculatePrice(1);

            Assert.AreEqual(160, result);

            result = specialized.CalculatePrice(3);

            Assert.AreEqual(280, result);
        }

        [TestMethod]
        public void CalculatePrice_WithMoreThenThreeDays()
        {
            Specialized specialized = new Specialized();

            float result = specialized.CalculatePrice(4);

            Assert.AreEqual(380, result);

            result = specialized.CalculatePrice(15);

            Assert.AreEqual(1480, result);
        }
    }
}
