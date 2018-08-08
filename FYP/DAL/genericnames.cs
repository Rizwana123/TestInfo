using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class Genericnames : Connection
    {
        //Generic function for Bal to DAL
        public bool GenericnameInsert(string strGenericName, ref string strReturnMessage)
        {
            bool bReturn = false;
            try
            {
                Dictionary<String, Object> Params = new Dictionary<string, object>();
                Params.Add("@name", strGenericName);


                int iRetValue = AddDataSP("generic_nameInsertRow", Params, ref strReturnMessage);

                bReturn = (iRetValue > 0) ? true : false;
            }
            catch (Exception ex)
            {
                strReturnMessage = "An Error Occured, Please Try Again Later";
            }

            return bReturn;
        }



        public DataTable getAllGenericName()
        {
            DataTable dtb = new DataTable();
            try
            {
                dtb = GetSPData("generic_nameSelectAll");
                return dtb;
            }
            catch (Exception ex)
            {
                return dtb;
            }
        }



        //GenericName Delete function for Bal to DAL
        public bool GenericnameDelete(string id, ref string strReturnMessage)
        {
            bool bReturn = false;
            try
            {
                Dictionary<String, Object> Params = new Dictionary<string, object>();
                Params.Add("@id", id);
                bReturn = AddUpdateDataSP("generic_nameDeleteRow", Params, ref strReturnMessage);
            }
            catch (Exception ex)
            {
                strReturnMessage = "An Error Occured, Please Try Again Later";
            }

            return bReturn;
        }


        //GenericName Update function for Bal to DAL
        public bool GenericnameUpdate(string strGenericName, string strId, ref string strReturnMessage)
        {
            bool bReturn = false;
            try
            {
                Dictionary<String, Object> Params = new Dictionary<string, object>();
                Params.Add("@name", strGenericName);
                Params.Add("@id", strId);
                bReturn = AddUpdateDataSP("generic_nameUpdateRow", Params, ref strReturnMessage);
            }
            catch (Exception ex)
            {
                strReturnMessage = "An Error Occured, Please Try Again Later";
            }

            return bReturn;
        }


    }
}
