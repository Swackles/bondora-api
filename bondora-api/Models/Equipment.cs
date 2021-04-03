using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using bondora_api.Models.EquipmentType;

namespace bondora_api.Models
{
    public enum EquipmentTypes
    {
        Regular,
        Heavy,
        Specialized
    }

    public class Equipment
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public EquipmentTypes TypeID { get; set; }

        private static string JsonString = "{\"equipments\":[{\"ID\":1,\"Name\":\"Caterpillar bulldozer\",\"TypeID\":1},{\"ID\":2,\"Name\":\"KamAZ truck\",\"TypeID\":0},{\"ID\":3,\"Name\":\"Komatsu crane\",\"TypeID\":1},{\"ID\":4,\"Name\":\"Volvo steamroller\",\"TypeID\":0},{\"ID\":5,\"Name\":\"Bosch jackhammer\",\"TypeID\":2}]}";

        [JsonIgnore]
        public AbstractEquipmentType Type { get; set; }

        public static Equipment[] FindAll()
        {
            //For some reason the .json file not included in build
            JObject json = JObject.Parse(JsonString);

            JToken[] JEquipments = json["equipments"].Children().ToArray();

            IList<Equipment> equipments = new List<Equipment>();
            foreach(JToken JEquipment in JEquipments)
            {
                Equipment equipment = JEquipment.ToObject<Equipment>();
                equipment.BindEquipmentType();

                equipments.Add(equipment);
            }

            return equipments.ToArray();
        }

        private void BindEquipmentType()
        {
            switch(this.TypeID)
            {
                case EquipmentTypes.Regular:
                    Type = new Regular();
                    break;
                case EquipmentTypes.Heavy:
                    Type = new Heavy();
                    break;
                case EquipmentTypes.Specialized:
                    Type = new Specialized();
                    break;
            }
        }

        public override bool Equals(object obj)
        {
            Equipment equipment = obj as Equipment;

            if (this.ID != equipment.ID)
                return false;

            if (this.Name != equipment.Name)
                return false;

            if (this.TypeID != equipment.TypeID)
                return false;

            if (this.Type != equipment.Type)
                return false;

            return true;
        }
    }
}
