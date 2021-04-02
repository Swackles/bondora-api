using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using bondora_api.Models;

namespace bondora_api.Tests.Models
{
    [TestClass]
    public class EquipmentTest
    {
        #region Equals Method Tests
        [TestMethod]
        public void Equals_WhenEqual()
        {
            Equipment firstEquipment = new Equipment
            {
                ID = 1,
                Name = "Caterpillar bulldozer",
                TypeID = EquipmentTypes.Heavy,
                Type = new bondora_api.Models.EquipmentType.Heavy()
            };

            Equipment secondEquipment = new Equipment
            {
                ID = 1,
                Name = "Caterpillar bulldozer",
                TypeID = EquipmentTypes.Heavy,
                Type = new bondora_api.Models.EquipmentType.Heavy()
            };

            Assert.AreEqual(firstEquipment, secondEquipment);
        }

        [TestMethod]
        public void Equals_WhenIDNotEqual()
        {
            Equipment firstEquipment = new Equipment
            {
                ID = 2,
                Name = "Caterpillar bulldozer",
                TypeID = EquipmentTypes.Heavy,
                Type = new bondora_api.Models.EquipmentType.Heavy()
            };

            Equipment secondEquipment = new Equipment
            {
                ID = 1,
                Name = "Caterpillar bulldozer",
                TypeID = EquipmentTypes.Heavy,
                Type = new bondora_api.Models.EquipmentType.Heavy()
            };

            Assert.AreNotEqual(firstEquipment, secondEquipment);
        }

        [TestMethod]
        public void Equals_WhenNameNotEqual()
        {
            Equipment firstEquipment = new Equipment
            {
                ID = 1,
                Name = "Caterpillar",
                TypeID = EquipmentTypes.Heavy,
                Type = new bondora_api.Models.EquipmentType.Heavy()
            };

            Equipment secondEquipment = new Equipment
            {
                ID = 1,
                Name = "Caterpillar bulldozer",
                TypeID = EquipmentTypes.Heavy,
                Type = new bondora_api.Models.EquipmentType.Heavy()
            };

            Assert.AreNotEqual(firstEquipment, secondEquipment);
        }

        [TestMethod]
        public void Equals_WhenTypeIDNotEqual()
        {
            Equipment firstEquipment = new Equipment
            {
                ID = 1,
                Name = "Caterpillar bulldozer",
                TypeID = EquipmentTypes.Regular,
                Type = new bondora_api.Models.EquipmentType.Heavy()
            };

            Equipment secondEquipment = new Equipment
            {
                ID = 1,
                Name = "Caterpillar bulldozer",
                TypeID = EquipmentTypes.Heavy,
                Type = new bondora_api.Models.EquipmentType.Heavy()
            };

            Assert.AreNotEqual(firstEquipment, secondEquipment);
        }
        #endregion

        [TestMethod]
        public void FindAll()
        {
            Equipment[] result = Equipment.FindAll();
            List<Equipment> expectedResult = new List<Equipment>();

            expectedResult.Add(new Equipment {
                ID = 1,
                Name = "Caterpillar bulldozer",
                TypeID = EquipmentTypes.Heavy,
                Type = new bondora_api.Models.EquipmentType.Heavy()
            });
            expectedResult.Add(new Equipment
            {
                ID = 2,
                Name = "KamAZ truck",
                TypeID = EquipmentTypes.Regular,
                Type = new bondora_api.Models.EquipmentType.Regular()
            });
            expectedResult.Add(new Equipment
            {
                ID = 3,
                Name = "Komatsu crane",
                TypeID = EquipmentTypes.Heavy,
                Type = new bondora_api.Models.EquipmentType.Heavy()
            });
            expectedResult.Add(new Equipment
            {
                ID = 4,
                Name = "Volvo steamroller",
                TypeID = EquipmentTypes.Regular,
                Type = new bondora_api.Models.EquipmentType.Regular()
            });
            expectedResult.Add(new Equipment
            {
                ID = 5,
                Name = "Bosch jackhammer",
                TypeID = EquipmentTypes.Specialized,
                Type = new bondora_api.Models.EquipmentType.Specialized()
            });

            CollectionAssert.AreEqual(expectedResult.ToArray(), result);
        }
    }
}
