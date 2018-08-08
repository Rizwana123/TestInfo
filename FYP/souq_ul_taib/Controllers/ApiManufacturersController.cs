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
    public class ApiManufacturersController : ApiController
    {

        [HttpPost]
        public string ManufactureNameInsert(dynamic data)
        {
            string strResponse = "";
            string strmanufactureName = data.manufactureName;


            Manufacturers objManu = new Manufacturers();
            bool bResult = objManu.ManufacturenameInsert(strmanufactureName, ref strResponse);

            if (bResult)
            {
                strResponse = "Manufacture added successfully";
            }
            else
            {
                strResponse = "Failed to add manufacture";
            }

            return strResponse;

        }


        [HttpGet]
        public DataTable GetAllManufacturers()
        {

            Manufacturers objManufacturers = new Manufacturers();
            DataTable dtb = objManufacturers.getAllManufacturers();
            return dtb;
        }

        [HttpGet]
        public string DeleteManufacturers(string id)
        {
            string strResponse = "";
            Manufacturers objManufacturers = new Manufacturers();
            bool bResult = objManufacturers.ManufacturersDelete(id, ref strResponse);

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
        public string ManufacturersUpdate(dynamic data)
        {
            string strResponse = "";
            string strmanufacturers = data.manufacturersName;
            string strmanufacturersid = data.id;

            Manufacturers objManufacturers = new Manufacturers();
            bool bResult = objManufacturers.ManufacturersUpdate(strmanufacturers, strmanufacturersid, ref strResponse);

            if (bResult)
            {
                strResponse = "Manufacturer updated successfully";
            }
            else
            {
                strResponse = "Failed to updated Manufacturer";
            }
            return strResponse;

        }


    }
}
