function httpMVCGetRequest(url, callback, errcallback) {

    url = window.location.origin+ /api/ + url;
    $.ajax({
        type: "GET",
        url: url,
        contentType: "application/json; charset=utf-8",
        //dataType: "jsonp",
        async: true,
        success: callback,
        error: errcallback
    });
}

function httpPostRequest(url, data, callback, errcallback) {

    url = window.location.origin + '/api/' + url;
    $.ajax({
        type: "POST",
        url: url,
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        async: true,
        success: callback,
        error: errcallback
    });
}