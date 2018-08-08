// document.ready is automatically triggered when the page loads
$(document).ready(function () {
    getAllManufacturers();
});

function getAllManufacturers() {
    httpMVCGetRequest('/ApiManufacturers/GetAllManufacturers/', getManufacturersId);
}


function getManufacturersId(jsonData) {
    var ddManufacturers = $('#ddmanufacturerID');
    for (var i = 0; i < jsonData.length; i++) {
        ddManufacturers.append(
            "<option value='" + jsonData[i].id + "'>" + jsonData[i].name + "</option>"
        );
    }
}

function delManufacturer() {
    //alert($('#medicinetypeID :selected').text());
    var manufacturersId = $('#ddmanufacturerID').val();
    httpMVCGetRequest('/ApiManufacturers/DeleteManufacturers/' + manufacturersId, DeleteManufacturers)
}

function DeleteManufacturers(data) {
    alert(data);
    $('#ddmanufacturerID').empty();
    getAllManufacturers();
}