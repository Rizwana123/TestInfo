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
    public class ApiMedicinesController : ApiController
    {
        [HttpPost]
        public string InsertMedicines(dynamic data)
        {
            string strResponse = "";
            string strmedicineName = data.medicineName;
            string strmedicinetypeid = data.medicinetypeid;
            string strmedicinecontentvalue = data.medicinecontentvalue;
            string strmedicinecontenttype = data.medicinecontenttype;
            string strpacketsize = data.packetsize;
            string strpacketprice = data.packetprice;
            string strdosage = data.dosage;
            string strgenericid = data.genericid;
            string strmanufacturerid = data.manufacturerid;
            string strusage = data.usage;
            string strsideeffect = data.sideeffect;
            string stralternate = data.alternate;
          

            Medicines objMed = new Medicines();
            bool bResult = objMed.InsertMedicine(strmedicineName, strmedicinetypeid, strmedicinecontentvalue, strmedicinecontenttype, strpacketsize, strpacketprice, strdosage, strgenericid, strmanufacturerid, strusage, strsideeffect, stralternate, ref strResponse);

            if (bResult)
            {
                strResponse = "Medicine added successfully";
            }
            else
            {
                strResponse = "Failed to add medicine.";
            }

            return strResponse;

        }


        [HttpGet]
        public DataTable GetAllMedicines()
        {

            Medicines objMedicines = new Medicines();
            DataTable dtb = objMedicines.getAllMedicines();
            return dtb;
        }

        [HttpGet]
        public string DeleteMedicines(string id)
        {
            string strResponse = "";
            Medicines objMedicines = new Medicines();
            bool bResult = objMedicines.DeleteMedicines(id, ref strResponse);

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


        [HttpPost]
        public string MedicinesUpdate(dynamic data)
        {
            string strResponse = "";
            string strmedicineid = data.id;
            string strmedicineName = data.medicineName;
            string strmedicinetypeid = data.medicinetypeid;
            string strmedicinecontentvalue = data.medicinecontentvalue;
            string strmedicinecontenttype = data.medicinecontenttype;
            string strpacketsize = data.packetsize;
            string strpacketprice = data.packetprice;
            string strdosage = data.dosage;
            string strgenericid = data.genericid;
            string strmanufacturerid = data.manufacturerid;
            string strusage = data.usage;
            string strsideeffect = data.sideeffect;
            string stralternate = data.alternate;

            Medicines objMed = new Medicines();
            bool bResult = objMed.MedicinesUpdate(strmedicineid, strmedicineName, strmedicinetypeid, strmedicinecontentvalue, strmedicinecontenttype, strpacketsize, strpacketprice, strdosage, strgenericid, strmanufacturerid, strusage, strsideeffect, stralternate, ref strResponse);

            if (bResult)
            {
                strResponse = "Medicine updated successfully";
            }
            else
            {
                strResponse = "Failed to updated Medicine";
            }
            return strResponse;

        }
    }
}
