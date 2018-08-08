using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
using System.Data;


namespace souq_ul_taib.Controllers
{
    public class ApiMedicinetypenamesController : ApiController
    {
        //MedicineType Insert fuction
        [HttpPost]
        public string MedicinetypeNameInsert(dynamic data)
        {
            string strResponse = "";
            string strmedicinetypeName = data.medicinetypeName;


            Medicinetypenames objUser = new Medicinetypenames();
            bool bResult = objUser.MedicinetypenameInsert(strmedicinetypeName, ref strResponse);

            if (bResult)
            {
                strResponse = "Medicine_type added successfully";
            }
            else
            {
                strResponse = "Failed to add medicine_type";
            }

            return strResponse;

        }


        [HttpGet]
        public DataTable GetAllMedicineType()
        {
            Medicinetypenames objMedicinetypenames = new Medicinetypenames();
            DataTable dtb = objMedicinetypenames.getAllMedicineType();
            return dtb;
        }


        //MedicineType Delete fuction
        [HttpGet]
        public string DeleteMedicineType(string id)
        {
            string strResponse = "";
            Medicinetypenames objMedicinetypenames = new Medicinetypenames();
            bool bResult = objMedicinetypenames.MedicinetypenameDelete(id, ref strResponse);

            if (bResult)
            {
                strResponse = "Data Deleted Successfully";
            }
            else
            {
                strResponse = "Unable To Delete Data, please try again later";
            }
            return strResponse;
        }


        //MedicineType Update fuction
        [HttpPost]
        public string MedicinetypeNameUpdate(dynamic data)
        {
            string strResponse = "";
            string strmedicinetypeName = data.medicinetypeName;
            string strmedicinetypeid = data.id;

            Medicinetypenames objMedicinetypenames = new Medicinetypenames();
            bool bResult = objMedicinetypenames.MedicinetypenameUpdate(strmedicinetypeName, strmedicinetypeid, ref strResponse);

            if (bResult)
            {
                strResponse = "Medicine Type updated successfully";
            }
            else
            {
                strResponse = "Failed to updated Medicine Type";
            }
            return strResponse;

        }
    }
}
