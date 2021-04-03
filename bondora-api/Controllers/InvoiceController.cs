using System;
using System.Collections.Generic;
using bondora_api.Models;
using System;
using System.Web.Http;

namespace bondora_api.Controllers
{
    public class InvoiceController : ApiController
    {
        public Invoice Post([FromBody] Dictionary<int, int> body)
        {
            return GenerateInvoice(body);
        }

        [HttpPost]
        [Route("api/invoice/print")]
        public string Print([FromBody] Dictionary<int, int> body)
        {
            Invoice invoice = GenerateInvoice(body);

            return invoice.Print();
        }

        /// <summary>
        /// Generates an invoice based on the input dictionary
        /// </summary>
        /// <param name="InvoiceDict">key is id of the equipment and value is for how many days it gets rented</param>
        /// <returns>Generated invoice</returns>
        private Invoice GenerateInvoice(Dictionary<int, int> InvoiceDict)
        {
            Invoice invoice = new Invoice();

            foreach (KeyValuePair<int, int> value in InvoiceDict)
            {
                Equipment equipment = Array.Find(Equipment.FindAll(), (Equipment x) => x.ID == value.Key);

                if (equipment == null)
                    continue;

                invoice.Items.Add(new ItemInInvoice()
                {
                    DaysRented = value.Value,
                    Equipment = equipment
                });
            }

            return invoice;
        }
    }
}
