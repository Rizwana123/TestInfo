// document.ready is automatically triggered when the page loads
$(document).ready(function () {
    getAllMedicines();
});

function getAllMedicines() {
    httpMVCGetRequest('/ApiMedicines/GetAllMedicines/', getMedicineId);
}


function getMedicineId(jsonData) {
    var ddMedicine = $('#ddmedicineID');
    for (var i = 0; i < jsonData.length; i++) {
        ddMedicine.append(
            "<option value='" + jsonData[i].id + "'>" + jsonData[i].name + "</option>"
        );
    }
}

function delMedicines() {
    //alert($('#medicinetypeID :selected').text());
    var medicineId = $('#ddmedicineID').val();
    httpMVCGetRequest('/ApiMedicines/DeleteMedicines/' + medicineId, DeleteMedicines)
}

function DeleteMedicines(data) {
    alert(data);
    $('#ddmedicineID').empty();
    getAllMedicines();
}