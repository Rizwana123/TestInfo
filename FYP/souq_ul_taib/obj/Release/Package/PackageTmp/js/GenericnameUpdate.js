$(document).ready(function () {
    getAllGenericName();
    $("#ddgenericnameDropDown").change(function () {
        $('#txtGenericName').val($('#ddgenericnameDropDown :selected').text())

        //alert("Handler for .select() called.");
    });
});


function getAllGenericName() {
    httpMVCGetRequest('/ApiGenericnames/GetAllGenericName/', getGenericNameId);
}

function getGenericNameId(jsonData) {
    var ddGenericName = $('#ddgenericnameDropDown');
    for (var i = 0; i < jsonData.length; i++) {
        ddGenericName.append(
            "<option value='" + jsonData[i].id + "'>" + jsonData[i].name + "</option>"
        );
    }
}


var GenericnameUpdateFeilds = { id: 0, genericName: "" }

function callGenericnameUpdate() {
    GenericnameUpdateFeilds.id = $('#ddgenericnameDropDown').val();
    GenericnameUpdateFeilds.genericName = $('#txtGenericName').val();
    httpPostRequest('/ApiGenericnames/GenericNameUpdate', GenericnameUpdateFeilds, callbackGenericnameInsert);
}

function callbackGenericnameInsert(data) {
    alert(data);
    $('#ddgenericnameDropDown').empty();
    $('#txtGenericName').empty();
    getAllGenericName();
}