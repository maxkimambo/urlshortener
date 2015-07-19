



var app = function () {
    var resultField =  $("#shortenerResult .form-inline > input");
    var resultDiv = $("#shortenerResult"); 
    function hideResult() {
        resultDiv.hide(); 
    }

    function shortenSuccess(response) {
        resultField.val(response.Url);
        resultDiv.show('slow'); 
        resultField.prop('readonly', true);
        resultField.select(); 

    }

    function shortenDone(response) {
        console.log(response);
    }




    return {
        shortenSuccess: shortenSuccess,
        shortenDone: shortenDone,
        hideResult: hideResult
    }
}(); 

$(document).ready(function () {
    app.hideResult();
   

});