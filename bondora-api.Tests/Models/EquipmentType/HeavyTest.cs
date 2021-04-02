using bondora_api.Models.EquipmentType;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bondora_api.Tests.Models.EquipmentType
{
    [TestClass]
    public class HeavyTest
    {
        [TestMethod]
        public void CalculatePrice_WithDaysLessThenZero()
        {
            Heavy heavy = new Heavy();

            float result = heavy.CalculatePrice(0);

            Assert.AreEqual(0, result);

            result = heavy.CalculatePrice(-3212);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CalculatePrice_WithDaysMoreThenZero()
        {
            Heavy heavy = new Heavy();

            float result = heavy.CalculatePrice(1);

            Assert.AreEqual(160, result);

            result = heavy.CalculatePrice(15);

            Assert.AreEqual(1000, result);
        }
    }
}
