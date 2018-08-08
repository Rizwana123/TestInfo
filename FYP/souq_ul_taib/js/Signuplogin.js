// SignUp Http Post start
var signUpFeilds = { userName: "", emailAddress: "", Password: "", isAdmin: true }

function callSignup() {
    signUpFeilds.userName = $('#username').val();
    signUpFeilds.emailAddress = $('#emailaddress').val();
    signUpFeilds.Password = $('#Signuppass').val();
    httpPostRequest('/users/InsertUsers', signUpFeilds, callbackSignup);
}

function callbackSignup(data) {
    alert(data);
}// SignUp Http Post



//login http post start
var signInFeilds = { userName: "", password: "" }

function callSignIn() {
    
    signInFeilds.userName = $('#nameuser').val();
    signInFeilds.password = $('#Signinpass').val();
    httpPostRequest('/users/LoginUsers', signInFeilds, callbackSignIn);
}

// yehe hai w
function callbackSignIn(data) {
    if (data == true) {

        window.location.href = '/Home/Index?login=' + data;
        //alert(data="Failed to Login");

    }
    else {
        //check  there 
        alert(data = "Failed to Login")
        //window.location.href = '/Home/Index?login=' + data;
    }
}//login http post endf






/* 
//Login http get not working (start)
var Username, Password;

function callLogIn() {

    Username = $('#nameuser').val();
    Password = $('#Signinpass').val();


    httpMVCGetRequest('api/users/login?UserName=zxczxc&Password=scasca', callbackLoginIn);
    //httpMVCGetRequest("api/users/login?UserName=" + nameuser + "&Password=" + Signinpass, callbackLoginIn);
    //httpMVCGetRequest("api/users/login?UserName=" + "#nameuser" + "&Password=" + "#Signinpass", callbackLoginIn);
   // httpMVCGetRequest("api/users/login?UserName=" + $('#nameuser') + "&Password=" + $('#Signinpass'), callbackLoginIn);
    //httpMVCGetRequest("api/users/login?UserName=" + $('#nameuser').val() + "&Password=" + $('#Signinpass').val(), callbackLoginIn);
  }

function callbackLoginIn(data) {
    alert(data);
}
//Login http get not working (end)
*/



//ManufacturerInsert httpPost start
var MamufacturerInsertFeilds = { manufactureName: "" }

function callManufacturerInsert() {
    MamufacturerInsertFeilds.manufactureName = $('#insertmanufacturename').val();
    httpPostRequest('/users/ManufactureNameInsert', MamufacturerInsertFeilds, callbackManufacturerInsert);
}

function callbackManufacturerInsert(data) {
    alert(data);
}//ManufacturerInsert httpPost end
// where  is call  back function