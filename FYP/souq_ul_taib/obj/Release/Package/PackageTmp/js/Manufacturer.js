
// MaufacturerInsert HttpPost
var ManufacturerInsertFeilds = { manufactureName: "" }

function callManufacturerInsert() {
    ManufacturerInsertFeilds.manufactureName = $('#insertmanufacturer').val();
    httpPostRequest('/ApiManufacturers/ManufactureNameInsert', ManufacturerInsertFeilds, callbackManufacturerInsert);
}

function callbackManufacturerInsert(data) {
    alert(data);
}


