$(document).ready(function () {
    getAllMedicines();
    getAllMedicineType();
    getAllGenericName();
    getAllManufacturers();
});


function getAllMedicines() {
    httpMVCGetRequest('/ApiMedicines/GetAllMedicines/', getMedicineId);
}
function getMedicineId(jsonData) {
    var ddMedicines = $('#ddmedicineidDropDown');
    for (var i = 0; i < jsonData.length; i++) {
        ddMedicines.append(
            "<option value='" + jsonData[i].id + "'>" + jsonData[i].name + "</option>"
        );
    }
}



function getAllMedicineType() {
    httpMVCGetRequest('/ApiMedicinetypenames/GetAllMedicineType/', getMedicineTypeId);
}
function getMedicineTypeId(jsonData) {
    var ddMedicineType = $('#ddmedicinetypeidDropDown');
    for (var i = 0; i < jsonData.length; i++) {
        ddMedicineType.append(
            "<option value='" + jsonData[i].id + "'>" + jsonData[i].name + "</option>"
        );
    }
}



function getAllGenericName() {
    httpMVCGetRequest('/ApiGenericnames/GetAllGenericName/', getGenericNameId);
}
function getGenericNameId(jsonData) {
    var ddGenericName = $('#ddgenericnameidDropDown');
    for (var i = 0; i < jsonData.length; i++) {
        ddGenericName.append(
            "<option value='" + jsonData[i].id + "'>" + jsonData[i].name + "</option>"
        );
    }
}



function getAllManufacturers() {
    httpMVCGetRequest('/ApiManufacturers/GetAllManufacturers/', getManufacturersId);
}
function getManufacturersId(jsonData) {
    var ddManufacturers = $('#ddmanufactureidDropDown');
    for (var i = 0; i < jsonData.length; i++) {
        ddManufacturers.append(
            "<option value='" + jsonData[i].id + "'>" + jsonData[i].name + "</option>"
        );
    }
}


// Medicine Insert HttpPost
var MedicineUpdateFeilds = { id: "", medicineName: "", medicinetypeid: "", medicinecontentvalue: "", medicinecontenttype: "", packetsize: "", packetprice: "", dosage: "", genericid: "", manufacturerid: "", usage: "", sideeffect: "", alternate: "" }

function callMedicineUpdate() {
    MedicineUpdateFeilds.id = $('#ddmedicineidDropDown').val();
    MedicineUpdateFeilds.medicineName = $('#txtmedicinename').val();
    MedicineUpdateFeilds.medicinetypeid = $('#ddmedicinetypeidDropDown').val();
    MedicineUpdateFeilds.medicinecontentvalue = $('#txtmedicinecontentvalue').val();
    MedicineUpdateFeilds.medicinecontenttype = $('#txtmedicinecontenttype').val();
    MedicineUpdateFeilds.packetsize = $('#txtpacketsize').val();
    MedicineUpdateFeilds.packetprice = $('#txtpacketprice').val();
    MedicineUpdateFeilds.dosage = $('#txtdosage').val();
    MedicineUpdateFeilds.genericid = $('#ddgenericnameidDropDown').val();
    MedicineUpdateFeilds.manufacturerid = $('#ddmanufactureidDropDown').val();
    MedicineUpdateFeilds.usage = $('#txtusage').val();
    MedicineUpdateFeilds.sideeffect = $('#txtsideeffect').val();
    MedicineUpdateFeilds.alternate = $('#txtalternate').val();



    httpPostRequest('/ApiMedicines/MedicinesUpdate', MedicineUpdateFeilds, callbackMedicineUpdate);
}

function callbackMedicineUpdate(data) {
    alert(data);
    $('#ddmedicineidDropDown').empty();
    getAllMedicines();
}


