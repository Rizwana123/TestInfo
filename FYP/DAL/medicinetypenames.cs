using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class Medicinetypenames : Connection
    {
        //MedicineType Insert function for Bal to DAL
        public bool MedicinetypenameInsert(string strMedicinetypeName, ref string strReturnMessage)
        {
            bool bReturn = false;
            try
            {
                Dictionary<String, Object> Params = new Dictionary<string, object>();
                Params.Add("@name", strMedicinetypeName);


                int iRetValue = AddDataSP("medicine_typeInsertRow", Params, ref strReturnMessage);

                bReturn = (iRetValue > 0) ? true : false;
            }
            catch (Exception ex)
            {
                strReturnMessage = "An Error Occured, Please Try Again Later";
            }

            return bReturn;
        }



        public DataTable getAllMedicineType()
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = GetSPData("medicine_typeSelectAll");
                return dtb;
            }
            catch (Exception ex)
            {
                return dtb;
            }
        }


        //MedicineType Delete function for Bal to DAL
        public bool MedicinetypenameDelete(string id, ref string strReturnMessage)
        {
            bool bReturn = false;
            try
            {
                Dictionary<String, Object> Params = new Dictionary<string, object>();
                Params.Add("@id", id);
                bReturn = AddUpdateDataSP("medicine_typeDeleteRow", Params, ref strReturnMessage);
            }
            catch (Exception ex)
            {
                strReturnMessage = "An Error Occured, Please Try Again Later";
            }

            return bReturn;
        }


        //MedicineType Update function for Bal to DAL
        public bool MedicinetypenameUpdate(string strMedicinetypeName, string strId, ref string strReturnMessage)
        {
            bool bReturn = false;
            try
            {
                Dictionary<String, Object> Params = new Dictionary<string, object>();
                Params.Add("@name", strMedicinetypeName);
                Params.Add("@id", strId);
                bReturn = AddUpdateDataSP("medicine_typeUpdateRow", Params, ref strReturnMessage);
            }
            catch (Exception ex)
            {
                strReturnMessage = "An Error Occured, Please Try Again Later";
            }

            return bReturn;
        }

    }
}
