$(document).ready(function () {
    var prodModel;
    var storeModel;
function NotifyError(message) {
    $('#err').html('');
    $("#err").append("<p>" + message + "</p>")
    $("#err").show("slow").delay(2000).hide("slow");
}

function NotifySuccess(message) {
    $('#info').html('');
    $("#info").append("<p>" + message + "</p>")
    $("#info").show("slow").delay(2000).hide("slow");
    }

    $("#prodSaveBtn").click(function () {
        $.ajax({
            type: "GET",
            url: "Home/GetProducts",
            method: "GET",
            dataType: 'json',
            contentType: false,
            processData: false,
            success: function (json) {
                if (json.isRedirect) {
                    window.location.href = json.redirectUrl;
                }
            },
            error: function () {
                NotifyError("Error Getting Data");
            }
        });
    }); 

    $("#storeSaveBtn").click(function () {
        $.ajax({
            type: "GET",
            url: "Home/GetStores",
            method: "GET",
            dataType: 'json',
            contentType: false,
            processData: false,
            success: function (json) {
                if (json.isRedirect) {
                    window.location.href = json.redirectUrl;
                }
            },
            error: function () {
                NotifyError("Error Getting Data");
            }
        });
    });

$("#prodBtn").click(function () {
    $.ajax({
        type: "POST",
        url: "/Home/GetProductsFromApi",
        success: function (data, msg) {
            if (msg !== "" && msg !== null && msg !== "success") {
                NotifyError(msg);
            }
            if (data === null || data.length <= 0) {
                NotifySuccess("response contains no data");
            }
            else {
                NotifySuccess("Products loaded successfully");
                if (data !== null) {
                    $("#productsJson").empty();
                    $("#productsJson").append(JSON.stringify(data));
                    prodModel = data;
                    $("#prodSaveBtn").show();
                }
            }
        },
        error: function () {
            NotifyError("Error Getting Data");
        }
    });
}); 


$("#storeBtn").click(function () {
    $.ajax({
        type: "POST",
        url: "/Home/GetStoresFromApi",
        success: function (data, msg) {

            if (msg !== "" && msg !== null && msg !== "success") {
                NotifyError(msg);
            }
            if (data === null || data.length <=0) {
                NotifySuccess("response contains no data");
            }
            else {
                NotifySuccess("Stores loaded successfully");
                if (data !== null) {
                    $("#storesJson").empty();
                    $("#storesJson").append(JSON.stringify(data));

                    $("#storeSaveBtn").show();
                }
            }
        },
        error: function () {
            NotifyError("Error Getting Data");
        }
    });
}); 
}); 
