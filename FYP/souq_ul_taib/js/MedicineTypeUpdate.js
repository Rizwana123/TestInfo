$(document).ready(function () {
    getAllMedicineType();
    $("#ddmedicinetypeDropDown").change(function () {
        $('#txtMedicineTypeName').val($('#ddmedicinetypeDropDown :selected').text())

        //alert("Handler for .select() called.");
    });
});


function getAllMedicineType() {
    httpMVCGetRequest('/ApiMedicinetypenames/GetAllMedicineType/', getMedicineTypeId);
}

function getMedicineTypeId(jsonData) {
    var ddMedicineType = $('#ddmedicinetypeDropDown');
    for (var i = 0; i < jsonData.length; i++) {
        ddMedicineType.append(
            "<option value='" + jsonData[i].id + "'>" + jsonData[i].name + "</option>"
        );
    }
}


var MedicinetypeUpdateFeilds = { id: 0, medicinetypeName: "" }

function callMedicinetypeUpdate() {
    MedicinetypeUpdateFeilds.id = $('#ddmedicinetypeDropDown').val();
    MedicinetypeUpdateFeilds.medicinetypeName = $('#txtMedicineTypeName').val();
    httpPostRequest('/ApiMedicinetypenames/MedicinetypeNameUpdate', MedicinetypeUpdateFeilds, callbackMedicinetypeInsert);
}

function callbackMedicinetypeInsert(data) {
    alert(data);
    $('#ddmedicinetypeDropDown').empty();
    $('#txtMedicineTypeName').empty();
    getAllMedicineType();
}