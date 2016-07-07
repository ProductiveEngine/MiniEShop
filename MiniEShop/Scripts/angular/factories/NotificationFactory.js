eshopApp.factory('notificationFactory', function() {
    toastr.options = {
        "showDuration": "100",
        "hideDuration": "100",
        "timeOut": "2000",
        "extendedTimeOut": "5000",
    }
    
    return {
        
        success: function (text) {
            if (text === undefined) {
                text = '';
            }
            toastr.success("Success. " + text);
        },
        error: function (text) {
            if (text === undefined) {
                text = '';
            }
            toastr.error("Error. " + text);
        },
    };
});