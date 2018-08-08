$(document).ready(function () {
    getAllManufacturers();
    $("#manufacturerID").change(function () {
        $('#txtManufacturersName').val($('#manufacturerID :selected').text())

        //alert("Handler for .select() called.");
    });
});


function getAllManufacturers() {
    httpMVCGetRequest('/ApiManufacturers/GetAllManufacturers/', getManufacturersId);
}

function getManufacturersId(jsonData) {
    var ddManufacturers = $('#manufacturerID');
    for (var i = 0; i < jsonData.length; i++) {
        ddManufacturers.append(
            "<option value='" + jsonData[i].id + "'>" + jsonData[i].name + "</option>"
        );
    }
}


var ManufacturerUpdateFeilds = { id: 0, manufacturersName: "" }

function callManufacturerUpdate() {
    ManufacturerUpdateFeilds.id = $('#manufacturerID').val();
    ManufacturerUpdateFeilds.manufacturersName = $('#txtManufacturersName').val();
    httpPostRequest('/ApiManufacturers/ManufacturersUpdate', ManufacturerUpdateFeilds, callbackManufacturerInsert);
}


function callbackManufacturerInsert(data) {
    alert(data);
    $('#manufacturerID').empty();
    $('#txtManufacturersName').empty();
    getAllManufacturers();
}