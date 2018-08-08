// document.ready is automatically triggered when the page loads
$(document).ready(function () {
    getAllGenericName();
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

function delGenericName() {
    //alert($('#medicinetypeID :selected').text());
    var genericNameId = $('#ddgenericnameDropDown').val();
    httpMVCGetRequest('/ApiGenericnames/DeleteGenericname/' + genericNameId, DeleteGenericName)
}

function DeleteGenericName(data) {
    alert(data);
    $('#ddgenericnameDropDown').empty();
    getAllGenericName();
}