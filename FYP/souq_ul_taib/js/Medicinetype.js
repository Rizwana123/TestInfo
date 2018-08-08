

// Medicinetype Insert HttpPost
var MedicinetypeInsertFeilds = { medicinetypeName: "" }

function callMedicinetypeInsert() {
    MedicinetypeInsertFeilds.medicinetypeName = $('#insertmedicinetypename').val();
    httpPostRequest('/ApiMedicinetypenames/MedicinetypeNameInsert', MedicinetypeInsertFeilds, callbackMedicinetypeInsert);
}

function callbackMedicinetypeInsert(data) {
    alert(data);
}


