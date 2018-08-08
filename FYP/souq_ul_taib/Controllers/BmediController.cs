using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace souq_ul_taib.Controllers
{
    public class BmediController : ApiController
    {

        [HttpGet]
        public List<string> GetAllMedicine()
        {
            List<string> med = new List<string>();
            med.Add("Hajmola");
            med.Add("Panadol");
            return med;


        }

        [HttpGet]
        public string AddMedicine(string id)
        {
            string str = "Kam Hogya Name add krwadya" + id;
            return str;

        }

        [HttpGet]
        public string GetMedicine(string id)
        {
            string str = "this is panadol" + id;
            return str;

        }

        [HttpPost]
        public string InsertMedicine(dynamic data)
        {
            string strFirstName = data.FirstName;
            string strLastName = data.LastName;
            return strFirstName + " " + strLastName;

        }
    }
}
