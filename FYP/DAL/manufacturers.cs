using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class Manufacturers : Connection
    {
        //Manufacture function for Bal to DAL
        public bool ManufacturenameInsert(string strManufactureName, ref string strReturnMessage)
        {
            bool bReturn = false;
            try
            {
                Dictionary<String, Object> Params = new Dictionary<string, object>();
                Params.Add("@name", strManufactureName);


                int iRetValue = AddDataSP("manufactureInsertRow", Params, ref strReturnMessage);

                bReturn = (iRetValue > 0) ? true : false;
            }
            catch (Exception ex)
            {
                strReturnMessage = "An Error Occured, Please Try Again Later";
            }

            return bReturn;
        }

        public DataTable getAllManufacturers()
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = GetSPData("manufactureSelectAll");
                return dtb;
            }
            catch (Exception ex)
            {
                return dtb;
            }
        }

        public bool ManufacturersDelete(string id, ref string strReturnMessage)
        {
            bool bReturn = false;
            try
            {
                Dictionary<String, Object> Params = new Dictionary<string, object>();
                Params.Add("@id", id);
                bReturn = AddUpdateDataSP("manufactureDeleteRow", Params, ref strReturnMessage);
            }
            catch (Exception ex)
            {
                strReturnMessage = "An Error Occured, Please Try Again Later";
            }

            return bReturn;
        }

        public bool ManufacturersUpdate(string strManufacturersName, string strId, ref string strReturnMessage)
        {
            bool bReturn = false;
            try
            {
                Dictionary<String, Object> Params = new Dictionary<string, object>();
                Params.Add("@name", strManufacturersName);
                Params.Add("@id", strId);
                bReturn = AddUpdateDataSP("manufactureUpdateRow", Params, ref strReturnMessage);
            }
            catch (Exception ex)
            {
                strReturnMessage = "An Error Occured, Please Try Again Later";
            }

            return bReturn;
        }

    }
}




