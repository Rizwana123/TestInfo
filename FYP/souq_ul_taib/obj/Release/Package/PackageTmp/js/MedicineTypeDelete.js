// document.ready is automatically triggered when the page loads
$(document).ready(function () {
    getAllMedicineType();
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

function delMedicineType() {
    //alert($('#medicinetypeID :selected').text());
    var medicineTypeId = $('#ddmedicinetypeDropDown').val();
    httpMVCGetRequest('/ApiMedicinetypenames/DeleteMedicineType/' + medicineTypeId, DeleteMedicineType)
}

function DeleteMedicineType(data) {
    alert(data);
    $('#ddmedicinetypeDropDown').empty();
    getAllMedicineType();
}