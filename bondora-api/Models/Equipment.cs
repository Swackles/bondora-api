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
        
        [JsonIgnore]
        public AbstractEquipmentType Type { get; set; }

        public static Equipment[] FindAll()
        {
            string jsonString = File.ReadAllText("./data.json");

            JObject json = JObject.Parse(jsonString);

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
