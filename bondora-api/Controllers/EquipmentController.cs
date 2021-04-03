using System;
using System.Web.Http;
using bondora_api.Models;

namespace bondora_api.Controllers
{
    public class EquipmentController : ApiController
    {
        // GET api/values
        public Equipment[] Get()
        {
            return Equipment.FindAll();
        }

        // GET api/values/5
        public Equipment Get(int id)
        {
            return Array.Find(Equipment.FindAll(), (Equipment e) => e.ID == id);    
        }
    }
}
