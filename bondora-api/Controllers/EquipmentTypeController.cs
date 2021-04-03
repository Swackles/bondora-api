using System;
using System.Web.Http;
using bondora_api.Models;
using bondora_api.Models.EquipmentType;

namespace bondora_api.Controllers
{
    public class EquipmentTypeController : ApiController
    {
        public AbstractEquipmentType Get(int id)
        {
            switch((EquipmentTypes)id)
            {
                case EquipmentTypes.Regular:
                    return new Regular();
                case EquipmentTypes.Heavy:
                    return new Heavy();
                case EquipmentTypes.Specialized:
                    return new Specialized();
            }

            return null;
        }
    }
}
