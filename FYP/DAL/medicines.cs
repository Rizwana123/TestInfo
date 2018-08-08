using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class Medicines : Connection
    {
        //Medicine function for Bal to DAL

        public bool InsertMedicine(string strMedicineName, string strMedicinetypeid, string strMedicinecontentvalue, string strMedicinecontenttype, string strPacketsize, string strPacketprice, string strDosage, string strGenericid, string strManufacturerid, string strUsage, string strSideeffect, string strAlternate, ref string strReturnMessage)
        {
            bool bReturn = false;
            try
            {
                Dictionary<String, Object> Params = new Dictionary<string, object>();
                Params.Add("@name", strMedicineName);
                Params.Add("@medicine_type_id", strMedicinetypeid);
                Params.Add("@medicine_content_value", strMedicinecontentvalue);
                Params.Add("@medicine_content_type", strMedicinecontenttype);
                Params.Add("@packet_size", strPacketsize);
                Params.Add("@packet_price", strPacketprice);
                Params.Add("@dosage", strDosage);
                Params.Add("@generic_name_id", strGenericid);
                Params.Add("@manufacture_id", strManufacturerid);
                Params.Add("@usage", strUsage);
                Params.Add("@side_effect", strSideeffect);
                Params.Add("@alternate", strAlternate);


                int iRetValue = AddDataSP("medicinesInsertRow", Params, ref strReturnMessage);

                bReturn = (iRetValue > 0) ? true : false;
            }
            catch (Exception ex)
            {
                strReturnMessage = "An Error Occured, Please Try Again Later";
            }

            return bReturn;
        }

        public DataTable getAllMedicines()
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = GetSPData("medicinesSelectAll");
                return dtb;
            }
            catch (Exception ex)
            {
                return dtb;
            }
        }

        public bool DeleteMedicines(string id, ref string strReturnMessage)
        {
            bool bReturn = false;
            try
            {
                Dictionary<String, Object> Params = new Dictionary<string, object>();
                Params.Add("@id", id);
                bReturn = AddUpdateDataSP("medicinesDeleteRow", Params, ref strReturnMessage);
            }
            catch (Exception ex)
            {
                strReturnMessage = "An Error Occured, Please Try Again Later";
            }

            return bReturn;
        }

        public bool MedicinesUpdate(string strId, string strMedicineName, string strMedicinetypeid, string strMedicinecontentvalue, string strMedicinecontenttype, string strPacketsize, string strPacketprice, string strDosage, string strGenericid, string strManufacturerid, string strUsage, string strSideeffect, string strAlternate, ref string strReturnMessage)
        {
            bool bReturn = false;
            try
            {
                Dictionary<String, Object> Params = new Dictionary<string, object>();
                Params.Add("@id", strId);
                Params.Add("@name", strMedicineName);
                Params.Add("@medicine_type_id", strMedicinetypeid);
                Params.Add("@medicine_content_value", strMedicinecontentvalue);
                Params.Add("@medicine_content_type", strMedicinecontenttype);
                Params.Add("@packet_size", strPacketsize);
                Params.Add("@packet_price", strPacketprice);
                Params.Add("@dosage", strDosage);
                Params.Add("@generic_name_id", strGenericid);
                Params.Add("@manufacture_id", strManufacturerid);
                Params.Add("@usage", strUsage);
                Params.Add("@side_effect", strSideeffect);
                Params.Add("@alternate", strAlternate);


                bReturn = AddUpdateDataSP("medicinesUpdateRow", Params, ref strReturnMessage);
            }
            catch (Exception ex)
            {
                strReturnMessage = "An Error Occured, Please Try Again Later";
            }

            return bReturn;
        }

    }
}
