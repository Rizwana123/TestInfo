
// GenericInsert HttpPost
var GenericInsertFeilds = { genericName: "" }

function callGenericnameInsert() {
    GenericInsertFeilds.genericName = $('#insertgenericname').val();
    httpPostRequest('/ApiGenericnames/GenericNameInsert', GenericInsertFeilds, callbackGenericnameInsert);
}

function callbackGenericnameInsert(data) {
    alert(data);
}


