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
    public class usersController : ApiController
    {
     

        [HttpPost]
        public string InsertUsers(dynamic data)
        {
            string strResponse = "";
            string struserName = data.userName;
            string stremailAddress = data.emailAddress;
            string strPassword = data.Password;
            string strIsAdmin = data.isAdmin;
            
            

            Users objUser = new Users();
            bool bResult = objUser.InsertUser(struserName, stremailAddress, strPassword, strIsAdmin, ref strResponse);

            if (bResult)
            {
                strResponse = "User added successfully";
            }
            else
            {
                strResponse = "Failed to add user.";
            }

            return strResponse;
            
        }


        [HttpPost]
        public Boolean LoginUsers(dynamic data)
        {
            Boolean strResponse;
            string struserName = data.userName;
            string strPassword = data.password;

            Users objUser = new Users();
            bool bResult = objUser.SignInUser(struserName, strPassword);

            if (bResult)
            {
                strResponse = true;
            }
            else
            {
                strResponse = false;
            }

            return strResponse;

        }








        //[HttpGet] 
        //public string login(string UserName, string Password)
        //{
        //    Users objUser = new Users();
        //    bool bResult = objUser.ValidateUser(UserName, Password);
        //    string strResponse = "";
        //    if (bResult)
        //    {
        //        strResponse = "Login Successful";
        //    }
        //    else
        //    {
        //        strResponse = "Failed to Login.";
        //    }


        //    //string query = "select * from users where username='" + UserName + "' AND password='" + Password + "'";

        //    //DataTable dt = new DataTable(query);

        //    ////dt = bResult.getData(query);

        //    //if (dt.Rows.Count > 0)
        //    //{
        //    //    auth = true;

        //    //}

        //    return strResponse;  
        //}



    }

}

