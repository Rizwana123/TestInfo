$(document).ready(function () {
    getAllMedicineType();
    getAllGenericName();
    getAllManufacturers();
});


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
var MedicineInsertFeilds = { medicineName: "", medicinetypeid: "", medicinecontentvalue: "", medicinecontenttype: "", packetsize: "", packetprice: "", dosage: "", genericid: "", manufacturerid: "", usage: "", sideeffect: "", alternate: "" }

function callMedicineInsert() {
    MedicineInsertFeilds.medicineName = $('#txtmedicinename').val();
    MedicineInsertFeilds.medicinetypeid = $('#ddmedicinetypeidDropDown').val();
    MedicineInsertFeilds.medicinecontentvalue = $('#txtmedicinecontentvalue').val();
    MedicineInsertFeilds.medicinecontenttype = $('#txtmedicinecontenttype').val();
    MedicineInsertFeilds.packetsize = $('#txtpacketsize').val();
    MedicineInsertFeilds.packetprice = $('#txtpacketprice').val();
    MedicineInsertFeilds.dosage = $('#txtdosage').val();
    MedicineInsertFeilds.genericid = $('#ddgenericnameidDropDown').val();
    MedicineInsertFeilds.manufacturerid = $('#ddmanufactureidDropDown').val();
    MedicineInsertFeilds.usage = $('#txtusage').val();
    MedicineInsertFeilds.sideeffect = $('#txtsideeffect').val();
    MedicineInsertFeilds.alternate = $('#txtalternate').val();



    httpPostRequest('/ApiMedicines/InsertMedicines', MedicineInsertFeilds, callbackMedicineInsert);
}

function callbackMedicineInsert(data) {
    alert(data);
}


