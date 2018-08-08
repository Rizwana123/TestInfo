using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class Users : Connection
    {
        public bool InsertUser(string strUserName, string strEmailAddress, string strPassword, string strIsActive, ref string strReturnMessage)
        {
            bool bReturn = false;
            try
            {
                Dictionary<String, Object> Params = new Dictionary<string, object>();
                Params.Add("@user_name", strUserName);
                Params.Add("@email", strEmailAddress);
                Params.Add("@password_", strPassword);
                Params.Add("@is_admin", strIsActive);
                
                int iRetValue = AddDataSP("add_users", Params, ref strReturnMessage);

                bReturn = (iRetValue > 0) ? true : false;
            }
            catch (Exception ex)
            {
                strReturnMessage = "An Error Occured, Please Try Again Later";
            }

            return bReturn;
        }



        //Login HttpPost
        public bool SignInUser(string strUserName, string strPassword)
        {
            string strQuery = "SELECT * FROM [dbo].[user] WHERE user_name = '" + strUserName + "' and password_ = '" + strPassword + "'";

            DataTable dtb = GetDataFromQuery(strQuery);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}
