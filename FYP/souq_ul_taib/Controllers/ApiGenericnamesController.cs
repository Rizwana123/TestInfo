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
    public class ApiGenericnamesController : ApiController
    {
        //GenricNameInsert HttpPost
        [HttpPost]
        public string GenericNameInsert(dynamic data)
        {
            string strResponse = "";
            string strgenericName = data.genericName;


            Genericnames objGeneric = new Genericnames();
            bool bResult = objGeneric.GenericnameInsert(strgenericName, ref strResponse);

            if (bResult)
            {
                strResponse = "Generic added successfully";
            }
            else
            {
                strResponse = "Failed to add generic";
            }

            return strResponse;

        }



        [HttpGet]
        public DataTable GetAllGenericName()
        {
            Genericnames objGenericnames = new Genericnames();
            DataTable dtb = objGenericnames.getAllGenericName();
            return dtb; 
        }



        //GenricName Delete fuction
        [HttpGet]
        public string DeleteGenericname(string id)
        {
            string strResponse = "";
            Genericnames objGenericnames = new Genericnames();
            bool bResult = objGenericnames.GenericnameDelete(id, ref strResponse);

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





        //GenricName Update HttpPost
        [HttpPost]
        public string GenericNameUpdate(dynamic data)
        {
            string strResponse = "";
            string strgenericName = data.genericName;
            string strgenericNameid = data.id;

            Genericnames objGenericnames = new Genericnames();
            bool bResult = objGenericnames.GenericnameUpdate(strgenericName, strgenericNameid, ref strResponse);

            if (bResult)
            {
                strResponse = "Generic Name updated successfully";
            }
            else
            {
                strResponse = "Failed to updated Generic Name";
            }
            return strResponse;

        }
    }
}
