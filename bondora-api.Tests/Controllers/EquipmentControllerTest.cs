using bondora_api.Controllers;
using bondora_api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bondora_api.Tests.Controllers
{
    [TestClass]
    public class EquipmentControllerTest
    {
        [TestMethod]
        public void Get()
        {
            EquipmentController controller = new EquipmentController();

            Equipment[] result = controller.Get();

            CollectionAssert.AreEqual(Equipment.FindAll(), result);
        }

        [TestMethod]
        public void GetById()
        {
            EquipmentController controller = new EquipmentController();

            Equipment result = controller.Get(5);

            Assert.AreEqual(Equipment.FindAll()[4], result);
        }
    }
}
